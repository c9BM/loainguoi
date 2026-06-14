using System;
using System.Collections.Generic;
using System.Text;

namespace DichVuLuuTruKCN
{
    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("==============================================");
            Console.WriteLine(" HỆ THỐNG THÔNG TIN DỊCH VỤ LƯU TRÚ KHU CÔNG NGHIỆP ");
            Console.WriteLine("==============================================\n");

            List<string> dichVu = new List<string>()
            {
                "Nhà trọ công nhân",
                "Ký túc xá doanh nghiệp",
                "Nhà nghỉ bình dân",
                "Khách sạn",
                "Căn hộ dịch vụ",
                "Bãi giữ xe",
                "Giặt là",
                "Căng tin",
                "Dịch vụ đưa đón",
                "Internet tốc độ cao",
                "Bảo vệ 24/7",
                "Camera an ninh",
                "Siêu thị mini",
                "Hiệu thuốc",
                "Khu sinh hoạt cộng đồng"
            };

            Console.WriteLine("DANH SÁCH DỊCH VỤ HIỆN CÓ:\n");

            for (int i = 0; i < dichVu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dichVu[i]}");
            }

            Console.WriteLine("\n----------------------------------------------");

            decimal giaNhaTro = 1800000;
            decimal giaKyTucXa = 1200000;
            decimal giaNhaNghi = 250000;
            decimal giaKhachSan = 550000;
            decimal giaCanHo = 6500000;

            Console.WriteLine("\nBẢNG CHI PHÍ THAM KHẢO");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"Nhà trọ công nhân : {giaNhaTro:N0} VNĐ/tháng");
            Console.WriteLine($"Ký túc xá         : {giaKyTucXa:N0} VNĐ/tháng");
            Console.WriteLine($"Nhà nghỉ          : {giaNhaNghi:N0} VNĐ/đêm");
            Console.WriteLine($"Khách sạn         : {giaKhachSan:N0} VNĐ/đêm");
            Console.WriteLine($"Căn hộ dịch vụ    : {giaCanHo:N0} VNĐ/tháng");

            Console.WriteLine("\n----------------------------------------------");
            Console.WriteLine("LỢI ÍCH CỦA DỊCH VỤ LƯU TRÚ");
            Console.WriteLine("----------------------------------------------");

            string[] loiIch =
            {
                "Tiết kiệm thời gian di chuyển.",
                "Dễ dàng đi làm theo ca.",
                "Tiếp cận các tiện ích thiết yếu.",
                "Được hỗ trợ an ninh và quản lý.",
                "Tạo môi trường sinh hoạt cộng đồng.",
                "Thuận tiện cho lao động ngoại tỉnh."
            };

            foreach (string item in loiIch)
            {
                Console.WriteLine("- " + item);
            }

            Console.WriteLine("\n----------------------------------------------");
            Console.WriteLine("THÔNG TIN KHÁCH ĐĂNG KÝ");
            Console.WriteLine("----------------------------------------------");

            Console.Write("Họ và tên: ");
            string hoTen = Console.ReadLine();

            Console.Write("Đơn vị làm việc: ");
            string congTy = Console.ReadLine();

            Console.Write("Nhu cầu lưu trú (tháng hoặc đêm): ");
            string nhuCau = Console.ReadLine();

            Console.WriteLine("\n========== PHIẾU ĐĂNG KÝ ==========");
            Console.WriteLine($"Khách hàng : {hoTen}");
            Console.WriteLine($"Công ty    : {congTy}");
            Console.WriteLine($"Nhu cầu    : {nhuCau}");
            Console.WriteLine("Trạng thái : Chờ xác nhận");
            Console.WriteLine("===================================");

            Console.WriteLine("\nMỘT SỐ TIỆN ÍCH PHỔ BIẾN GẦN KCN:");
            Console.WriteLine("- Chợ dân sinh.");
            Console.WriteLine("- Siêu thị.");
            Console.WriteLine("- Trạm y tế.");
            Console.WriteLine("- ATM và ngân hàng.");
            Console.WriteLine("- Bến xe.");
            Console.WriteLine("- Quán ăn và cà phê.");

            Console.WriteLine("\nChương trình kết thúc.");
            Console.ReadKey();
        }
    }
}