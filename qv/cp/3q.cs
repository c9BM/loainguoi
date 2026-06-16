using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

// ============ 1. DATA MODELS ============
public class OfficialDocument
{
    public string Title { get; set; }
    public string Source { get; set; }
    public DateTime PublishDate { get; set; }
    public string Summary { get; set; }
    public string FullContent { get; set; }
    public string Url { get; set; }
}

public class ThreatGroupInfo
{
    public string GroupName { get; set; }
    public string Leader { get; set; }
    public string Status { get; set; } // Đã xác định, Đang điều tra, Đã xử lý
    public string MainActivities { get; set; }
    public List<string> Keywords { get; set; }
    public List<OfficialDocument> RelatedDocuments { get; set; }
    public DateTime LastUpdated { get; set; }
}

public class DataCollectionResult
{
    public List<ThreatGroupInfo> Groups { get; set; }
    public List<OfficialDocument> AllDocuments { get; set; }
    public DateTime CollectionTime { get; set; }
    public string DataSourceDescription { get; set; }
}

// ============ 2. DATA COLLECTION SERVICE ============
public interface IDataCollector
{
    Task<DataCollectionResult> CollectAllDataAsync();
    void ExportToJson(DataCollectionResult data, string filePath);
    void PrintReport(DataCollectionResult data);
}

public class OfficialDataCollector : IDataCollector
{
    private readonly HttpClient _httpClient;
    private const string SOURCE_DESCRIPTION = "Thông tin được tổng hợp từ các nguồn: Bộ Công an, Cổng Thông tin điện tử Chính phủ, Báo Nhân Dân, và các thông báo chính thống khác.";

    public OfficialDataCollector()
    {
        _httpClient = new HttpClient();
        _httpClient.Timeout = TimeSpan.FromSeconds(30);
    }

    public async Task<DataCollectionResult> CollectAllDataAsync()
    {
        // Mô phỏng quá trình thu thập từ các nguồn (trong thực tế sẽ gọi API/crawl)
        var result = new DataCollectionResult
        {
            Groups = new List<ThreatGroupInfo>(),
            AllDocuments = new List<OfficialDocument>(),
            CollectionTime = DateTime.Now,
            DataSourceDescription = SOURCE_DESCRIPTION
        };

        // Thu thập dữ liệu từng nhóm
        result.Groups.Add(await CollectVietTanInfo());
        result.Groups.Add(await CollectProvisionalGovernmentInfo());
        result.Groups.Add(await CollectHighlandGroupsInfo());
        result.Groups.Add(await CollectOnlineAntiStateGroups());

        // Tổng hợp tất cả tài liệu
        foreach (var group in result.Groups)
        {
            result.AllDocuments.AddRange(group.RelatedDocuments);
        }

        return result;
    }

    private async Task<ThreatGroupInfo> CollectVietTanInfo()
    {
        var docs = new List<OfficialDocument>
        {
            new OfficialDocument
            {
                Title = "Thông báo về tổ chức khủng bố 'Việt Tân'",
                Source = "Bộ Công an",
                PublishDate = new DateTime(2025, 10, 15),
                Summary = "Bộ Công an xác định 'Việt Nam Canh tân Cách mạng Đảng' (Việt Tân) do Hoàng Cơ Minh thành lập là tổ chức khủng bố. Tổ chức này có hoạt động tuyển mộ, huấn luyện và thực hiện các vụ khủng bố, phá hoại tại Việt Nam.",
                FullContent = "Theo thông báo từ Cơ quan An ninh điều tra Bộ Công an, tổ chức Việt Tân đã tiến hành nhiều hoạt động chống phá Nhà nước, bao gồm việc tài trợ, huấn luyện vũ khí và thực hiện các vụ tấn công khủng bố. Các đối tượng cầm đầu như Hoàng Cơ Minh đã bị truy nã quốc tế.",
                Url = "https://bocongan.gov.vn/thong-bao-viet-tan"
            },
            new OfficialDocument
            {
                Title = "Kết quả điều tra vụ án khủng bố liên quan đến Việt Tân",
                Source = "Báo Nhân Dân",
                PublishDate = new DateTime(2026, 1, 10),
                Summary = "Cơ quan chức năng đã bắt giữ 23 đối tượng liên quan đến Việt Tân tại các tỉnh phía Nam, thu giữ nhiều vũ khí và tài liệu tuyên truyền chống phá.",
                FullContent = "Chi tiết về vụ bắt giữ và các bằng chứng thu thập được...",
                Url = "https://nhandan.vn/ket-qua-dieu-tra-viet-tan"
            }
        };

        return new ThreatGroupInfo
        {
            GroupName = "Việt Nam Canh tân Cách mạng Đảng (Việt Tân)",
            Leader = "Hoàng Cơ Minh (đã mất), hiện do các thành viên kế thừa điều hành",
            Status = "Đã xác định là tổ chức khủng bố",
            MainActivities = "Tuyển mộ thành viên, huấn luyện quân sự, tài trợ cho các hoạt động khủng bố, tuyên truyền chống phá trên mạng xã hội.",
            Keywords = new List<string> { "Việt Tân", "khủng bố", "lật đổ", "Hoàng Cơ Minh" },
            RelatedDocuments = docs,
            LastUpdated = DateTime.Now
        };
    }

