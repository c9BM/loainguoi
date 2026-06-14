using System;

namespace TraThemTienKCN
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=================================");
            Console.WriteLine(" CHÍNH SÁCH TRẢ THÊM TIỀN ");
            Console.WriteLine("=================================\n");

            decimal luongCoBan = 8000000;
            decimal phuCap = 1000000;
            decimal thuong = 1500000;
            decimal tangCa = 2000000;

            decimal tongThuNhap = luongCoBan + phuCap + thuong + tangCa;

            Console.WriteLine($"Lương cơ bản : {luongCoBan:N0} VNĐ");
            Console.WriteLine($"Phụ cấp      : {phuCap:N0} VNĐ");
            Console.WriteLine($"Thưởng       : {thuong:N0} VNĐ");
            Console.WriteLine($"Tiền tăng ca : {tangCa:N0} VNĐ");

            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Tổng thu nhập: {tongThuNhap:N0} VNĐ");
            Console.WriteLine("---------------------------------\n");

            Console.WriteLine("Các khoản trả thêm có thể gồm:");
            Console.WriteLine("- Thưởng chuyên cần.");
            Console.WriteLine("- Thưởng năng suất.");
            Console.WriteLine("- Phụ cấp đi lại.");
            Console.WriteLine("- Phụ cấp nhà ở.");
            Console.WriteLine("- Tiền làm thêm giờ.");
            Console.WriteLine("- Thưởng lễ, tết.");
            Console.WriteLine("- Thưởng sáng kiến cải tiến.");

            Console.WriteLine("\nNhấn phím bất kỳ để kết thúc...");
            Console.ReadKey();
        }
    }
}