using System;

namespace GreatestMidfielderStory
{
    // Lớp mô tả một Cầu thủ
    public class FootballPlayer
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Legacy { get; set; }

        public FootballPlayer(string name, string position, string legacy)
        {
            Name = name;
            Position = position;
            Legacy = legacy;
        }

        public void DisplayStory()
        {
            Console.WriteLine($"--- CÂU CHUYỆN VỀ HUYỀN THOẠI ---\n");
            Console.WriteLine($"Tiền vệ: {Name}");
            Console.WriteLine($"Vị trí: {Position}\n");
            Console.WriteLine($"Cốt truyện vĩ đại: {Legacy}\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Khởi tạo câu chuyện về Tiền vệ vĩ đại nhất
            FootballPlayer greatestMidfielder = new FootballPlayer(
                name: "Zinedine Zidane",
                position: "Tiền vệ tấn công (Playmaker)",
                legacy: "Được mệnh danh là 'Zizou', ông được nhiều người xem là tiền vệ vĩ đại nhất thế giới nhờ kỹ thuật siêu hạng, tầm nhìn bao quát, khả năng kiểm soát bóng hoàn hảo và bản lĩnh tỏa sáng trong các trận cầu lớn. Từ cú volley lịch sử tại chung kết Champions League đến việc làm chủ khu trung tuyến giúp đội tuyển Pháp vô địch World Cup và Euro, di sản của ông là sự kết hợp hoàn hảo giữa nghệ thuật và hiệu quả."
            );

            // Kể lại câu chuyện
            greatestMidfielder.DisplayStory();

            Console.WriteLine("Bạn có muốn tìm hiểu thêm về cách code này, hoặc tham khảo thêm những bài tập lập trình khác?");
        }
    }
}