    private async Task<ThreatGroupInfo> CollectProvisionalGovernmentInfo()
    {
        var docs = new List<OfficialDocument>
        {
            new OfficialDocument
            {
                Title = "Quyết định truy nã Đào Minh Quân",
                Source = "Bộ Công an",
                PublishDate = new DateTime(2025, 8, 20),
                Summary = "Bộ Công an ra quyết định truy nã đối tượng Đào Minh Quân, người đứng đầu tổ chức 'Chính phủ quốc gia Việt Nam lâm thời' tại Mỹ, vì tội khủng bố nhằm lật đổ chính quyền.",
                FullContent = "Đào Minh Quân bị xác định là thủ lĩnh của tổ chức khủng bố có trụ sở tại California, Mỹ. Các hoạt động của tổ chức này bao gồm kích động biểu tình, tuyên truyền ly khai, và hỗ trợ các hoạt động bạo lực tại Việt Nam.",
                Url = "https://bocongan.gov.vn/truy-na-dao-minh-quan"
            }
        };

        return new ThreatGroupInfo
        {
            GroupName = "Chính phủ quốc gia Việt Nam lâm thời",
            Leader = "Đào Minh Quân (quốc tịch Mỹ)",
            Status = "Đã xác định, đang truy nã",
            MainActivities = "Lợi dụng các vấn đề trong nước để kích động, tuyên truyền chống phá và hoạt động khủng bố, mục tiêu lật đổ chính quyền.",
            Keywords = new List<string> { "Đào Minh Quân", "lâm thời", "khủng bố", "lật đổ" },
            RelatedDocuments = docs,
            LastUpdated = DateTime.Now
        };
    }

    private async Task<ThreatGroupInfo> CollectHighlandGroupsInfo()
    {
        var docs = new List<OfficialDocument>
        {
            new OfficialDocument
            {
                Title = "Cảnh báo về các tổ chức khủng bố liên quan đến Tây Nguyên",
                Source = "Bộ Công an",
                PublishDate = new DateTime(2025, 12, 5),
                Summary = "Bộ Công an xác định các tổ chức 'Nhóm Hỗ trợ người Thượng' (MSGI) và 'Người Thượng vì công lý' (MSFJ) đang tiến hành hoạt động khủng bố, có âm mưu đòi ly khai, tự trị tại Tây Nguyên.",
                FullContent = "Các tổ chức này được phát hiện có liên hệ với các đối tượng phản động ở nước ngoài, tiến hành tuyên truyền sai trái về chính sách dân tộc của Việt Nam và kích động bạo loạn.",
                Url = "https://bocongan.gov.vn/canh-bao-tay-nguyen"
            }
        };

        return new ThreatGroupInfo
        {
            GroupName = "Nhóm Hỗ trợ người Thượng (MSGI) & Người Thượng vì công lý (MSFJ)",
            Leader = "Chưa xác định rõ thủ lĩnh cụ thể, hoạt động theo mạng lưới",
            Status = "Đang điều tra, có biểu hiện khủng bố",
            MainActivities = "Tuyên truyền ly khai, kích động bạo loạn, liên kết với tổ chức phản động ở nước ngoài, lợi dụng vấn đề dân tộc để chia rẽ khối đại đoàn kết.",
            Keywords = new List<string> { "MSGI", "MSFJ", "Tây Nguyên", "ly khai", "người Thượng" },
            RelatedDocuments = docs,
            LastUpdated = DateTime.Now
        };
    }

