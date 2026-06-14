using System;
using System.Collections.Generic;

namespace VietnamManufacturing2026
{
    class Company
    {
        public string Name { get; set; }
        public string Industry { get; set; }
        public int Employees { get; set; }
        public string Status { get; set; }

        public void Display()
        {
            Console.WriteLine($"Tên công ty : {Name}");
            Console.WriteLine($"Ngành nghề  : {Industry}");
            Console.WriteLine($"Nhân sự     : {Employees}");
            Console.WriteLine($"Tình hình   : {Status}");
            Console.WriteLine("--------------------------------");
        }
    }

    class IndustryReport
    {
        public static void ShowNationalOverview()
        {
            Console.WriteLine("=== BÁO CÁO DOANH NGHIỆP SẢN XUẤT VIỆT NAM 2026 ===");
            Console.WriteLine("Tăng trưởng chế biến chế tạo: 9.73%");
            Console.WriteLine("FDI vào sản xuất rất mạnh");
            Console.WriteLine("Nhu cầu chuyển đổi số gia tăng");
            Console.WriteLine("Xu hướng: AI, Robot, ERP, IoT");
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            IndustryReport.ShowNationalOverview();

            List<Company> companies = new List<Company>()
            {
                new Company()
                {
                    Name = "TNHH Cơ Khí Việt Phát",
                    Industry = "Cơ khí chế tạo",
                    Employees = 250,
                    Status = "Đơn hàng tăng"
                },

                new Company()
                {
                    Name = "TNHH May Mặc Đông Á",
                    Industry = "Dệt may",
                    Employees = 800,
                    Status = "Cạnh tranh xuất khẩu cao"
                },

                new Company()
                {
                    Name = "TNHH Điện Tử Á Châu",
                    Industry = "Linh kiện điện tử",
                    Employees = 1200,
                    Status = "Mở rộng nhà máy"
                },

                new Company()
                {
                    Name = "TNHH Nhựa Công Nghiệp Việt",
                    Industry = "Nhựa kỹ thuật",
                    Employees = 350,
                    Status = "Ổn định"
                },

                new Company()
                {
                    Name = "TNHH Thực Phẩm An Việt",
                    Industry = "Chế biến thực phẩm",
                    Employees = 500,
                    Status = "Tăng sản lượng"
                }
            };

            foreach (var company in companies)
            {
                company.Display();
            }

            Console.WriteLine();
            Console.WriteLine("=== XU HƯỚNG CÔNG NGHỆ ===");

            string[] technologies =
            {
                "ERP",
                "MES",
                "Robot công nghiệp",
                "AI kiểm tra chất lượng",
                "IoT nhà máy",
                "Digital Twin",
                "Big Data",
                "Blockchain truy xuất nguồn gốc",
                "Kho thông minh",
                "Xe AGV tự hành"
            };

            foreach (string tech in technologies)
            {
                Console.WriteLine("• " + tech);
            }

            Console.WriteLine();
            Console.WriteLine("=== THÁCH THỨC ===");

            Console.WriteLine("1. Chi phí nguyên liệu");
            Console.WriteLine("2. Thiếu lao động tay nghề cao");
            Console.WriteLine("3. Cạnh tranh quốc tế");
            Console.WriteLine("4. Chuyển đổi xanh");
            Console.WriteLine("5. Tự động hóa sản xuất");

            Console.WriteLine();
            Console.WriteLine("=== TRIỂN VỌNG ===");
            Console.WriteLine("FDI tiếp tục tăng.");
            Console.WriteLine("Ngành điện tử, cơ khí và thực phẩm tăng trưởng tốt.");
            Console.WriteLine("Nhà máy thông minh sẽ là xu hướng chủ đạo đến 2030.");

            Console.ReadKey();
        }
    }
}