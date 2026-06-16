using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

// ============ 1. ENTITIES & ENUMS ============
public enum OrderStatus
{
    Planned,
    MaterialReady,
    Produced,
    QCPassed,
    Shipped,
    Failed
}

public class ProductionOrder
{
    public Guid Id { get; set; }
    public string ProductCode { get; set; }
    public int Quantity { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public string ErrorMessage { get; set; }

    public ProductionOrder(string productCode, int quantity)
    {
        Id = Guid.NewGuid();
        ProductCode = productCode;
        Quantity = quantity;
        Status = OrderStatus.Planned;
        CreatedAt = DateTime.Now;
    }

    public override string ToString() 
        => $"[{Id.ToString().Substring(0,8)}] {ProductCode} x{Quantity} => {Status}";
}

// ============ 2. EVENTS ============
public abstract class DomainEvent
{
    public Guid OrderId { get; set; }
    public DateTime OccurredOn { get; set; } = DateTime.Now;
}

public class MaterialReadyEvent : DomainEvent { }
public class ProducedEvent : DomainEvent { }
public class QCPassedEvent : DomainEvent { }
public class QCFailedEvent : DomainEvent { public string Reason { get; set; } }
public class OrderShippedEvent : DomainEvent { public string TrackingNumber { get; set; } }

// ============ 3. IN-MEMORY REPOSITORY ============
public interface IOrderRepository
{
    Task<ProductionOrder> GetById(Guid id);
    Task Update(ProductionOrder order);
    Task<List<ProductionOrder>> GetAll();
}

public class InMemoryOrderRepository : IOrderRepository
{
    private static readonly Dictionary<Guid, ProductionOrder> _db = new();

    public Task<ProductionOrder> GetById(Guid id) 
        => Task.FromResult(_db.GetValueOrDefault(id));

    public Task Update(ProductionOrder order)
    {
        _db[order.Id] = order;
        return Task.CompletedTask;
    }

    public Task<List<ProductionOrder>> GetAll() 
        => Task.FromResult(_db.Values.ToList());
}

// ============ 4. EVENT BUS (SIMPLE IN-MEMORY) ============
public interface IEventBus
{
    Task Publish<T>(T @event) where T : DomainEvent;
    void Subscribe<T>(Func<T, Task> handler) where T : DomainEvent;
}

public class InMemoryEventBus : IEventBus
{
    private readonly Dictionary<Type, List<Delegate>> _handlers = new();

    public void Subscribe<T>(Func<T, Task> handler) where T : DomainEvent
    {
        var type = typeof(T);
        if (!_handlers.ContainsKey(type))
            _handlers[type] = new List<Delegate>();
        _handlers[type].Add(handler);
    }

    public async Task Publish<T>(T @event) where T : DomainEvent
    {
        var type = typeof(T);
        if (_handlers.TryGetValue(type, out var handlers))
        {
            foreach (var handler in handlers.Cast<Func<T, Task>>())
            {
                await handler(@event);
            }
        }
    }
}

// ============ 5. SERVICES ============
public interface IProductionService
{
    Task<ProductionOrder> PlanOrder(string productCode, int quantity);
    Task ReceiveMaterial(Guid orderId);
}

public class ProductionService : IProductionService
{
    private readonly IOrderRepository _repo;
    private readonly IEventBus _eventBus;

    public ProductionService(IOrderRepository repo, IEventBus eventBus)
    {
        _repo = repo;
        _eventBus = eventBus;
    }

    public async Task<ProductionOrder> PlanOrder(string productCode, int quantity)
    {
        var order = new ProductionOrder(productCode, quantity);
        await _repo.Update(order);
        Console.WriteLine($"[PLAN] Đã tạo đơn: {order}");
        return order;
    }

    public async Task ReceiveMaterial(Guid orderId)
    {
        var order = await _repo.GetById(orderId);
        if (order == null) 
            throw new Exception("Không tìm thấy đơn hàng");

        order.Status = OrderStatus.MaterialReady;
        await _repo.Update(order);
        Console.WriteLine($"[MATERIAL] Nguyên liệu sẵn sàng: {order}");

        await _eventBus.Publish(new MaterialReadyEvent { OrderId = orderId });
    }
}

// ============ 6. HANDLERS (TỰ ĐỘNG PHẢN ỨNG VỚI EVENT) ============
public class ProductionHandlers
{
    private readonly IOrderRepository _repo;
    private readonly IEventBus _eventBus;
    private static readonly Random _rand = new();

    public ProductionHandlers(IOrderRepository repo, IEventBus eventBus)
    {
        _repo = repo;
        _eventBus = eventBus;
    }

    // Xử lý khi nguyên liệu sẵn sàng => Tiến hành sản xuất
    public async Task HandleMaterialReady(MaterialReadyEvent evt)
    {
        var order = await _repo.GetById(evt.OrderId);
        if (order == null) return;

        Console.WriteLine($"[PRODUCTION] Đang sản xuất: {order}...");
        await Task.Delay(1500); // Giả lập thời gian gia công

        order.Status = OrderStatus.Produced;
        await _repo.Update(order);
        Console.WriteLine($"[PRODUCTION] Sản xuất hoàn tất: {order}");

        await _eventBus.Publish(new ProducedEvent { OrderId = evt.OrderId });
    }

