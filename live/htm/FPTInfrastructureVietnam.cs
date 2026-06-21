using System;
using System.Collections.Generic;

namespace FPTInfrastructureVietnam
{
    /// <summary>
    /// FPT Infrastructure in Vietnam - Data compiled as of 2026
    /// FPT Telecom (part of FPT Corporation) is one of Vietnam's largest telecommunications and digital infrastructure providers.
    /// Key areas: Fiber optic network, Data Centers (Fornix), Cloud (FPT Smart Cloud / FPT Cloud), International connectivity.
    /// </summary>
    public class FPTInfrastructureInfo
    {
        public static readonly string Overview = 
            "FPT Telecom cung cấp hạ tầng viễn thông lớn nhất Việt Nam, bao gồm mạng cáp quang phủ sóng rộng, data centers Tier III, " +
            "và FPT Cloud. Là nhà cung cấp data center lớn nhất Việt Nam với 4 data centers tại Hà Nội và TP.HCM.";

        // Data Centers - Fornix Brand
        public static List<DataCenter> DataCenters = new List<DataCenter>
        {
            new DataCenter 
            { 
                Name = "FPT Fornix HN01", 
                Location = "Cau Giay Ward, Hanoi", 
                Details = "One of the operating DCs in Hanoi" 
            },
            new DataCenter 
            { 
                Name = "FPT Fornix HN02", 
                Location = "Cau Giay Ward, Hanoi", 
                Details = "Second DC in Hanoi" 
            },
            new DataCenter 
            { 
                Name = "FPT Fornix HCM01", 
                Location = "Tan Thuan Export Processing Zone, Ho Chi Minh City", 
                Details = "Tier III certified, one of the early modern DCs" 
            },
            new DataCenter 
            { 
                Name = "FPT Fornix HCM02", 
                Location = "Saigon Hi-Tech Park (SHTP), Ho Chi Minh City", 
                Details = "Opened 2025, 10,000 sqm, 3,600 racks, first LEED certified in Vietnam, largest" 
            }
        };

        public static readonly int TotalDataCenters = 4;
        public static readonly int TotalAreaSqm = 17000;
        public static readonly int TotalRacksCapacity = 7000;
        public static readonly string Certifications = "Tier III, ISO 9001, 27001, PCI DSS, LEED (for HCM02)";

        // Network Infrastructure
        public static readonly string NetworkCoverage = "Phủ sóng 61/63 tỉnh thành Việt Nam với hạ tầng cáp quang FTTH/xPON lớn nhất một trong những nhà mạng.";
        public static readonly string InternationalConnectivity = 
            "5 tuyến cáp quang biển lớn + 1 tuyến cáp đất liền xuyên biên giới. Kết nối trực tiếp >100 Gbps đến AWS, GCP, Azure, Oracle, v.v. " +
            "Kết nối với hơn 30 nhà cung cấp cloud quốc tế.";

        // Cloud & AI
        public static readonly string CloudServices = 
            "FPT Smart Cloud / FPT Cloud: Dựa trên OpenStack, multi-region (Vietnam + Japan). " +
            "Hỗ trợ Compute, Storage, Database, AI Factory với GPU clusters (H100, H200). " +
            "Hợp tác VAST Data, NVIDIA, DDN. Largest GPU cluster in Vietnam (up to 16k+ H100).";

        public static readonly string AIPartnerships = 
            "Hợp tác với G42, GS E&C cho AI-ready data centers. Kế hoạch xây thêm AI Factories. " +
            "Hỗ trợ hyperscale AI và cloud cho doanh nghiệp Việt Nam.";

        // Other Services
        public static readonly List<string> Services = new List<string>
        {
            "Internet băng rộng FTTH (tốc độ lên đến 1Gbps+)",
            "Truyền hình FPT Play",
            "Colocation, Dedicated Servers, Managed Services",
            "Leased Line, IP VPN, MPLS",
            "Cloud Computing (Public, Private, Hybrid)",
            "AI Infrastructure & GPU Cloud",
            "WiFi 6/7 deployment for better performance and eSports"
        };

        public static void PrintSummary()
        {
            Console.WriteLine("=== FPT Infrastructure in Vietnam ===");
            Console.WriteLine(Overview);
            Console.WriteLine($"Data Centers: {TotalDataCenters} | Total Area: {TotalAreaSqm} m² | Racks: {TotalRacksCapacity}+");
            Console.WriteLine($"Network: {NetworkCoverage}");
            Console.WriteLine($"Cloud & AI: {CloudServices}");
            Console.WriteLine("Nguồn: Public information from FPT websites, news (2025-2026).");
        }
    }

    public class DataCenter
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FPTInfrastructureInfo.PrintSummary();
            
            // Bạn có thể mở rộng class này để thêm data chi tiết hơn, API calls, hoặc models cho ứng dụng.
            Console.WriteLine("\nFile này chứa tóm tắt kiến thức về hạ tầng FPT tại Việt Nam.");
        }
    }
}