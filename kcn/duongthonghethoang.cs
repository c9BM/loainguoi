using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UrbanInfrastructure.SidewalkManagement
{
    /// <summary>
    /// Định nghĩa các trạng thái thông thoáng của vỉa hè.
    /// </summary>
    public enum ClearanceStatus
    {
        Compliant,      // Đạt chuẩn
        NonCompliant,   // Không đạt chuẩn
        Warning         // Cảnh báo (gần đạt)
    }

    /// <summary>
    /// Mô tả một vật cản trên vỉa hè (cây xanh, biển báo, xe cộ, vật liệu xây dựng...).
    /// </summary>
    public class Obstacle
    {
        public string Id { get; set; }
        public string Type { get; set; } // Ví dụ: "Cây xanh", "Biển báo", "Xe máy"
        
        /// <summary>
        /// Chiều rộng chiếm chỗ của vật cản (mét).
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Khoảng cách từ mép đường đến vật cản (mét).
        /// </summary>
        public double DistanceFromCurb { get; set; }

        public bool IsFixed { get; set; } // true: cố định (cột điện), false: di động (xe cộ)

        public Obstacle(string type, double width, double distance, bool isFixed = false)
        {
            Id = Guid.NewGuid().ToString().Substring(0, 8);
            Type = type;
            Width = width;
            DistanceFromCurb = distance;
            IsFixed = isFixed;
        }
    }

    /// <summary>
    /// Đại diện cho một đoạn vỉa hè cần kiểm tra.
    /// </summary>
    public class SidewalkSegment
    {
        public string SegmentId { get; set; }
        public string StreetName { get; set; }
        
        /// <summary>
        /// Tổng chiều rộng vật lý của vỉa hè (mét).
        /// </summary>
        [Range(0.5, 50.0, ErrorMessage = "Chiều rộng vỉa hè không hợp lệ.")]
        public double TotalWidth { get; set; }

        /// <summary>
        /// Chiều dài đoạn kiểm tra (mét).
        /// </summary>
        public double Length { get; set; }

        public List<Obstacle> Obstacles { get; set; }

        public SidewalkSegment(string streetName, double totalWidth, double length)
        {
            SegmentId = Guid.NewGuid().ToString();
            StreetName = streetName;
            TotalWidth = totalWidth;
            Length = length;
            Obstacles = new List<Obstacle>();
        }

        public void AddObstacle(Obstacle obstacle)
        {
            Obstacles.Add(obstacle);
        }

        /// <summary>
        /// Tính toán chiều rộng thông thủy thực tế còn lại.
        /// Giả định đơn giản: Chiều rộng thông thủy = Tổng rộng - Rộng vật cản lớn nhất chắn ngang.
        /// Trong thực tế có thể phức tạp hơn tùy vị trí vật cản.
        /// </summary>
        public double GetClearWidth()
        {
            if (!Obstacles.Any())
                return TotalWidth;

            // Tìm vật cản chiếm nhiều diện tích ngang nhất trong luồng đi bộ
            // Giả sử luồng đi bộ an toàn cần tránh vật cản hoàn toàn
            var maxObstacleWidth = Obstacles.Max(o => o.Width);
            
            // Nếu vật cản nằm sát mép hoặc sát tường, cách tính có thể khác. 
            // Ở đây ta tính trường hợp xấu nhất: vật cản nằm giữa hoặc chắn ngang.
            return Math.Max(0, TotalWidth - maxObstacleWidth);
        }
    }

    /// <summary>
    /// Bộ kiểm tra quy chuẩn "Đường thông hè thoáng".
    /// </summary>
    public class ClearanceValidator
    {
        // Tiêu chuẩn chiều rộng tối thiểu cho người đi bộ (ví dụ: 1.5m theo QCVN xây dựng VN)
        private const double MinClearWidth = 1.5; 
        private const double WarningThreshold = 1.8;

        /// <summary>
        /// Kiểm tra một đoạn vỉa hè.
        /// </summary>
        public ClearanceStatus Validate(SidewalkSegment segment)
        {
            double clearWidth = segment.GetClearWidth();

            if (clearWidth >= MinClearWidth)
            {
                if (clearWidth < WarningThreshold)
                    return ClearanceStatus.Warning;
                return ClearanceStatus.Compliant;
            }

            return ClearanceStatus.NonCompliant;
        }

        /// <summary>
        /// Tạo báo cáo chi tiết.
        /// </summary>
        public string GenerateReport(SidewalkSegment segment)
        {
            var status = Validate(segment);
            double clearWidth = segment.GetClearWidth();
            
            var report = new System.Text.StringBuilder();
            report.AppendLine($"--- BÁO CÁO HÈ PHỐ: {segment.StreetName} ---");
            report.AppendLine($"ID Đoạn: {segment.SegmentId}");
            report.AppendLine($"Tổng chiều rộng: {segment.TotalWidth}m");
            report.AppendLine($"Chiều rộng thông thủy: {clearWidth:F2}m");
            report.AppendLine($"Số lượng vật cản: {segment.Obstacles.Count}");

            switch (status)
            {
                case ClearanceStatus.Compliant:
                    report.AppendLine("=> KẾT QUẢ: ĐẠT CHUẨN (Thông thoáng)");
                    break;
                case ClearanceStatus.Warning:
                    report.AppendLine($"=> KẾT QUẢ: CẢNH BÁO (Hẹp hơn {WarningThreshold}m nhưng vẫn > {MinClearWidth}m)");
                    break;
                case ClearanceStatus.NonCompliant:
                    report.AppendLine($"=> KẾT QUẢ: KHÔNG ĐẠT (Yêu cầu tối thiểu {MinClearWidth}m)");
                    if (segment.Obstacles.Any())
                    {
                        report.AppendLine("   Vật cản gây hẹp lòng đường:");
                        foreach (var obs in segment.Obstacles.OrderByDescending(o => o.Width).Take(3))
                        {
                            report.AppendLine($"   - {obs.Type} (Rộng: {obs.Width}m, Cố định: {obs.IsFixed})");
                        }
                    }
                    break;
            }
            
            return report.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Khởi tạo bộ kiểm tra
            var validator = new ClearanceValidator();

            // Tạo đoạn vỉa hè mẫu 1: Rộng 4m, có vài vật cản nhỏ
            var segment1 = new SidewalkSegment("Đường Nguyễn Huệ", 4.0, 50.0);
            segment1.AddObstacle(new Obstacle("Cây xanh", 0.8, 1.0, true));
            segment1.AddObstacle(new Obstacle("Biển báo", 0.2, 0.5, true));

            // Tạo đoạn vỉa hè mẫu 2: Rộng 3m, bị xe máy lấn chiếm
            var segment2 = new SidewalkSegment("Đường Lê Lợi", 3.0, 20.0);
            segment2.AddObstacle(new Obstacle("Dãy xe máy", 2.0, 0.5, false)); // Xe máy chiếm 2m

            // Tạo đoạn vỉa hè mẫu 3: Rất hẹp
            var segment3 = new SidewalkSegment("Hẻm nhỏ", 1.2, 10.0);

            // Thực hiện kiểm tra và in báo cáo
            Console.WriteLine(validator.GenerateReport(segment1));
            Console.WriteLine("\n" + new string('-', 30) + "\n");
            Console.WriteLine(validator.GenerateReport(segment2));
            Console.WriteLine("\n" + new string('-', 30) + "\n");
            Console.WriteLine(validator.GenerateReport(segment3));

            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}