    // Xử lý khi sản xuất xong => Kiểm tra chất lượng (QC)
    public async Task HandleProduced(ProducedEvent evt)
    {
        var order = await _repo.GetById(evt.OrderId);
        if (order == null) return;

        Console.WriteLine($"[QC] Đang kiểm tra chất lượng: {order}...");
        await Task.Delay(1000);

        // Giả lập 90% đạt QC
        bool isPass = _rand.NextDouble() < 0.9;

        if (isPass)
        {
            order.Status = OrderStatus.QCPassed;
            await _repo.Update(order);
            Console.WriteLine($"[QC] ✅ ĐẠT chất lượng: {order}");
            await _eventBus.Publish(new QCPassedEvent { OrderId = evt.OrderId });
        }
        else
        {
            order.Status = OrderStatus.Failed;
            order.ErrorMessage = "Lỗi kỹ thuật từ QC";
            await _repo.Update(order);
            Console.WriteLine($"[QC] ❌ KHÔNG ĐẠT: {order}");
            await _eventBus.Publish(new QCFailedEvent { OrderId = evt.OrderId, Reason = order.ErrorMessage });
        }
    }

    // Xử lý khi QC Pass => Giao cho Logistics vận chuyển
    public async Task HandleQCPassed(QCPassedEvent evt)
    {
        var order = await _repo.GetById(evt.OrderId);
        if (order == null) return;

        Console.WriteLine($"[LOGISTICS] Đang đặt vận chuyển cho: {order}...");
        await Task.Delay(800);

        var tracking = $"VN{_rand.Next(100000, 999999)}";
        order.Status = OrderStatus.Shipped;
        await _repo.Update(order);
        Console.WriteLine($"[LOGISTICS] 🚚 ĐÃ GIAO HÀNG - Mã vận đơn: {tracking}");

        await _eventBus.Publish(new OrderShippedEvent 
        { 
            OrderId = evt.OrderId, 
            TrackingNumber = tracking 
        });
    }

    // Xử lý khi QC Failed => Thông báo lỗi
    public async Task HandleQCFailed(QCFailedEvent evt)
    {
        var order = await _repo.GetById(evt.OrderId);
        Console.WriteLine($"[ALERT] ⚠️ Đơn hàng {order?.Id} thất bại: {evt.Reason}");
        // Ở đây có thể gửi email/SMS cho bộ phận sản xuất
        await Task.CompletedTask;
    }

    // Xử lý khi ship thành công => Thông báo cho khách
    public async Task HandleOrderShipped(OrderShippedEvent evt)
    {
        var order = await _repo.GetById(evt.OrderId);
        Console.WriteLine($"[CUSTOMER] 📧 Đã gửi email thông báo giao hàng cho đơn {order?.Id} - Tracking: {evt.TrackingNumber}");
        await Task.CompletedTask;
    }
}

// ============ 7. MAIN PROGRAM (CHẠY MÔ PHỎNG) ============
class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("===== HỆ THỐNG SẢN XUẤT - GIAO HÀNG (C# EVENT DRIVEN) =====\n");

        // 7.1. Khởi tạo DI thủ công (không cần container cho demo)
        var repo = new InMemoryOrderRepository();
        var eventBus = new InMemoryEventBus();
        var productionService = new ProductionService(repo, eventBus);
        var handlers = new ProductionHandlers(repo, eventBus);

        // 7.2. Đăng ký Handler với EventBus
        eventBus.Subscribe<MaterialReadyEvent>(handlers.HandleMaterialReady);
        eventBus.Subscribe<ProducedEvent>(handlers.HandleProduced);
        eventBus.Subscribe<QCPassedEvent>(handlers.HandleQCPassed);
        eventBus.Subscribe<QCFailedEvent>(handlers.HandleQCFailed);
        eventBus.Subscribe<OrderShippedEvent>(handlers.HandleOrderShipped);

        // 7.3. Mô phỏng quy trình với 2 đơn hàng
        var order1 = await productionService.PlanOrder("LAPTOP-15", 10);
        await productionService.ReceiveMaterial(order1.Id);

        var order2 = await productionService.PlanOrder("PHONE-X", 50);
        await productionService.ReceiveMaterial(order2.Id);

        // 7.4. Chờ các handler xử lý xong (bất đồng bộ)
        Console.WriteLine("\n⏳ Đang xử lý các đơn hàng...");
        await Task.Delay(6000);

        // 7.5. In kết quả cuối cùng
        Console.WriteLine("\n===== KẾT QUẢ CUỐI CÙNG =====");
        var allOrders = await repo.GetAll();
        foreach (var o in allOrders)
        {
            Console.WriteLine($"- {o}");
            if (!string.IsNullOrEmpty(o.ErrorMessage))
                Console.WriteLine($"  LỖI: {o.ErrorMessage}");
        }

        Console.WriteLine("\n✅ Hoàn tất! Nhấn phím bất kỳ để thoát...");
        Console.ReadKey();
    }
}