using System;
using System.Collections.Generic;

namespace TINInfrastructureVietnam
{
    /// <summary>
    /// Thông tin về Công ty TNHH Hạ tầng Viễn thông Miền Bắc (TIN)
    /// Đối tác độc quyền triển khai & bảo trì của FPT Telecom tại Miền Bắc & Miền Trung
    /// </summary>
    public class TINInfrastructureInfo
    {
        public static readonly string CompanyName = "Công ty TNHH Hạ tầng Viễn thông Miền Bắc (TIN)";
        public static readonly string FullName = "Telecom Infrastructure North Co., Ltd";
        public static readonly string MST = "0104547936";
        public static readonly DateTime FoundedDate = new DateTime(2010, 4, 1);
        public static readonly string Address = "Tầng 3 - Tòa nhà Detech II, 107 Nguyễn Phong Sắc, Phường Cầu Giấy, Hà Nội";

        public static readonly string Overview = 
            "TIN là đối tác độc quyền của FPT Telecom trong lĩnh vực triển khai, thi công và bảo trì hạ tầng viễn thông " +
            "tại khu vực Miền Bắc và Miền Trung Việt Nam. Chuyên trách hạ tầng fiber optic, FTTH, mạng băng rộng.";

        // Hạ tầng & Dịch vụ chính
        public static List<string> MainServices = new List<string>
        {
            "Triển khai hạ tầng cáp quang FTTH / xPON",
            "Thi công và lắp đặt mạng viễn thông (Fiber Optic, Leased Line)",
            "Bảo trì và vận hành hệ thống hạ tầng FPT Telecom",
            "Dịch vụ không dây (Wireless services)",
            "Xây dựng giải pháp hạ tầng viễn thông cho doanh nghiệp và hộ gia đình",
            "Hỗ trợ mở rộng phủ sóng mạng internet băng rộng"
        };

        public static readonly string Scale = "1.001 - 5.000 nhân viên (dữ liệu tham khảo)";
        public static readonly string Partnership = "Đối tác độc quyền FPT Telecom (Miền Bắc & Miền Trung)";
        public static readonly string FocusAreas = "Triển khai hạ tầng viễn thông, bảo trì mạng, thi công fiber optic";

        public static void PrintSummary()
        {
            Console.WriteLine("=== Công ty TNHH Hạ tầng Viễn thông Miền Bắc (TIN) ===");
            Console.WriteLine(Overview);
            Console.WriteLine($"Thành lập: {FoundedDate:dd/MM/yyyy} | MST: {MST}");
            Console.WriteLine($"Trụ sở: {Address}");
            Console.WriteLine($"Đối tác: {Partnership}");
            Console.WriteLine("\nDịch vụ chính:");
            foreach (var service in MainServices)
            {
                Console.WriteLine($"- {service}");
            }
            Console.WriteLine("\nTIN tập trung vào thi công & duy trì hạ tầng fiber của FPT Telecom.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TINInfrastructureInfo.PrintSummary();
            
            Console.WriteLine("\nLưu ý: TIN là công ty chuyên thi công hạ tầng (không phải nhà cung cấp dịch vụ trực tiếp cho khách hàng cuối).");
            Console.WriteLine("Thông tin dựa trên dữ liệu công khai (LinkedIn, TopCV, Masothue, v.v.).");
        }
    }
}