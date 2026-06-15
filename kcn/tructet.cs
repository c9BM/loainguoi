using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndustrialZoneSecurity
{
    /// <summary>
    /// Định nghĩa các loại ca trực.
    /// </summary>
    public enum ShiftType
    {
        Morning,    // 06:00 - 14:00
        Afternoon,  // 14:00 - 22:00
        Night       // 22:00 - 06:00 (hôm sau)
    }

    /// <summary>
    /// Thông tin nhân viên bảo vệ.
    /// </summary>
    public class Guard
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Team { get; set; } // Đội 1, Đội 2...
        public double DailySalary { get; set; } // Lương ngày thường

        public Guard(string id, string name, string team, double salary)
        {
            Id = id;
            FullName = name;
            Team = team;
            DailySalary = salary;
        }
    }

    /// <summary>
    /// Chi tiết một ca trực trong lịch.
    /// </summary>
    public class ShiftAssignment
    {
        public DateTime Date { get; set; }
        public ShiftType Shift { get; set; }
        public Guard Guard { get; set; }
        public string Position { get; set; } // Cổng chính, Tuần tra, Kho...
        public bool IsHoliday { get; set; } // Có phải ngày lễ/tết không

        /// <summary>
        /// Tính lương cho ca trực này.
        /// Quy tắc: Ngày lễ hưởng 400% (100% lương ngày lễ + 300% làm thêm).
        /// Ca đêm hưởng thêm 30%.
        /// </summary>
        public double CalculateShiftSalary()
        {
            double baseRate = Guard.DailySalary / 3; // Giả sử 1 ngày 3 ca, mỗi ca 1/3 lương ngày
            double multiplier = IsHoliday ? 4.0 : 1.0; // Ngày Tết: 400%, Ngày thường: 100%
            
            // Phụ cấp ca đêm (22h-6h)
            if (Shift == ShiftType.Night)
            {
                // Nếu là ngày lễ: 400% + 30% của lương cơ bản ngày thường
                // Nếu là ngày thường: 100% + 30%
                baseRate += (Guard.DailySalary / 3) * 0.3; 
            }

            // Lưu ý: Cách tính chi tiết có thể thay đổi tùy chính sách công ty
            // Ở đây tính đơn giản: Lương ca = (Lương ngày / 3) * Hệ số ngày lễ
            return (Guard.DailySalary / 3) * (IsHoliday ? 4.0 : 1.0) + (Shift == ShiftType.Night ? Guard.DailySalary * 0.1 : 0);
        }
    }

    /// <summary>
    /// Bộ quản lý lịch trực Tết.
    /// </summary>
    public class TetScheduleManager
    {
        public List<Guard> Guards { get; set; }
        public List<ShiftAssignment> Schedule { get; set; }
        
        // Dự kiến lịch nghỉ Tết 2027 (Âm lịch: 29 Tết đến Mùng 5)
        // Dương lịch: 05/02/2027 (Thứ 6) đến 11/02/2027 (Thứ 5)
        private readonly List<DateTime> _tetHolidays2027 = new List<DateTime>
        {
            new DateTime(2027, 2, 5), // 29 Tết
            new DateTime(2027, 2, 6), // 30 Tết
            new DateTime(2027, 2, 7), // Mùng 1
            new DateTime(2027, 2, 8), // Mùng 2
            new DateTime(2027, 2, 9), // Mùng 3
            new DateTime(2027, 2, 10),// Mùng 4
            new DateTime(2027, 2, 11) // Mùng 5
        };

        public TetScheduleManager()
        {
            Guards = new List<Guard>();
            Schedule = new List<ShiftAssignment>();
        }

        public void AddGuard(Guard guard)
        {
            Guards.Add(guard);
        }

        /// <summary>
        /// Tự động xếp lịch trực cho khu công nghiệp trong dịp Tết.
        /// Phương pháp: Luân phiên ca đều giữa các đội.
        /// </summary>
        public void GenerateTetSchedule(DateTime startDate, DateTime endDate)
        {
            Schedule.Clear();
            int guardIndex = 0;
            string[] positions = { "Cổng Chính", "Tuần Tra Khu A", "Tuần Tra Khu B", "Phòng Monitor" };

            DateTime currentDay = startDate;
            while (currentDay <= endDate)
            {
                bool isHoliday = _tetHolidays2027.Contains(currentDay.Date);

                foreach (var shift in Enum.GetValues(typeof(ShiftType)))
                {
                    ShiftType currentShift = (ShiftType)shift;
                    
                    // Phân công 4 vị trí cho 4 nhân viên khác nhau (hoặc luân phiên)
                    foreach (var pos in positions)
                    {
                        if (guardIndex >= Guards.Count)
                            guardIndex = 0; // Quay vòng lại danh sách bảo vệ

                        var assignment = new ShiftAssignment
                        {
                            Date = currentDay,
                            Shift = currentShift,
                            Guard = Guards[guardIndex],
                            Position = pos,
                            IsHoliday = isHoliday
                        };

                        Schedule.Add(assignment);
                        guardIndex++;
                    }
                }
                currentDay = currentDay.AddDays(1);
            }
        }

        /// <summary>
        /// Xuất báo cáo lịch trực và dự toán lương.
        /// </summary>
        public string ExportReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine("==========================================================");
            sb.AppendLine("       LỊCH TRỰC TẾT NGUYÊN ĐÁN 2027 - KCN BÌNH DƯƠNG      ");
            sb.AppendLine("==========================================================");
            sb.AppendLine($"Thời gian: 05/02/2027 - 11/02/2027 (29 Tết - Mùng 5)");
            sb.AppendLine($"Tổng nhân sự: {Guards.Count} | Tổng ca trực: {Schedule.Count}");
            sb.AppendLine("----------------------------------------------------------\n");

            // Nhóm lịch theo ngày
            var groupedByDate = Schedule.OrderBy(s => s.Date).ThenBy(s => s.Shift).GroupBy(s => s.Date);

            foreach (var dayGroup in groupedByDate)
            {
                string dateStr = dayGroup.Key.ToString("dd/MM/yyyy");
                string holidayLabel = _tetHolidays2027.Contains(dayGroup.Key) ? "[NGÀY TẾT]" : "[Ngày thường]";
                
                sb.AppendLine($"NGÀY: {dateStr} {holidayLabel}");
                sb.AppendLine($"{"Ca", -10} {"Giờ", -15} {"Nhân viên", -20} {"Vị trí", -20} {"Lương dự kiến"}");
                
                foreach (var shift in dayGroup.OrderBy(s => s.Shift))
                {
                    string timeRange = shift.Shift switch
                    {
                        ShiftType.Morning => "06:00 - 14:00",
                        ShiftType.Afternoon => "14:00 - 22:00",
                        ShiftType.Night => "22:00 - 06:00",
                        _ => ""
                    };

                    sb.AppendLine($"{shift.Shift, -10} {timeRange, -15} {shift.Guard.FullName, -20} {shift.Position, -20} {shift.CalculateShiftSalary(), -15:C}");
                }
                sb.AppendLine("----------------------------------------------------------");
            }

            // Tổng hợp lương
            double totalBudget = Schedule.Sum(s => s.CalculateShiftSalary());
            sb.AppendLine($"\n>>> TỔNG DỰ TOÁN LƯƠNG TẾT: {totalBudget:C}");
            sb.AppendLine(">>> LƯU Ý: Nhân viên trực Tết được nghỉ bù sau lễ theo quy định.");
            
            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var manager = new TetScheduleManager();

            // 1. Khai báo nhân sự (Ví dụ 4 bảo vệ cho 1 tổ)
            manager.AddGuard(new Guard("G001", "Nguyễn Văn A", "Đội 1", 600000)); // 600k/ngày
            manager.AddGuard(new Guard("G002", "Trần Văn B", "Đội 1", 600000));
            manager.AddGuard(new Guard("G003", "Lê Văn C", "Đội 2", 650000));
            manager.AddGuard(new Guard("G004", "Phạm Văn D", "Đội 2", 650000));

            // 2. Sinh lịch trực Tết 2027
            DateTime startDate = new DateTime(2027, 2, 5); // 29 Tết
            DateTime endDate = new DateTime(2027, 2, 11);   // Mùng 5 Tết

            manager.GenerateTetSchedule(startDate, endDate);

            // 3. Xuất báo cáo
            Console.WriteLine(manager.ExportReport());

            Console.WriteLine("\nĐã xuất lịch thành công. Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}