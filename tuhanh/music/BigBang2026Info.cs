using System;
using System.Collections.Generic;

namespace KPopEvents2026
{
    /// <summary>
    /// Lớp chứa thông tin chi tiết về các cột mốc quan trọng của BIGBANG năm 2026.
    /// Dữ liệu được cập nhật tính đến tháng 6/2026.
    /// </summary>
    public class BigBang2026Info
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== BIGBANG 20TH ANNIVERSARY TIMELINE 2026 ===\n");

            // 1. Sự kiện mở màn: Coachella 2026
            Event coachella = new Event
            {
                Name = "Coachella 2026 Reunion",
                Type = "Festival Performance",
                Dates = new List<DateTime> { new DateTime(2026, 4, 12), new DateTime(2026, 4, 19) },
                Location = "Outdoor Theatre, Indio, California, USA",
                Description = "Màn tái hợp lịch sử của bộ ba G-Dragon, Taeyang, Daesung. Trình diễn các hit huyền thoại như 'Fantastic Baby', 'Bang Bang Bang', 'Haru Haru'. Giữ nguyên phần giọng của T.O.P trong ca khúc 'Still Life' dù anh không trực tiếp biểu diễn.",
                Significance = "Nghi thức 'trưởng thành' và mở màn chính thức cho chuỗi hoạt động 20 năm."
            };

            // 2. Hoạt động cá nhân liên quan (T.O.P)
            Event soloComeback = new Event
            {
                Name = "T.O.P Solo Album Release",
                Type = "Album Release",
                Date = new DateTime(2026, 4, 3),
                Title = "Another Dimension (다중관점)",
                Description = "Album phòng thu đầu tiên sau 13 năm của T.O.P, phát hành bởi Topspot Pictures. Đánh dấu sự trở lại của anh trước thềm kỷ niệm nhóm."
            };

            // 3. Công bố World Tour chính thức
            Event tourAnnouncement = new Event
            {
                Name = "BIGBANG 2026 WORLD TOUR Announcement",
                Type = "Press Release",
                Date = new DateTime(2026, 6, 11),
                Organizer = "YG Entertainment",
                Description = "Chính thức công bố lịch trình tour diễn kỷ niệm 20 năm với 31 buổi diễn tại 18 thành phố khắp châu Á, Âu, Mỹ.",
                VietnamHighlight = "Lần đầu tiên Việt Nam (Hà Nội) xuất hiện trong tour diễn quy mô sân vận động của nhóm."
            };

            // 4. Chi tiết lịch trình Việt Nam
            Event vietnamConcert = new Event
            {
                Name = "BIGBANG 2026 WORLD TOUR in Hanoi",
                Type = "Stadium Concert",
                Dates = new List<DateTime> { new DateTime(2026, 10, 24), new DateTime(2026, 10, 25) },
                Location = "Sân vận động Quốc gia Mỹ Đình, Hà Nội",
                Status = "Đã công bố, chưa mở bán vé chính thức",
                Warning = "Cảnh báo lừa đảo: Nhiều tài khoản rao bán vé chui/giữ chỗ với giá 30-75 triệu đồng khi chưa có thông tin chính thức. Người hâm mộ cần tránh chuyển tiền cọc."
            };

            // 5. Lịch trình World Tour chi tiết (Mẫu dữ liệu)
            List<TourDate> worldTourSchedule = GetWorldTourSchedule();

            // Hiển thị thông tin
            PrintEvent(coachella);
            PrintEvent(soloComeback);
            PrintEvent(tourAnnouncement);
            PrintEvent(vietnamConcert);
            
