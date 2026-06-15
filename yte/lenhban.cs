using System;
using System.Collections.Generic;

namespace QuanLyQuyenTruyCapCongNghe
{
    #region Danh mục cấu trúc dữ liệu (Domain Models)

    /// <summary>
    /// Đại diện cho một đối tượng bị áp dụng lệnh cấm sử dụng công nghệ
    /// </summary>
    public class DoiTuongBiCam
    {
        public string TenDoiTuong { get; set; }
        public string NhomBoiCanh { get; set; } // Pháp lý, Quân sự, Y tế, Giáo dục, An toàn
        public List<string> ThietBiBiCam { get; set; }
        public string ThoiHanCam { get; set; }
        public string CoQuanBanHanh { get; set; }
        public LyDoChiTiet ChiTietLyDo { get; set; }
    }

    /// <summary>
    /// Chi tiết nguyên nhân và mục đích của lệnh cấm
    /// </summary>
    public class LyDoChiTiet
    {
        public string NguyenNhanCotLoi { get; set; }
        public string MucDichApDung { get; set; }
        public bool CoNguyCoTaiPham { get; set; }
    }

    /// <summary>
    /// Kho lưu trữ dữ liệu tổng hợp về các lý do cấm sử dụng công nghệ
    /// </summary>
    public static class DanhSachLyDoHeThong
    {
        public static Dictionary<string, List<string>> LayDuLieuLyDo()
        {
            return new Dictionary<string, List<string>>
            {
                {
                    "1. CHẾ TÀI PHÁP LÝ & HÌNH SỰ", new List<string>
                    {
                        "Lệnh cấm của Tòa án đối với tội phạm công nghệ cao (Hacker, lừa đảo mạng).",
                        "Vi phạm nghiêm trọng Luật An ninh mạng (Phát tán thông tin độc hại, chống phá).",
                        "Tịch thu thiết bị phục vụ điều tra phá án (Gián điệp, rò rỉ bí mật quốc gia)."
                    }
                },
                {
                    "2. KỶ LUẬT QUÂN SỰ & MÔI TRƯỜNG MẬT", new List<string>
                    {
                        "Bảo mật thông tin cơ yếu, phòng nghiên cứu vũ khí, trung tâm dữ liệu cốt lõi.",
                        "Tránh lộ vị trí đóng quân qua định vị GPS hoặc rò rỉ hình ảnh hành quân.",
                        "Chống gian lận tuyệt đối trong các kỳ thi quốc gia và quốc tế."
                    }
                },
                {
                    "3. CAN THIỆP Y TẾ & TÂM LÝ", new List<string>
                    {
                        "Liệu pháp 'detox công nghệ' cho người nghiện Internet và trò chơi điện tử nặng.",
                        "Hạn chế kích thích thần kinh đối với bệnh nhân trầm cảm, hoang tưởng, mất ngủ mãn tính."
                    }
                },
                {
                    "4. QUẢN LÝ GIÁO DỤC & GIA ĐÌNH", new List<string>
                    {
                        "Biện pháp kỷ luật của cha mẹ khi con cái sa sút học tập hoặc xem nội dung độc hại.",
                        "Quy định cấm sử dụng điện thoại trong giờ học của nhà trường để tăng tập trung."
                    }
                },
                {
                    "5. AN TOÀN KỸ THUẬT ĐẶC THÙ", new List<string>
                    {
                        "Phòng chống cháy nổ tại trạm xăng, nhà máy hóa chất, mỏ khai thác khí gas.",
                        "Tránh nhiễu loạn thiết bị y tế (máy tạo nhịp tim) hoặc an toàn hàng không khi cất/hạ cánh."
                    }
                }
            };
        }
    }

    #endregion

    #region Chương trình chạy chính (Execution Project)

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("==================================================================================");
            Console.WriteLine(" HỆ THỐNG PHÂN TÍCH LÝ DO CẤM SỬ DỤNG INTERNET VÀ THIẾT BỊ CÔNG NGHỆ ");
            Console.WriteLine("==================================================================================\n");

            // 1. Hiển thị danh sách lý do tổng hợp từ hệ thống
            InDanhSachLyDoHeThong();

            // 2. Mô phỏng thực tế các trường hợp bị cấm cụ thể
            List<DoiTuongBiCam> danhSachCam = KhoiTaoTruongHopMoPhong();

            // 3. In báo cáo chi tiết từng trường hợp
            InBaoCaoLenhCam(danhSachCam);

