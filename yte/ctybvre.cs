using System;
using System.Collections.Generic;

namespace YTeCoSoVietNam2026
{
    #region Danh mục cấu trúc dữ liệu (Domain Models)

    /// <summary>
    /// Đại diện cho một Trạm Y tế cấp xã tại Việt Nam
    /// </summary>
    public class TramYTeXa
    {
        public string TenTram { get; set; }
        public string ThonXa { get; set; }
        public string TinhThanh { get; set; }
        public bool DatChuanQuocGia2026 { get; set; }
        public CoSoVatChat HaTang { get; set; }
        public ThongTinNhanLuc NhanLuc { get; set; }
        public HeThongCongNgheSo CongNghe { get; set; }
    }

    /// <summary>
    /// Tình trạng cơ sở vật chất và trang thiết bị
    /// </summary>
    public class CoSoVatChat
    {
        public string TinhTrangPhongKham { get; set; } // Sửa chữa mới, xuống cấp, xây mới
        public List<string> ThietBiMoiCap { get; set; }
        public bool SanSangSoCapCuu { get; set; }
    }

    /// <summary>
    /// Cơ cấu nhân sự tại trạm y tế
    /// </summary>
    public class ThongTinNhanLuc
    {
        public int SoLuongBacSi { get; set; }
        public int SoLuongDieuDuongYTa { get; set; }
        public bool ThieuHutNhanLucChatLuongCao { get; set; }
        public string ChieuHuongDichChuyen { get; set; } // Khối tư nhân cạnh tranh gay gắt
    }

    /// <summary>
    /// Các nền tảng số hóa theo định hướng y tế thông minh
    /// </summary>
    public class HeThongCongNgheSo
    {
        public bool DaTrienKhaiHoSoSucKhoeDienTu { get; set; }
        public bool CoHeThongKhamBenhTuXaTelehealth { get; set; }
        public string NenTangQuanLy { get; set; } // Hệ thống dữ liệu đồng bộ Bộ Y tế
    }

    /// <summary>
    /// Lưu trữ các thông tin mang tính chiến lược và pháp lý
    /// </summary>
    public static class TinhHinhViMo2026
    {
        public const string MoHinhQuanLyMoi = "Từ 01/01/2026, Trạm Y tế xã chuyển giao từ TTYT Huyện về UBND Cấp Xã quản lý trực tiếp.";
        public const string HanhLangPhapLy = "Thông tư số 43/2025/TT-BYT hướng dẫn chức năng, nhiệm vụ, quyền hạn và cơ cấu tổ chức.";
        public const string HuongDichChuyen = "Tinh gọn bộ máy, chuyển dịch theo mô hình chính quyền địa phương hai cấp.";
        
        public static List<string> CacThachThucLon => new List<string>
        {
            "Khó khăn thủ tục bàn giao tài sản, máy móc sau sáp nhập địa giới hành chính.",
            "Thiếu hụt nguồn nhân lực trình độ cao do chính sách đãi ngộ chưa cạnh tranh được với y tế tư nhân.",
            "Tiến độ giải ngân nguồn vốn đầu tư công tại một số địa phương còn chậm."
        };
    }

    #endregion

    #region Chương trình chạy chính (Execution Project)

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("==================================================================================");
            Console.WriteLine("HỆ THỐNG GIÁM SÁT TÌNH HÌNH XÂY DỰNG VÀ ĐỔI MỚI Y TẾ TUYẾN XÃ VIỆT NAM (CẬP NHẬT 2026)");
            Console.WriteLine("==================================================================================\n");

            // 1. Hiển thị thông tin vĩ mô và pháp lý
            InThongTinViMo();

            // 2. Khởi tạo dữ liệu mẫu mô phỏng thực tế chuyển đổi tại một trạm y tế vùng chuyển đổi
            TramYTeXa tramMau = KhoiTaoDuLieuTramMau();

            // 3. Đánh giá và in báo cáo chi tiết trạm y tế
            InBaoCaoTramYTe(tramMau);