            Console.WriteLine("\n=== WORLD TOUR SCHEDULE SAMPLE ===");
            foreach (var date in worldTourSchedule)
            {
                Console.WriteLine($"{date.Date:dd/MM/yyyy} - {date.City}, {date.Country} @ {date.Venue}");
            }
        }

        private static List<TourDate> GetWorldTourSchedule()
        {
            return new List<TourDate>
            {
                new TourDate { Date = new DateTime(2026, 8, 21), City = "Goyang", Country = "South Korea", Venue = "Goyang Stadium" },
                new TourDate { Date = new DateTime(2026, 8, 22), City = "Goyang", Country = "South Korea", Venue = "Goyang Stadium" },
                new TourDate { Date = new DateTime(2026, 8, 23), City = "Goyang", Country = "South Korea", Venue = "Goyang Stadium" },
                new TourDate { Date = new DateTime(2026, 9, 5), City = "Oakland", Country = "USA", Venue = "Oakland-Alameda County Coliseum" },
                new TourDate { Date = new DateTime(2026, 9, 11), City = "East Rutherford", Country = "USA", Venue = "MetLife Stadium" },
                new TourDate { Date = new DateTime(2026, 9, 19), City = "Paris", Country = "France", Venue = "Stade de France" },
                new TourDate { Date = new DateTime(2026, 9, 26), City = "London", Country = "UK", Venue = "Tottenham Hotspur Stadium" },
                new TourDate { Date = new DateTime(2026, 10, 10), City = "Taipei", Country = "Taiwan", Venue = "Taipei Dome" },
                new TourDate { Date = new DateTime(2026, 10, 17), City = "Singapore", Country = "Singapore", Venue = "National Stadium" },
                new TourDate { Date = new DateTime(2026, 10, 24), City = "Hanoi", Country = "Vietnam", Venue = "My Dinh National Stadium" },
                new TourDate { Date = new DateTime(2026, 10, 25), City = "Hanoi", Country = "Vietnam", Venue = "My Dinh National Stadium" },
                new TourDate { Date = new DateTime(2026, 10, 31), City = "Sydney", Country = "Australia", Venue = "Accor Stadium" },
                new TourDate { Date = new DateTime(2026, 11, 7), City = "Bangkok", Country = "Thailand", Venue = "Rajamangala National Stadium" },
                new TourDate { Date = new DateTime(2026, 11, 13), City = "Hong Kong", Country = "China", Venue = "Kai Tak Stadium" },
                new TourDate { Date = new DateTime(2026, 11, 27), City = "Osaka", Country = "Japan", Venue = "Kyocera Dome Osaka" },
                new TourDate { Date = new DateTime(2026, 12, 13), City = "Tokyo", Country = "Japan", Venue = "Tokyo Dome" }
                // ... Các ngày khác tiếp tục đến tháng 2/2027
            };
        }

        private static void PrintEvent(Event e)
        {
            Console.WriteLine($"[SỰ KIỆN]: {e.Name}");
            if (e.Date != default) Console.WriteLine($"  Ngày: {e.Date:dd/MM/yyyy}");
            if (e.Dates != null && e.Dates.Count > 0)
            {
                Console.Write("  Ngày: ");
                foreach(var d in e.Dates) Console.Write($"{d:dd/MM/yyyy} ");
                Console.WriteLine();
            }
            if (!string.IsNullOrEmpty(e.Location)) Console.WriteLine($"  Địa điểm: {e.Location}");
            if (!string.IsNullOrEmpty(e.Title)) Console.WriteLine($"  Sản phẩm: {e.Title}");
            Console.WriteLine($"  Mô tả: {e.Description}");
            if (!string.IsNullOrEmpty(e.Significance)) Console.WriteLine($"  Ý nghĩa: {e.Significance}");
            if (!string.IsNullOrEmpty(e.Warning)) Console.WriteLine($"  ⚠️ CẢNH BÁO: {e.Warning}");
            Console.WriteLine();
        }
    }

    public class Event
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public List<DateTime> Dates { get; set; }
        public string Location { get; set; }
        public string Title { get; set; } // Dùng cho Album/Single
        public string Description { get; set; }
        public string Significance { get; set; }
        public string Organizer { get; set; }
        public string VietnamHighlight { get; set; }
        public string Warning { get; set; }
    }

    public class TourDate
    {
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Venue { get; set; }
    }
}   