            Console.ReadLine();
        }

        private static void InDanhSachLyDoHeThong()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[A. TỔNG HỢP CÁC NHÓM NGUYÊN NHÂN CHÍNH]");
            Console.ResetColor();

            var duLieu = DanhSachLyDoHeThong.LayDuLieuLyDo();
            foreach (var nhom in duLieu)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n* {nhom.Key}:");
                Console.ResetColor();
                foreach (var lyDo in nhom.Value)
                {
                    Console.WriteLine($"  - {lyDo}");
                }
            }
            Console.WriteLine("\n----------------------------------------------------------------------------------\n");
        }

        private static List<DoiTuongBiCam> KhoiTaoTruongHopMoPhong()
        {
            return new List<DoiTuongBiCam>
            {
                new DoiTuongBiCam
                {
                    TenDoiTuong = "Tội phạm mạng đang hưởng án treo",
                    NhomBoiCanh = "Pháp lý & Hình sự",
                    ThietBiBiCam = new List<string> { "Internet", "Máy tính cá nhân", "Điện thoại thông minh" },
                    ThoiHanCam = "3 năm quản chế tại địa phương",
                    CoQuanBanHanh = "Tòa án Nhân dân",
                    ChiTietLyDo = new LyDoChiTiet
                    {
                        NguyenNhanCotLoi = "Từng tổ chức đường dây lừa đảo chiếm đoạt tài sản qua mạng",
                        MucDichApDung = "Ngăn chặn hành vi tiếp cận không gian mạng để tiếp tục phạm tội",
                        CoNguyCoTaiPham = true
                    }
                },
                new DoiTuongBiCam
                {
                    TenDoiTuong = "Chiến sĩ thuộc đơn vị Tác chiến đặc biệt",
                    NhomBoiCanh = "Quân sự & Cơ yếu",
                    ThietBiBiCam = new List<string> { "Thiết bị di động có định vị GPS", "Máy ảnh", "Thiết bị thu phát sóng cá nhân" },
                    ThoiHanCam = "Toàn thời gian trong doanh trại và khi làm nhiệm vụ",
                    CoQuanBanHanh = "Bộ Chỉ huy Quân sự",
                    ChiTietLyDo = new LyDoChiTiet
                    {
                        NguyenNhanCotLoi = "Yêu cầu bảo mật tuyệt đối vị trí đóng quân và kế hoạch hành quân",
                        MucDichApDung = "Phòng ngừa gián điệp công nghệ và rò rỉ thông tin tình báo",
                        CoNguyCoTaiPham = false
                    }
                },
                new DoiTuongBiCam
                {
                    TenDoiTuong = "Bệnh nhân điều trị Hội chứng Nghiện Game nặng",
                    NhomBoiCanh = "Y tế & Tâm lý",
                    ThietBiBiCam = new List<string> { "Máy tính chơi game (PC/Console)", "Internet băng thông rộng" },
                    ThoiHanCam = "Theo liệu trình điều trị của bác sĩ (Dự kiến 6 tháng)",
                    CoQuanBanHanh = "Hội đồng Y khoa / Gia đình giám sát",
                    ChiTietLyDo = new LyDoChiTiet
                    {
                        NguyenNhanCotLoi = "Suy nhược cơ thể nghiêm trọng, rối loạn hành vi do thức đêm chơi game kéo dài",
                        MucDichApDung = "Cách ly khỏi tác nhân kích thích thần kinh, phục hồi sức khỏe tâm thần",
                        CoNguyCoTaiPham = true
                    }
                }
            };
        }

        private static void InBaoCaoLenhCam(List<DoiTuongBiCam> danhSach)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[B. BÁO CÁO CHI TIẾT CÁC TRƯỜNG HỢP ĐIỂN HÌNH]");
            Console.ResetColor();

            foreach (var dt in danhSach)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\n[Đối tượng: {dt.TenDoiTuong}]");
                Console.ResetColor();
                Console.WriteLine($"  + Nhóm bối cảnh : {dt.NhomBoiCanh}");
                Console.WriteLine($"  + Thẩm quyền cấm: {dt.CoQuanBanHanh}");
                Console.WriteLine($"  + Thời hạn cấm  : {dt.ThoiHanCam}");
                Console.WriteLine($"  + Thiết bị áp đặt: {string.Join(", ", dt.ThietBiBiCam)}");
                Console.WriteLine($"  + Nguyên nhân    : {dt.ChiTietLyDo.NguyenNhanCotLoi}");
                Console.WriteLine($"  + Mục đích       : {dt.ChiTietLyDo.MucDichApDung}");
                Console.WriteLine($"  + Nguy cơ tái phạm cao: {(dt.ChiTietLyDo.CoNguyCoTaiPham ? "Có ⚠️" : "Không 🟢")}");
            }
            Console.WriteLine("==================================================================================");
        }
    }

    #endregion
}