            Console.ReadLine();
        }

        private static void InThongTinViMo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[1. THAY ĐỔI LỚN VỀ TỔ CHỨC & PHÁP LÝ]");
            Console.ResetColor();
            Console.WriteLine($"- Mô hình quản lý: {TinhHinhViMo2026.MoHinhQuanLyMoi}");
            Console.WriteLine($"- Căn cứ pháp lý: {TinhHinhViMo2026.HanhLangPhapLy}");
            Console.WriteLine($"- Định hướng: {TinhHinhViMo2026.HuongDichChuyen}\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[2. THÁCH THỨC LỚN HIỆN NAY]");
            Console.ResetColor();
            foreach (var thachThuc in TinhHinhViMo2026.CacThachThucLon)
            {
                Console.WriteLine($"- Bất cập: {thachThuc}");
            }
            Console.WriteLine("\n----------------------------------------------------------------------------------\n");
        }

        private static TramYTeXa KhoiTaoDuLieuTramMau()
        {
            return new TramYTeXa
            {
                TenTram = "Trạm Y tế Xã Điển Hình",
                ThonXa = "Xã Đổi Mới",
                TinhThanh = "Tỉnh Tiên Phong",
                DatChuanQuocGia2026 = true,
                HaTang = new CoSoVatChat
                {
                    TinhTrangPhongKham = "Được đầu tư xây mới & sửa chữa đồng bộ từ nguồn vốn đầu tư công",
                    ThietBiMoiCap = new List<string> { "Máy siêu âm 4D", "Máy xét nghiệm máu cơ bản", "Hệ thống thở oxy" },
                    SanSangSoCapCuu = true
                },
                NhanLuc = new ThongTinNhanLuc
                {
                    SoLuongBacSi = 1,
                    SoLuongDieuDuongYTa = 3,
                    ThieuHutNhanLucChatLuongCao = true,
                    ChieuHuongDichChuyen = "Bác sĩ trẻ có xu hướng chuyển dịch sang khối bệnh viện tư nhân do thu nhập"
                },
                CongNghe = new HeThongCongNgheSo
                {
                    DaTrienKhaiHoSoSucKhoeDienTu = true,
                    CoHeThongKhamBenhTuXaTelehealth = true,
                    NenTangQuanLy = "Kết nối liên thông dữ liệu triệu chứng lâm sàng toàn diện với Bộ Y Tế"
                }
            };
        }

        private static void InBaoCaoTramYTe(TramYTeXa tram)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[3. BÁO CÁO THỰC ĐỊA: {tram.TenTram.ToUpper()} - {tram.TinhThanh.ToUpper()}]");
            Console.ResetColor();
            Console.WriteLine($"- Đạt chuẩn quốc gia bộ tiêu chí mới: {(tram.DatChuanQuocGia2026 ? "Đã Đạt ✔" : "Chưa Đạt ❌")}");
            
            Console.WriteLine("\na. Cơ sở vật chất & Hạ tầng kỹ thuật:");
            Console.WriteLine($"  + Hiện trạng: {tram.HaTang.TinhTrangPhongKham}");
            Console.WriteLine($"  + Thiết bị y tế cấp mới: {string.Join(", ", tram.HaTang.ThietBiMoiCap)}");
            Console.WriteLine($"  + Năng lực sơ cấp cứu tại chỗ: {(tram.HaTang.SanSangSoCapCuu ? "Đảm bảo tốt" : "Còn hạn chế")}");

            Console.WriteLine("\nb. Hạ tầng công nghệ số (Y tế thông minh):");
            Console.WriteLine($"  + Hồ sơ sức khỏe điện tử trọn đời: {(tram.CongNghe.DaTrienKhaiHoSoSucKhoeDienTu ? "Đã triển khai số hóa" : "Chưa tích hợp")}");
            Console.WriteLine($"  + Khám chữa bệnh từ xa (Telehealth): {(tram.CongNghe.CoHeThongKhamBenhTuXaTelehealth ? "Sẵn sàng kết nối chuyên gia tuyến trên" : "Chưa cài đặt")}");
            Console.WriteLine($"  + Nền tảng lõi: {tram.CongNghe.NenTangQuanLy}");

            Console.WriteLine("\nc. Thực trạng nhân lực:");
            Console.WriteLine($"  + Định biên: {tram.NhanLuc.SoLuongBacSi} Bác sĩ, {tram.NhanLuc.SoLuongDieuDuongYTa} Điều dưỡng/Y tá.");
            Console.WriteLine($"  + Tình trạng khan hiếm nhân sự cao cấp: {(tram.NhanLuc.ThieuHutNhanLucChatLuongCao ? "Cảnh báo Đỏ (Thiếu hụt)" : "Ổn định")}");
            Console.WriteLine($"  + Áp lực cạnh tranh: {tram.NhanLuc.ChieuHuongDichChuyen}");
            Console.WriteLine("==================================================================================");
        }
    }

    #endregion
}
