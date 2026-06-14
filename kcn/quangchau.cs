using System;
using System.Collections.Generic;

namespace BaoCaoKCNQuangChau
{
    class DoiMoi
    {
        public string Ten { get; set; }
        public string MoTa { get; set; }

        public void HienThi()
        {
            Console.WriteLine($"Tên đổi mới : {Ten}");
            Console.WriteLine($"Mô tả       : {MoTa}");
            Console.WriteLine("------------------------------------------");
        }
    }

    class BaoCaoKCN
    {
        public string TenKCN { get; set; }
        public string DiaDiem { get; set; }

        public void HienThiThongTin()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("BÁO CÁO KHU CÔNG NGHIỆP QUANG CHÂU");
            Console.WriteLine("========================================");
            Console.WriteLine($"Tên KCN : {TenKCN}");
            Console.WriteLine($"Địa điểm: {DiaDiem}");
            Console.WriteLine();
        }
    }

    class ChuongTrinh
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            BaoCaoKCN baoCao = new BaoCaoKCN
            {
                TenKCN = "Quang Châu",
                DiaDiem = "Thị xã Việt Yên, Bắc Giang"
            };

            baoCao.HienThiThongTin();

            List<DoiMoi> danhSachDoiMoi = new List<DoiMoi>
            {
                new DoiMoi
                {
                    Ten = "Mở rộng khu công nghiệp",
                    MoTa = "Tăng diện tích để thu hút thêm các dự án sản xuất công nghệ cao."
                },

                new DoiMoi
                {
                    Ten = "Hạ tầng kỹ thuật hiện đại",
                    MoTa = "Đầu tư hệ thống điện, nước, viễn thông và xử lý nước thải đồng bộ."
                },

                new DoiMoi
                {
                    Ten = "Nhà máy thông minh",
                    MoTa = "Ứng dụng robot công nghiệp và tự động hóa trong sản xuất."
                },

                new DoiMoi
                {
                    Ten = "Chuyển đổi số",
                    MoTa = "Sử dụng phần mềm ERP, MES và quản lý dữ liệu thời gian thực."
                },

                new DoiMoi
                {
                    Ten = "Kho vận thông minh",
                    MoTa = "Ứng dụng xe tự hành AGV và hệ thống quản lý kho tự động."
                },

                new DoiMoi
                {
                    Ten = "Tiết kiệm năng lượng",
                    MoTa = "Áp dụng công nghệ xanh và tối ưu hóa tiêu thụ điện năng."
                },

                new DoiMoi
                {
                    Ten = "An toàn lao động",
                    MoTa = "Tăng cường giám sát bằng cảm biến và hệ thống cảnh báo tự động."
                },

                new DoiMoi
                {
                    Ten = "Thu hút doanh nghiệp điện tử",
                    MoTa = "Ưu tiên các dự án sản xuất linh kiện điện tử và công nghệ cao."
                }
            };

            Console.WriteLine("CÁC ĐIỂM ĐỔI MỚI NỔI BẬT");
            Console.WriteLine();

            foreach (var doiMoi in danhSachDoiMoi)
            {
                doiMoi.HienThi();
            }

            Console.WriteLine();
            Console.WriteLine("ĐỊNH HƯỚNG PHÁT TRIỂN");

            string[] dinhHuong =
            {
                "Phát triển khu công nghiệp thông minh",
                "Tăng tỷ lệ tự động hóa sản xuất",
                "Thu hút doanh nghiệp công nghệ cao",
                "Đẩy mạnh chuyển đổi số",
                "Phát triển công nghiệp xanh",
                "Nâng cao chất lượng nguồn nhân lực",
                "Tăng năng lực logistics",
                "Mở rộng hệ sinh thái công nghiệp phụ trợ"
            };

            foreach (string mucTieu in dinhHuong)
            {
                Console.WriteLine("• " + mucTieu);
            }

            Console.WriteLine();
            Console.WriteLine("Kết thúc báo cáo.");
            Console.ReadKey();
        }
    }
}