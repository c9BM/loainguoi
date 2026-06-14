using System;
using System.Collections.Generic;

namespace BaoVeStory
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("NHỮNG MỐI QUAN HỆ KHÔNG TÊN CỦA NGƯỜI BẢO VỆ");
            Console.WriteLine("------------------------------------------\n");

            List<string> stories = new List<string>()
            {
                "Người công nhân luôn chào hỏi mỗi ca sáng.",
                "Bác tài xe tải ghé cổng mỗi tuần vài lần.",
                "Cô lao công trực đêm cùng khung giờ.",
                "Người bán nước trước cổng khu công nghiệp.",
                "Nhân viên văn phòng hay quên thẻ ra vào.",
                "Đồng nghiệp đổi ca khi có việc gia đình.",
                "Người khách lạ chỉ gặp một lần rồi không quay lại.",
                "Chú bảo trì quen mặt nhưng không biết tên.",
                "Ca trưởng của đội sản xuất thường ghé hỏi tình hình.",
                "Những người đi ngang cổng mỗi ngày."
            };

            foreach (string story in stories)
            {
                Console.WriteLine("• " + story);
            }

            Console.WriteLine("\nSUY NGẪM");
            Console.WriteLine("Người bảo vệ thường biết rất nhiều khuôn mặt.");
            Console.WriteLine("Biết giờ giấc, thói quen và nhịp sống của họ.");
            Console.WriteLine("Nhưng đôi khi lại không biết tên thật.");
            Console.WriteLine("Đó là những mối quan hệ không tên,");
            Console.WriteLine("chỉ tồn tại qua những cái gật đầu,");
            Console.WriteLine("lời chào buổi sáng và những ca trực dài.");

            Console.WriteLine("\nKết thúc ca trực.");
        }
    }
}