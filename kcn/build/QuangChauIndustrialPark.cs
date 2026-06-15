using System;
using System.Collections.Generic;

namespace IndustrialParkData
{
    // Định nghĩa cấu trúc dữ liệu cho một phân khu công nghiệp
    public class IndustrialZone
    {
        public string Name { get; set; }
        public string Scale { get; set; }
        public string ConstructionDensity { get; set; }
        public string CompletionStatus { get; set; }
        public string OccupancyRate { get; set; }
        public string KeyInvestors { get; set; }
        public string Notes { get; set; }
    }

    public class QuangChauData
    {
        public static List<IndustrialZone> GetQuangChauInfo()
        {
            return new List<IndustrialZone>
            {
                new IndustrialZone
                {
                    Name = "KCN Quang Châu (Hiện hữu)",
                    Scale = "426 ha",
                    ConstructionDensity = "Nhà máy, nhà xưởng: tối đa 60% - 70%",
                    CompletionStatus = "Đã hoàn thành xây dựng hạ tầng hoàn toàn",
                    OccupancyRate = "100% (Đã lấp đầy hoàn toàn)",
                    KeyInvestors = "Foxconn, Luxshare-ICT",
                    Notes = "Các tập đoàn lớn đang vận hành nhà xưởng ổn định."
                },
                new IndustrialZone
                {
                    Name = "KCN Quang Châu Mở rộng",
                    Scale = "90,59 ha",
                    ConstructionDensity = "Nhà máy, nhà xưởng: tối đa 60% - 70%",
                    CompletionStatus = "Hạ tầng cốt lõi cơ bản hoàn thiện cuốn chiếu để bàn giao",
                    OccupancyRate = "Dự kiến lấp đầy hoàn toàn trong năm 2026 hoặc đầu năm 2027",
                    KeyInvestors = "Chủ yếu phục vụ tăng quy mô của Foxconn",
                    Notes = "Tốc độ lấp đầy rất nhanh, gần như không còn quỹ đất trống cho nhà đầu tư mới."
                },
                new IndustrialZone
                {
                    Name = "KCN Quang Châu 2 (Dự án mới)",
                    Scale = "125,12 ha",
                    ConstructionDensity = "- Đất công nghiệp: tối đa 70% (cao tối đa 5 tầng)\n" +
                                          "- Khu dịch vụ, tiện ích công cộng: 40% - 50% (cao 9 - 18 tầng)\n" +
                                          "- Hạ tầng kỹ thuật: tối đa 60%",
                    CompletionStatus = "Dự kiến đưa vào khai thác, vận hành chính thức vào Quý IV/2027",
                    OccupancyRate = "Dự kiến lấp đầy trên 90% vào khoảng năm 2029 - 2030",
                    KeyInvestors = "Đang thu hút các doanh nghiệp vệ tinh ngành điện tử",
                    Notes = "Kế hoạch dựa trên quy hoạch chi tiết 1/500 điều chỉnh mới nhất."
                }
            };
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<IndustrialZone> zones = GetQuangChauInfo();

            Console.WriteLine("=== THÔNG TIN KCN QUANG CHÂU (BẮC GIANG) ===\n");
            foreach (var zone in zones)
            {
                Console.WriteLine($"[Tên phân khu]: {zone.Name}");
                Console.WriteLine($" - Quy mô: {zone.Scale}");
                Console.WriteLine($" - Mật độ xây dựng: \n{zone.ConstructionDensity}");
                Console.WriteLine($" - Tiến độ xây dựng: {zone.CompletionStatus}");
                Console.WriteLine($" - Tỷ lệ lấp đầy: {zone.OccupancyRate}");
                Console.WriteLine($" - Nhà đầu tư tiêu biểu: {zone.KeyInvestors}");
                Console.WriteLine($" - Ghi chú: {zone.Notes}");
                Console.WriteLine(new string('-', 50));
            }
        }
    }
}
