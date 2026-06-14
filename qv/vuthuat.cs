using System;
using System.Collections.Generic;

namespace VuThuatTheGioi
{
    // Struct mô tả một hệ thống vu thuật/pháp thuật dân gian
    public struct HeThongVuThuat
    {
        public string TenGoi;
        public string KhuVuc;
        public string NguonGoc;
        public string[] DacTrung;
        public string[] NghiLeTieuBieu;
        public string[] CongCu;
        public string TinhTrangHienNay;
        public string AnhHuongVanHoa;

        public HeThongVuThuat(string ten, string kv, string nguon, string[] dacTrung, 
            string[] nghiLe, string[] congCu, string tinhTrang, string anhHuong)
        {
            TenGoi = ten;
            KhuVuc = kv;
            NguonGoc = nguon;
            DacTrung = dacTrung;
            NghiLeTieuBieu = nghiLe;
            CongCu = congCu;
            TinhTrangHienNay = tinhTrang;
            AnhHuongVanHoa = anhHuong;
        }

        public void InThongTin()
        {
            Console.WriteLine($"=== {TenGoi} ===");
            Console.WriteLine($"Khu vực: {KhuVuc}");
            Console.WriteLine($"Nguồn gốc: {NguonGoc}");
            Console.WriteLine("Đặc trưng:");
            foreach (var dt in DacTrung) Console.WriteLine($"  - {dt}");
            Console.WriteLine("Nghi lễ tiêu biểu:");
            foreach (var nl in NghiLeTieuBieu) Console.WriteLine($"  * {nl}");
            Console.WriteLine("Công cụ thường dùng:");
            foreach (var cc in CongCu) Console.WriteLine($"  + {cc}");
            Console.WriteLine($"Tình trạng hiện nay: {TinhTrangHienNay}");
            Console.WriteLine($"Ảnh hưởng văn hóa: {AnhHuongVanHoa}");
            Console.WriteLine();
        }
    }

