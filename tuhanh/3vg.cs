using System;
using System.Text;

namespace BaVangTuHoc
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("==================================");
            Console.WriteLine("     TÌM HIỂU TU HỌC BA VÀNG");
            Console.WriteLine("==================================\n");

            Console.WriteLine("Mục tiêu:");
            Console.WriteLine("- Rèn luyện đạo đức.");
            Console.WriteLine("- Học giáo lý Phật giáo.");
            Console.WriteLine("- Nuôi dưỡng tâm từ bi.");
            Console.WriteLine("- Hướng tới đời sống an lạc.\n");

            Console.WriteLine("Các hoạt động thường gặp:");
            Console.WriteLine("1. Nghe pháp thoại.");
            Console.WriteLine("2. Tụng kinh.");
            Console.WriteLine("3. Thiền định.");
            Console.WriteLine("4. Công quả.");
            Console.WriteLine("5. Tham gia khóa tu.");
            Console.WriteLine("6. Hoạt động thiện nguyện.\n");

            int congDuc = 0;

            Console.WriteLine("Đạo hữu tham gia một ngày tu học...\n");

            congDuc += 10;
            Console.WriteLine("✓ Dậy sớm công phu sáng (+10)");

            congDuc += 15;
            Console.WriteLine("✓ Nghe pháp thoại (+15)");

            congDuc += 20;
            Console.WriteLine("✓ Công quả giúp đại chúng (+20)");

            congDuc += 15;
            Console.WriteLine("✓ Thiền định (+15)");

            Console.WriteLine($"\nTổng điểm tinh tấn: {congDuc}");

            if (congDuc >= 50)
            {
                Console.WriteLine("Kết quả: Một ngày tu học viên mãn.");
            }
            else
            {
                Console.WriteLine("Kết quả: Tiếp tục tinh tấn hơn nữa.");
            }

            Console.WriteLine("\nNam Mô Bổn Sư Thích Ca Mâu Ni Phật.");
        }
    }
}