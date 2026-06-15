using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace BigoLiveInfoApp
{
    // Lớp đại diện cho một danh mục thông tin
    public class InfoCategory
    {
        public string Title { get; set; }
        public List<string> Details { get; set; }

        public InfoCategory(string title)
        {
            Title = title;
            Details = new List<string>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Cấu hình mã hóa UTF-8 để hiển thị đúng tiếng Việt
            Console.OutputEncoding = Encoding.UTF8;

            // 1. Khởi tạo dữ liệu Bigo Live
            string mainTitle = "BIGO LIVE VÀ NHỮNG ĐIỀU NÊN BIẾT";
            string overview = "Bigo Live là nền tảng phát video trực tiếp (livestream) toàn cầu. " +
                             "Ứng dụng cho phép người dùng giao lưu, thể hiện tài năng hoặc xem các thần tượng (Idol) trò chuyện. " +
                             "Người xem có thể donate (tặng quà) ảo để quy đổi ra thu nhập.";

            List<InfoCategory> categories = new List<InfoCategory>();

            // Danh mục 1: Nguồn gốc và Cách thức hoạt động
            var cat1 = new InfoCategory("1. Nguồn gốc và Cách thức hoạt động");
            cat1.Details.Add("- Công ty chủ quản: Thuộc sở hữu của BIGO Technology (trụ sở tại Singapore, công ty mẹ là Joyy) thành lập năm 2014.");
            cat1.Details.Add("- Hoạt động chính: Người dùng (Idol) có thể bật live để ca hát, nhảy múa, hoặc trò chuyện. Người xem có thể donate, sử dụng bộ lọc AI và tham gia phòng tương tác.");
            cat1.Details.Add("- Cẩm nang sử dụng: Cung cấp đầy đủ hướng dẫn từ cách tạo tài khoản, phát live đến xây dựng kênh truyền thông.");
            categories.Add(cat1);

            // Danh mục 2: Cơ chế Kiếm tiền và Thu nhập
            var cat2 = new InfoCategory("2. Cơ chế Kiếm tiền và Thu nhập");
            cat2.Details.Add("- Quy đổi tiền tệ: Quà tặng từ người xem được nhận dưới dạng 'Đậu'. Tỷ lệ quy đổi thông thường là 210 đậu = 1 USD.");
            cat2.Details.Add("- Thu nhập Idol: Một Idol (thần tượng) trên nền tảng có thể kiếm từ 10 triệu đến hàng trăm triệu VNĐ mỗi tháng nhờ vào lượng fan tặng quà.");
            cat2.Details.Add("- Gia tộc Bigo: Để có lượng tương tác ổn định và thu nhập tốt, nhiều Idol tham gia hoặc thành lập các 'Gia tộc' với các sự kiện định kỳ.");
            categories.Add(cat2);

            // Danh mục 3: Lưu ý, rủi ro và Hệ lụy
            var cat3 = new InfoCategory("3. Lưu ý, rủi ro và Hệ lụy");
            cat3.Details.Add("- Nội dung phản cảm: Nền tảng từng bị cơ quan chức năng và chuyên gia cảnh báo về các nội dung không lành mạnh, video hở hang hoặc lệch lạc đạo đức.");
            cat3.Details.Add("- Nguy cơ lừa đảo: Dễ gặp tình trạng lừa đảo việc làm, bị dụ dỗ nạp tiền hoặc làm việc cho các tổ chức không rõ nguồn gốc.");
            cat3.Details.Add("- Thời gian và Tiền bạc: Người xem cần kiểm soát chặt chẽ ngân sách donate, tránh việc tiêu xài quá đà vào tiền ảo.");
            categories.Add(cat3);

            // 2. Định nghĩa đường dẫn lưu file
            string fileName = "ThongTinBigoLive.txt";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            // 3. Tiến hành ghi dữ liệu ra file bằng StreamWriter (hỗ trợ UTF-8)
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    writer.WriteLine("==================================================");
                    writer.WriteLine($"*** {mainTitle} ***");
                    writer.WriteLine("==================================================");
                    writer.WriteLine(overview);
                    writer.WriteLine();

                    foreach (var cat in categories)
                    {
                        writer.WriteLine(cat.Title);
                        foreach (var detail in cat.Details)
                        {
                            writer.WriteLine(detail);
                        }
                        writer.WriteLine(); // Dòng trống phân cách giữa các mục
                    }
                    
                    writer.WriteLine("==================================================");
                    writer.WriteLine($"File được khởi tạo tự động vào lúc: {DateTime.Now}");
                }

                // Thông báo thành công ra màn hình Console
                Console.WriteLine("Xuất dữ liệu thành công!");
                Console.WriteLine($"Vị trí lưu file: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi khi lưu file: {ex.Message}");
            }

            Console.WriteLine("\nNhấn phím bất kỳ để thoát chương trình...");
            Console.ReadKey();
        }
    }
}
