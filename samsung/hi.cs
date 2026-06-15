using System;
using System.Collections.Generic;

namespace SamsungServicesApp
{
    // 1. Lớp cơ sở (Base Class) chứa các thông tin chung của dịch vụ Samsung
    public class SamsungService
    {
        public string Name { get; set; }
        public string Purpose { get; set; }
        public string CoreTechnology { get; set; }
        public List<string> KeyFeatures { get; set; } = new List<string>();

        public SamsungService(string name, string purpose, string coreTechnology)
        {
            Name = name;
            Purpose = purpose;
            CoreTechnology = coreTechnology;
        }

        // Phương thức ảo để các lớp con ghi đè (Override) thông tin riêng
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"========================================");
            Console.WriteLine($"Tên dịch vụ: {Name}");
            Console.WriteLine($"Mục đích: {Purpose}");
            Console.WriteLine($"Công nghệ cốt lõi: {CoreTechnology}");
            Console.WriteLine("Tính năng chính:");
            foreach (var feature in KeyFeatures)
            {
                Console.WriteLine($"  - {feature}");
            }
        }
    }

    // 2. Lớp con dành riêng cho Samsung Pass
    public class SamsungPass : SamsungService
    {
        public string SecurityPlatform { get; set; }
        public bool IsSamsungExclusive { get; set; }

        public SamsungPass() : base(
            "Samsung Pass", 
            "Quản lý mật khẩu và bảo mật đăng nhập", 
            "Sinh trắc học (Biometric Authentication)")
        {
            SecurityPlatform = "Samsung Knox (Phần cứng)";
            IsSamsungExclusive = true;
            
            KeyFeatures.Add("Tự động điền mật khẩu (Autofill)");
            KeyFeatures.Add("Hỗ trợ Passkey không mật khẩu");
            KeyFeatures.Add("Lưu trữ thông tin thẻ ngân hàng");
            KeyFeatures.Add("Chìa khóa kỹ thuật số (Digital Key) cho xe/nhà");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Nền tảng bảo mật: {SecurityPlatform}");
            Console.WriteLine($"Độc quyền thiết bị Samsung: {(IsSamsungExclusive ? "Có" : "Không")}");
        }
    }

    // 3. Lớp con dành riêng cho Samsung Food
    public class SamsungFood : SamsungService
    {
        public string DeviceIntegration { get; set; }
        public string PlatformSupport { get; set; }

        public SamsungFood() : base(
            "Samsung Food", 
            "Gợi ý công thức và lên kế hoạch ăn uống", 
            "Trí tuệ nhân tạo (Food AI)")
        {
            DeviceIntegration = "Thiết bị nhà bếp thông minh (SmartThings Cooking)";
            PlatformSupport = "Đa nền tảng (Hỗ trợ cả Android khác và iOS)";

            KeyFeatures.Add("Lưu và tùy biến công thức bằng AI");
            KeyFeatures.Add("Lên kế hoạch bữa ăn theo tuần");
            KeyFeatures.Add("Tự động tạo danh sách đi chợ");
            KeyFeatures.Add("Gửi thông số nấu trực tiếp đến lò nướng thông minh");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Kết nối thiết bị: {DeviceIntegration}");
            Console.WriteLine($"Hỗ trợ nền tảng: {PlatformSupport}");
        }
    }

    // 4. Chương trình chính (Main Program) để chạy ứng dụng ổn định
    class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập hiển thị tiếng Việt có dấu trên Console ổn định
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Khởi tạo danh sách lưu trữ dữ liệu tập trung
            List<SamsungService> ecosystem = new List<SamsungService>();

            // Nạp dữ liệu vào bộ nhớ
            ecosystem.Add(new SamsungPass());
            ecosystem.Add(new SamsungFood());

            Console.WriteLine("--- HỆ SINH THÁI ỨNG DỤNG SAMSUNG ---");

            // Vòng lặp chạy và hiển thị dữ liệu ổn định nhờ tính Đa hình (Polymorphism)
            foreach (var service in ecosystem)
            {
                service.DisplayInfo();
                Console.WriteLine();
            }

            Console.WriteLine("========================================");
            Console.WriteLine("Nhấn phím bất kỳ để thoát chương trình...");
            Console.ReadKey();
        }
    }
}
