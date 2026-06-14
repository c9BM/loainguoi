using System;

namespace ChiPhiQuaDemKCN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=======================================");
            Console.WriteLine("   TÍNH CHI PHÍ QUA ĐÊM TẠI KCN");
            Console.WriteLine("=======================================\n");

            Console.Write("Tên người lưu trú: ");
            string ten = Console.ReadLine();

            Console.Write("Số đêm lưu trú: ");
            int soDem = int.Parse(Console.ReadLine());

            Console.WriteLine("\nLoại hình lưu trú:");
            Console.WriteLine("1. Nhà trọ công nhân");
            Console.WriteLine("2. Nhà nghỉ");
            Console.WriteLine("3. Khách sạn bình dân");
            Console.WriteLine("4. Căn hộ dịch vụ");
            Console.Write("\nLựa chọn: ");

            int luaChon = int.Parse(Console.ReadLine());

            decimal giaMotDem = 0;

            switch (luaChon)
            {
                case 1:
                    giaMotDem = 120000;
                    break;
                case 2:
                    giaMotDem = 250000;
                    break;
                case 3:
                    giaMotDem = 500000;
                    break;
                case 4:
                    giaMotDem = 800000;
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    return;
            }

            decimal tongTien = giaMotDem * soDem;

            Console.WriteLine("\n========== HÓA ĐƠN ==========");
            Console.WriteLine($"Khách lưu trú : {ten}");
            Console.WriteLine($"Số đêm        : {soDem}");
            Console.WriteLine($"Đơn giá       : {giaMotDem:N0} VNĐ/đêm");
            Console.WriteLine($"Tổng tiền     : {tongTien:N0} VNĐ");
            Console.WriteLine("=============================");

            Console.WriteLine("\nCác khoản có thể phát sinh:");
            Console.WriteLine("- Giặt là.");
            Console.WriteLine("- Điện, nước.");
            Console.WriteLine("- Gửi xe.");
            Console.WriteLine("- Ăn uống.");
            Console.WriteLine("- Dịch vụ khác.");

            Console.WriteLine("\nNhấn phím bất kỳ để kết thúc...");
            Console.ReadKey();
        }
    }
}