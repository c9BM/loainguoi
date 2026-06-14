using System;
using System.Collections.Generic;

namespace IndustrialParkRelationships
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== CÁC MỐI QUAN HỆ PHI CHÍNH THỨC TRONG MÔI TRƯỜNG LÀM VIỆC ===\n");

            List<string> relationships = new List<string>
            {
                "Bạn bè cùng chuyền sản xuất",
                "Bạn cùng ca làm việc",
                "Đồng hương hỗ trợ nhau",
                "Nhóm cùng thuê trọ",
                "Quan hệ mentor - người mới",
                "Tình bạn ngoài công việc",
                "Tình cảm yêu đương giữa đồng nghiệp",
                "Mối quan hệ đã có gia đình nhưng phát sinh tình cảm bên ngoài",
                "Mối quan hệ trên mạng xã hội phát triển từ công việc",
                "Các nhóm sở thích chung (thể thao, game, âm nhạc)"
            };

            foreach (var relation in relationships)
            {
                Console.WriteLine("- " + relation);
            }

            Console.WriteLine("\n=== NHẬN XÉT ===");
            Console.WriteLine("Không phải mọi mối quan hệ đều tiêu cực.");
            Console.WriteLine("Nhiều mối quan hệ giúp hỗ trợ tinh thần và công việc.");
            Console.WriteLine("Tuy nhiên các mối quan hệ vi phạm cam kết gia đình hoặc quy định công ty");
            Console.WriteLine("có thể dẫn đến mâu thuẫn cá nhân, ảnh hưởng hiệu suất làm việc");
            Console.WriteLine("và tác động tới tập thể.");

            Console.WriteLine("\n=== KHUYẾN NGHỊ ===");
            Console.WriteLine("• Tôn trọng đồng nghiệp.");
            Console.WriteLine("• Giữ ranh giới nghề nghiệp phù hợp.");
            Console.WriteLine("• Tuân thủ nội quy doanh nghiệp.");
            Console.WriteLine("• Giải quyết mâu thuẫn bằng đối thoại.");
            Console.WriteLine("• Bảo vệ quyền riêng tư của mọi người.");

            Console.WriteLine("\nKết thúc chương trình.");
        }
    }
}