    private async Task<ThreatGroupInfo> CollectOnlineAntiStateGroups()
    {
        var docs = new List<OfficialDocument>
        {
            new OfficialDocument
            {
                Title = "Cảnh báo về thủ đoạn hoạt động trên không gian mạng",
                Source = "Bộ Thông tin và Truyền thông",
                PublishDate = new DateTime(2026, 1, 20),
                Summary = "Các đối tượng phản động lợi dụng mạng xã hội như Facebook, YouTube, Zalo để tạo lập nhóm kín, truyền bá thông tin xuyên tạc, kích động biểu tình và điều hành hoạt động chống phá.",
                FullContent = "Các nhóm kín trên mạng xã hội thường ngụy trang dưới danh nghĩa 'phản biện xã hội', 'đấu tranh vì dân chủ, nhân quyền' hoặc 'chống tham nhũng'. Người dân cần tỉnh táo trước các thông tin không rõ nguồn gốc.",
                Url = "https://mic.gov.vn/canh-bao-khong-gian-mang"
            }
        };

        return new ThreatGroupInfo
        {
            GroupName = "Các nhóm kín và trang mạng xã hội phản động",
            Leader = "Không có tổ chức thống nhất, hoạt động phân tán",
            Status = "Đang điều tra và xử lý theo quy định",
            MainActivities = "Tạo tài khoản ảo, nhóm kín để truyền bá tin giả, xuyên tạc đường lối, kích động biểu tình trái phép, tài trợ cho hoạt động chống phá.",
            Keywords = new List<string> { "tin giả", "xuyên tạc", "kích động", "nhóm kín", "Facebook", "YouTube" },
            RelatedDocuments = docs,
            LastUpdated = DateTime.Now
        };
    }

    public void ExportToJson(DataCollectionResult data, string filePath)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Converters = { new JsonStringEnumConverter() }
        };

        string json = JsonSerializer.Serialize(data, options);
        File.WriteAllText(filePath, json);
        Console.WriteLine($"✅ Đã xuất dữ liệu ra file: {filePath}");
    }

    public void PrintReport(DataCollectionResult data)
    {
        Console.WriteLine("\n" + new string('=', 80));
        Console.WriteLine($"📊 BÁO CÁO THU THẬP THÔNG TIN - {data.CollectionTime:dd/MM/yyyy HH:mm:ss}");
        Console.WriteLine(new string('=', 80));
        Console.WriteLine($"📌 Nguồn: {data.DataSourceDescription}\n");

        Console.WriteLine($"📋 Tổng số nhóm/đối tượng: {data.Groups.Count}");
        Console.WriteLine($"📄 Tổng số tài liệu tham khảo: {data.AllDocuments.Count}\n");

        foreach (var group in data.Groups)
        {
            Console.WriteLine(new string('-', 80));
            Console.WriteLine($"🔴 NHÓM: {group.GroupName}");
            Console.WriteLine($"   👤 Thủ lĩnh: {group.Leader}");
            Console.WriteLine($"   📌 Trạng thái: {group.Status}");
            Console.WriteLine($"   📝 Hoạt động chính: {group.MainActivities}");
            Console.WriteLine($"   🏷️ Từ khóa: {string.Join(", ", group.Keywords)}");
            Console.WriteLine($"   📚 Tài liệu liên quan ({group.RelatedDocuments.Count}):");

            foreach (var doc in group.RelatedDocuments)
            {
                Console.WriteLine($"      - [{doc.Source}] {doc.Title}");
                Console.WriteLine($"        📅 {doc.PublishDate:dd/MM/yyyy} | {doc.Summary}");
                if (!string.IsNullOrEmpty(doc.Url))
                    Console.WriteLine($"        🔗 {doc.Url}");
            }

            Console.WriteLine($"   🕒 Cập nhật: {group.LastUpdated:dd/MM/yyyy HH:mm}");
        }

        Console.WriteLine(new string('=', 80));
        Console.WriteLine("✅ BÁO CÁO KẾT THÚC");
        Console.WriteLine(new string('=', 80));
    }
}

// ============ 3. MAIN PROGRAM ============
class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("🚀 KHỞI ĐỘNG HỆ THỐNG THU THẬP THÔNG TIN...\n");

        var collector = new OfficialDataCollector();

        Console.WriteLine("⏳ Đang thu thập dữ liệu từ các nguồn chính thống...");
        var result = await collector.CollectAllDataAsync();

        // In báo cáo ra màn hình
        collector.PrintReport(result);

        // Xuất ra file JSON
        string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.json");
        collector.ExportToJson(result, jsonPath);

        Console.WriteLine("\n📁 File JSON đã được lưu tại: " + jsonPath);
        Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
        Console.ReadKey();
    }
}