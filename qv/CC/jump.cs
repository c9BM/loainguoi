using System;
using System.Collections.Generic;

namespace DongVatVoHai
{
    class DongVat
    {
        public string Ten { get; set; }
        public string MoiTruongSong { get; set; }
        public string DacDiem { get; set; }

        public DongVat(string ten, string moiTruongSong, string dacDiem)
        {
            Ten = ten;
            MoiTruongSong = moiTruongSong;
            DacDiem = dacDiem;
        }

        public void HienThiThongTin()
        {
            Console.WriteLine("Tên động vật: " + Ten);
            Console.WriteLine("Môi trường sống: " + MoiTruongSong);
            Console.WriteLine("Đặc điểm: " + DacDiem);
            Console.WriteLine(new string('-', 60));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("DANH SÁCH MỘT SỐ ĐỘNG VẬT VÔ HẠI TRÊN THẾ GIỚI");
            Console.WriteLine(new string('=', 60));

            List<DongVat> danhSach = new List<DongVat>()
            {
                new DongVat(
                    "Thỏ",
                    "Đồng cỏ, rừng và trang trại",
                    "Ăn thực vật, hiền lành và thường tránh xa nguy hiểm."
                ),

                new DongVat(
                    "Chuột Lang Nước (Capybara)",
                    "Nam Mỹ",
                    "Loài gặm nhấm lớn nhất thế giới, rất thân thiện với các loài khác."
                ),

                new DongVat(
                    "Lợn Biển (Guinea Pig)",
                    "Được nuôi làm thú cưng",
                    "Hiền lành, dễ chăm sóc và hiếm khi tấn công con người."
                ),

                new DongVat(
                    "Gấu Trúc Đỏ",
                    "Rừng núi Himalaya",
                    "Ăn tre và trái cây, có tính cách nhút nhát."
                ),

                new DongVat(
                    "Lười Ba Ngón",
                    "Rừng nhiệt đới Trung và Nam Mỹ",
                    "Di chuyển chậm, chủ yếu ăn lá cây."
                ),

                new DongVat(
                    "Cừu",
                    "Đồng cỏ và trang trại",
                    "Động vật ăn cỏ, sống theo bầy đàn."
                ),

                new DongVat(
                    "Hươu Sao",
                    "Rừng và đồng cỏ",
                    "Nhút nhát, thường bỏ chạy khi gặp nguy hiểm."
                ),

                new DongVat(
                    "Cá Heo",
                    "Đại dương",
                    "Thông minh, thường có hành vi thân thiện với con người."
                ),

                new DongVat(
                    "Rùa Cạn",
                    "Nhiều khu vực trên thế giới",
                    "Chậm chạp, chủ yếu ăn thực vật."
                ),

                new DongVat(
                    "Koala",
                    "Úc",
                    "Dành phần lớn thời gian nghỉ ngơi trên cây và ăn lá bạch đàn."
                )
            };

            foreach (var dongVat in danhSach)
            {
                dongVat.HienThiThongTin();
            }

            Console.WriteLine("Kết thúc danh sách.");
            Console.ReadKey();
        }
    }
}