    class Program
    {
        static List<HeThongVuThuat> KhoiTaoDuLieu()
        {
            var danhSach = new List<HeThongVuThuat>();

            danhSach.Add(new HeThongVuThuat(
                "Wicca Hiện Đại",
                "Châu Âu, Bắc Mỹ, Úc",
                "Phục hưng từ 1950 bởi Gerald Gardner, dựa trên tín ngưỡng ngoại giáo châu Âu cổ",
                new[] {
                    "Thờ Nữ Thần và Vị Thần Có Sừng",
                    "Tôn trọng Bánh Xe Năm - 8 lễ Sabbat",
                    "Luật Ba Lần: năng lượng gửi đi sẽ quay lại gấp ba",
                    "Thực hành phép thuật với thiên nhiên, trăng, nguyên tố"
                },
                new[] {
                    "Esbat - nghi lễ trăng tròn hàng tháng",
                    "Samhain - năm mới phù thủy 31/10",
                    "Nghi thức vẽ vòng tròn ma thuật"
                },
                new[] { "Athame - dao nghi lễ", "Nến", "Thảo mộc", "Tinh thể", "Sách Bóng Tối" },
                "Hợp pháp ở nhiều nước, khoảng 1-1.5 triệu người thực hành. Cộng đồng online phát triển mạnh",
                "Ảnh hưởng phim ảnh, văn học fantasy, phong trào sinh thái, nữ quyền tâm linh"
            ));

            danhSach.Add(new HeThongVuThuat(
                "Vodou Haiti",
                "Haiti, New Orleans Mỹ, Cộng hòa Dominica",
                "Hòa trộn tín ngưỡng Tây Phi Yoruba/Fon với Công giáo thời nô lệ thế kỷ 17-18",
                new[] {
                    "Thờ Loa - các linh thần trung gian",
                    "Papa Legba giữ cổng linh giới",
                    "Nghi lễ gọi hồn qua trống, múa, nhập đồng",
                    "Veve - biểu tượng hình học vẽ bằng bột"
                },
                new[] {
                    "Lễ cúng Loa với rượu rum, thuốc lá",
                    "Nhập đồng để Loa nói qua thân xác",
                    "Lễ tưởng niệm tổ tiên Gede"
                },
                new[] { "Trống", "Búp bê nghi lễ", "Nến nhiều màu", "Nước thánh", "Veve" },
                "Tôn giáo chính thức của Haiti từ 2003. 60% dân Haiti thực hành. Bị Hollywood bóp méo nhiều",
                "Nhạc, múa, nghệ thuật Haiti. Ảnh hưởng văn hóa New Orleans, jazz, blues"
            ));

            danhSach.Add(new HeThongVuThuat(
                "Santería / Regla de Ocha",
                "Cuba, Puerto Rico, Miami, Venezuela",
                "Tín ngưỡng Yoruba châu Phi kết hợp Công giáo Tây Ban Nha thời nô lệ",
                new[] {
                    "Thờ Orisha - thần linh đại diện lực tự nhiên",
                    "Mỗi Orisha ứng với một vị thánh Công giáo",
                    "Bói toán bằng vỏ sò Diloggun",
                    "Hiến tế động vật nhỏ trong nghi lễ lớn"
                },
                new[] {
                    "Lễ nhập môn làm thầy cúng Santero/Santera",
                    "Bembé - lễ hội trống múa gọi Orisha",
                    "Lễ thanh tẩy Ori - đầu"
                },
                new[] { "Vỏ sò cowrie", "Chuỗi hạt Elekes", "Trống Batá", "Thảo mộc Ewe", "Nến" },
                "Ước tính 3-5 triệu người ở châu Mỹ. Hợp pháp nhưng vẫn bị kỳ thị. Phát triển mạnh ở Miami",
                "Âm nhạc salsa, rumba. Nghệ thuật Afro-Cuba. Ẩm thực cúng tế"
            ));

            danhSach.Add(new HeThongVuThuat(
                "Shaman Siberia - Mông Cổ",
                "Siberia Nga, Mông Cổ, Tuva, Buryatia",
                "Tín ngưỡng bản địa hàng nghìn năm, Tengri giáo ở Mông Cổ",
                new[] {
                    "Shaman là cầu nối giữa 3 thế giới: Thượng, Trung, Hạ",
                    "Du hành linh hồn khi xuất thần",
                    "Thờ Tengri - Trời Xanh và linh hồn tổ tiên",
                    "Chữa bệnh bằng linh hồn, trục vong"
                },
                new[] {
                    "Nghi lễ đánh trống xuyên đêm để xuất hồn",
                    "Lễ Ovoo cúng núi đá thiêng",
                    "Lễ Tsagaan Sar đầu năm cầu may"
                },
                new[] { "Trống da thú", "Áo choàng gắn chuông", "Gương Toli", "Cành cây thiêng", "Khăn Hadag" },
                "Hồi sinh mạnh sau Liên Xô sụp đổ. Mông Cổ có 10,000+ shaman đăng ký. Du lịch tâm linh tăng",
                "Âm nhạc khàn giọng Khoomei. Y học cổ truyền. Bảo tồn văn hóa du mục"
            ));

            danhSach.Add(new HeThongVuThuat(
                "Onmyōdō - Âm Dương Đạo",
                "Nhật Bản",
                "Du nhập từ Đạo giáo Trung Quốc thế kỷ 6, phát triển thời Heian",
                new[] {
                    "Dùng Âm Dương Ngũ Hành để bói toán, trừ tà",
                    "Onmyoji - âm dương sư làm việc cho triều đình",
                    "Shikigami - thức thần giấy phục vụ chủ",
                    "Lịch pháp, phong thủy, chiêm tinh"
                },
                new[] {
                    "Lễ trừ tà Tsuina cuối năm",
                    "Dán bùa Ofuda trừ ma",
                    "Kagura - vũ điệu gọi thần"
                },
                new[] { "Bùa giấy", "Kiếm gỗ", "Gương đồng", "La bàn phong thủy", "Chỉ ngũ sắc" },
                "Không còn là tôn giáo chính thức nhưng vẫn có đền thờ. Ảnh hưởng mạnh anime, manga, game",
                "Manga Onmyoji, phim, game. Kiến trúc đền chùa. Lễ hội Setsubun ném đậu"
            ));

            danhSach.Add(new HeThongVuThuat(
                "Pháp Thuật Dân Gian Việt Nam",
                "Việt Nam, cộng đồng người Việt hải ngoại",
                "Hòa trộn Đạo Mẫu, Đạo giáo, Phật giáo, tín ngưỡng bản địa",
                new[] {
                    "Đạo Mẫu - thờ Thánh Mẫu Liễu Hạnh, Tam Tòa Thánh Mẫu",
                    "Lên đồng - hầu bóng, nhập thánh",
                    "Bùa chú, yểm, giải hạn, trừ tà",
                    "Thầy pháp, thầy cúng, bà đồng, ông đồng"
                },
                new[] {
                    "Hầu đồng với 36 giá chầu",
                    "Lễ giải hạn đầu năm",
                    "Cúng cô hồn tháng 7",
                    "Trấn yểm nhà cửa"
                },
                new[] { "Khăn chầu", "Quạt", "Gương", "Chuông", "Bùa chữ Nho", "Gạo muối" },
                "UNESCO công nhận Thực hành Tín ngưỡng thờ Mẫu là Di sản 2016. Hàng triệu người thực hành",
                "Chèo, chầu văn. Ẩm thực cúng lễ. Du lịch tâm linh Phủ Dầy, Sòng Sơn"
            ));

            danhSach.Add(new HeThongVuThuat(
                "Hoodoo / Rootwork",
                "Miền Nam nước Mỹ, cộng đồng người Mỹ gốc Phi",
                "Hình thành thế kỷ 18-19 từ tín ngưỡng châu Phi + Kinh Thánh + thảo mộc bản địa",
                new[] {
                    "Phép thuật dân gian, không phải tôn giáo",
                    "Dùng Kinh Thánh, đặc biệt Thánh Vịnh",
                    "Mojos - túi bùa mang theo người",
                    "Nhấn mạnh quyền năng cá nhân"
                },
                new[] {
                    "Làm túi Mojo Hand cầu tiền, tình, bảo vệ",
                    "Tắm thanh tẩy bằng thảo mộc",
                    "Đốt nến theo màu với ý nguyện"
                },
                new[] { "Rễ John the Conqueror", "Dầu phép", "Bột phép", "Nến", "Kinh Thánh" },
                "Vẫn phổ biến ở miền Nam Mỹ. Thương mại hóa thành thương hiệu. Khác với Voodoo Louisiana",
                "Nhạc Blues, văn hóa miền Nam. Từ lóng 'mojo' vào tiếng Anh"
            ));

            danhSach.Add(new HeThongVuThuat(
                "Seiðr Bắc Âu",
                "Iceland, Na Uy, Đan Mạch, cộng đồng Ásatrú",
                "Phục dựng từ thơ Edda, saga Viking. Nữ thần Freyja là bậc thầy Seiðr",
                new[] {
                    "Phép thuật xuất hồn, tiên tri Völva",
                    "Dệt số phận bằng khung cửi",
                    "Ngồi trên giàn cao Seiðhjallr để bói",
                    "Liên quan đến rune, galdr - thần chú"
                },
                new[] {
                    "Nghi lễ Útiseta - ngồi ngoài mộ đêm để gặp linh hồn",
                    "Bói rune 24 chữ Futhark",
                    "Blót - hiến tế cho thần"
                },
                new[] { "Gậy Völ Völva", "Áo choàng da mèo", "Rune", "Trống", "Sừng uống rượu" },
                "Phục hưng mạnh từ 1970. Iceland công nhận Ásatrú 1973. 5,000+ thành viên",
                "Văn hóa Viking, metal, fantasy. Lễ hội mùa đông. Phim Marvel về Thor"
            ));

            danhSach.Add(new HeThongVuThuat(
                "Candomblé",
                "Brazil, đặc biệt Bahia",
                "Nô lệ Yoruba mang đến Brazil thế kỷ 16, giữ bí mật dưới vỏ Công giáo",
                new[] {
                    "Thờ Orixás - tương tự Orisha của Santería",
                    "Terreiro - đền thờ do Mãe/Pai de Santo cai quản",
                    "Nhập đồng khi Orixá giáng",
                    "Ẩm thực cúng là phần quan trọng"
                },
                new[] {
                    "Lễ hội Iemanjá 2/2 ở biển",
                    "Xirê - vũ điệu gọi Orixá",
                    "Lễ cạo đầu nhập môn"
                },
                new[] { "Chuỗi hạt", "Trang phục trắng", "Trống Atabaque", "Đồ ăn cúng", "Nước hoa" },
                "2 triệu người Brazil. Được bảo vệ hiến pháp. UNESCO công nhận một số terreiro",
                "Samba, Capoeira, lễ hội Carnival. Ẩm thực Acarajé, Vatapá"
            ));

            danhSach.Add(new HeThongVuThuat(
                "Brujería Mỹ Latinh",
                "Mexico, Colombia, Peru, Trung Mỹ",
                "Hòa trộn tín ngưỡng bản địa Maya, Aztec, Inca với Công giáo và phù thủy châu Âu",
                new[] {
                    "Curandero/a - thầy chữa, Brujo/a - phù thủy",
                    "Santa Muerte - Thánh Chết được thờ",
                    "Limpia - thanh tẩy bằng trứng, thảo mộc",
                    "Mal de Ojo - yểm bùa mắt quỷ"
                },
                new[] {
                    "Lễ Día de los Muertos 1-2/11",
                    "Tắm Temazcal xông hơi nghi lễ",
                    "Đọc bài Tây, bã cà phê"
                },
                new[] { "Trứng gà", "Thánh giá", "Nến 7 màu", "Tượng Santa Muerte", "Thảo mộc Copal" },
                "Phổ biến rộng rãi. Mercado Sonora Mexico là chợ phù thủy lớn nhất. Du lịch tâm linh tăng",
                "Nghệ thuật dân gian, lễ hội. Phim ảnh. Biểu tượng Santa Muerte toàn cầu"
            ));

            return danhSach;
        }

        static void ThongKe(List<HeThongVuThuat> ds)
        {
            Console.WriteLine("=== THỐNG KÊ TỔNG QUAN ===");
            Console.WriteLine($"Tổng số hệ thống: {ds.Count}");
            
            var kv = new Dictionary<string, int>();
            foreach (var ht in ds)
            {
                var khuVucChinh = ht.KhuVuc.Split(',')[0].Trim();
                if (!kv.ContainsKey(khuVucChinh)) kv[khuVucChinh] = 0;
                kv[khuVucChinh]++;
            }
            
            Console.WriteLine("Phân bố khu vực:");
            foreach (var pair in kv)
                Console.WriteLine($"  - {pair.Key}: {pair.Value} hệ thống");
            
            Console.WriteLine("
=== XU HƯỚNG CHUNG THẾ KỶ 21 ===");
            Console.WriteLine("1. Phục hưng sau thời kỳ đàn áp: nhiều hệ thống hồi sinh mạnh");
            Console.WriteLine("2. Toàn cầu hóa: di cư mang theo tín ngưỡng khắp thế giới");
            Console.WriteLine("3. Thương mại hóa: du lịch tâm linh, sản phẩm phép thuật online");
            Console.WriteLine("4. Giao thoa: kết hợp với tâm lý học, thiền, chữa lành");
            Console.WriteLine("5. Tranh cãi: giữa bảo tồn văn hóa và bóp méo văn hóa");
            Console.WriteLine("6. Số hóa: cộng đồng TikTok Witch, Instagram Bruja, YouTube Tarot");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("VŨ THUẬT VÀ PHÁP THUẬT DÂN GIAN TRÊN THẾ GIỚI HIỆN NAY");
            Console.WriteLine("Tài liệu tham khảo văn hóa - nhân học
");
            
            var danhSach = KhoiTaoDuLieu();
            foreach (var ht in danhSach)
            {
                ht.InThongTin();
            }
            
            ThongKe(danhSach);
            
            Console.WriteLine("
=== LƯU Ý ===");
            Console.WriteLine("Tài liệu này chỉ mang tính tham khảo, nghiên cứu văn hóa.");
            Console.WriteLine("Thực hành cần tôn trọng luật pháp, tín ngưỡng địa phương và không gây hại.");
        }
    }
}
