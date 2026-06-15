using System;
using System.Collections.Generic;

namespace YTeCoSoVietNam2026
{
    #region Lớp kế thừa dành riêng cho Vùng Núi Khó Khăn

    /// <summary>
    /// Đại diện cho Trạm y tế tại các xã vùng cao, biên giới, hải đảo, kinh tế đặc biệt khó khăn
    /// </summary>
    public class TramYTeVungKhoKhan : TramYTeXa
    {
        // Thuộc tính đặc thù vùng miền
        public int DoKhoKhanTheoPhanCap { get; set; } // Bậc 1 đến 3 (3 là đặc biệt khó khăn)
        public double KhoangCachDenBanhVienHuyenKm { get; set; }
        public ThongTinTroCap ChinhSachDaiNgo { get; set; }
        public GiaiPhapPhucHoi GiaiPhapDacThu { get; set; }
    }

    /// <summary>
    /// Các chính sách trợ cấp, thu hút bác sĩ về vùng cao
    /// </summary>
    public class ThongTinTroCap
    {
        public double PhanTramPhuCapUuDaiNghe { get; set; } // Thường từ 70% - 100% lương
        public bool CoHoTroNhaCongVu { get; set; }
        public string ChinhSachThuHutRiengCuaTinh { get; set; }
    }

    /// <summary>
    /// Các giải pháp đặc thù đang triển khai cho vùng lõi khó khăn
    /// </summary>
    public class GiaiPhapPhucHoi
    {
        public bool SuDungGoiDienThoaiVienThongMienPhi { get; set; } // Phục vụ Telehealth vùng sâu
        public string MoHinhLuanPhienBacSi { get; set; } // Chế độ luân phiên có thời hạn từ tuyến trên về xã
        public string NguonVonUuTien { get; set; } // Chương trình mục tiêu quốc gia phát triển KT-XH vùng đồng bào ĐTTS&MN
    }

    #endregion

    #region Chương trình quản lý nâng cấp

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("==================================================================================");
            Console.WriteLine(" HỆ THỐNG GIÁM SÁT Y TẾ CƠ SỞ: KHU VỰC MIỀN NÚI & KHÓ KHĂN (CẬP NHẬT 2026) ");
            Console.WriteLine("==================================================================================\n");

            // 1. Khởi tạo dữ liệu một trạm y tế vùng cao đặc biệt khó khăn
            TramYTeVungKhoKhan tramVungCao = KhoiTaoTramVungCao();

            // 2. In báo cáo giám sát thực địa
            InBaoCaoTramVungCao(tramVungCao);

            Console.ReadLine();
        }

        private static TramYTeVungKhoKhan KhoiTaoTramVungCao()
        {
            return new TramYTeVungKhoKhan
            {
                // Dữ liệu nền tảng kế thừa
                TenTram = "Trạm Y tế Xã Bản Đèo",
                ThonXa = "Xã Biên Giới Giáp Biên",
                TinhThanh = "Tỉnh Cao Nguyên",
                DatChuanQuocGia2026 = false, // Vùng khó khăn thường gặp trở ngại khi chạy đua đạt chuẩn mới
                
                HaTang = new CoSoVatChat
                {
                    TinhTrangPhongKham = "Cơ sở cũ xuống cấp, đang chờ phê duyệt dòng vốn Chương trình mục tiêu quốc gia",
                    ThietBiMoiCap = new List<string> { "Tủ thuốc y tế cơ bản", "Bộ dụng cụ đỡ đẻ an toàn", "Bộ đàm kết nối vùng lõm sóng" },
                    SanSangSoCapCuu = false // Gặp khó do địa hình chia cắt
                },
                NhanLuc = new ThongTinNhanLuc
                {
                    SoLuongBacSi = 0, // Thực trạng phổ biến: Trạm y tế xã trắng bác sĩ
                    SoLuongDieuDuongYTa = 2,
                    ThieuHutNhanLucChatLuongCao = true,
                    ChieuHuongDichChuyen = "Không tuyển được bác sĩ mới; nhân lực hiện tại quá tải, kiêm nhiệm nhiều vai trò"
                },
                CongNghe = new HeThongCongNgheSo
                {
                    DaTrienKhaiHoSoSucKhoeDienTu = false, // Hạ tầng mạng chưa đồng bộ
                    CoHeThongKhamBenhTuXaTelehealth = true, // Được ưu tiên lắp đặt để nhận hỗ trợ khẩn cấp tuyến trên
                    NenTangQuanLy = "Sử dụng dữ liệu offline tạm thời, đồng bộ định kỳ khi có mạng"
                },

                // Dữ liệu đặc thù vùng khó khăn
                DoKhoKhanTheoPhanCap = 3, // Cấp độ đặc biệt khó khăn
                KhoangCachDenBanhVienHuyenKm = 45.5, // Đường đèo dốc hiểm trở
                ChinhSachDaiNgo = new ThongTinTroCap
                {
                    PhanTramPhuCapUuDaiNghe = 100.0, // Mức phụ cấp cao nhất theo quy định cho vùng biên giới
                    CoHoTroNhaCongVu = true,
                    ChinhSachThuHutRiengCuaTinh = "Hỗ trợ một lần đất ở hoặc tiền mặt nếu cam kết phục vụ trên 5 năm"
                },
                GiaiPhapDacThu = new GiaiPhapPhucHoi
                {
                    SuDungGoiDienThoaiVienThongMienPhi = true,
                    MoHinhLuanPhienBacSi = "Bác sĩ từ Bệnh viện đa khoa huyện luân phiên cắm bản 2 ngày/tuần",
                    NguonVonUuTien = "Nguồn vốn Chương trình mục tiêu quốc gia phát triển kinh tế xã hội vùng đồng bào dân tộc thiểu số"
                }
            };
        }

        private static void InBaoCaoTramVungCao(TramYTeVungKhoKhan tram)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[BÁO CÁO GIÁM SÁT ĐẶC THÙ: {tram.TenTram.ToUpper()} - {tram.TinhThanh.ToUpper()}]");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"(*) Phân cấp địa lý: Vùng khó khăn Nhóm {tram.DoKhoKhanTheoPhanCap} | Khoảng cách tuyến huyện: {tram.KhoangCachDenBanhVienHuyenKm} km");
            Console.ResetColor();
            
            Console.WriteLine($"\n1. Đánh giá tiêu chí quốc gia năm 2026: {(tram.DatChuanQuocGia2026 ? "Đã đạt chuẩn ✔" : "CHƯA ĐẠT CHUẨN ❌ (Cần tập trung nguồn lực)")}");

            Console.WriteLine("\n2. Thực trạng hạ tầng và y tế từ xa:");
            Console.WriteLine($"  + Hiện trạng cơ sở: {tram.HaTang.TinhTrangPhongKham}");
            Console.WriteLine($"  + Ứng cứu khẩn cấp Telehealth: {(tram.CongNghe.CoHeThongKhamBenhTuXaTelehealth ? "SẴN SÀNG kết nối vệ tinh với tuyến Trung ương" : "Chưa kết nối")}");
            Console.WriteLine($"  + Giải pháp viễn thông: {(tram.GiaiPhapDacThu.SuDungGoiDienThoaiVienThongMienPhi ? "Đã cấp bù kinh phí đường truyền ưu tiên" : "Chưa hỗ trợ")}");

            Console.WriteLine("\n3. Khủng hoảng nhân lực và chính sách gỡ khó:");
            Console.WriteLine($"  + Số lượng bác sĩ cơ hữu tại trạm: {tram.NhanLuc.SoLuongBacSi} (Trạng thái: Tình trạng báo động trắng)");
            Console.WriteLine($"  + Giải pháp tình thế: {tram.GiaiPhapDacThu.MoHinhLuanPhienBacSi}");
            Console.WriteLine($"  + Chế độ ưu đãi: Phụ cấp nghề đạt {tram.ChinhSachDaiNgo.PhanTramPhuCapUuDaiNghe}%, {(tram.ChinhSachDaiNgo.CoHoTroNhaCongVu ? "Đã bố trí nhà công vụ cho cán bộ ở lại" : "Chưa có nhà ở công vụ")}");
            Console.WriteLine($"  + Cam kết địa phương: {tram.ChinhSachDaiNgo.ChinhSachThuHutRiengCuaTinh}");

            Console.WriteLine("\n4. Nguồn vốn đầu tư dự kiến:");
            Console.WriteLine($"  + Danh mục thụ hưởng: {tram.GiaiPhapDacThu.NguonVonUuTien}");
            Console.WriteLine("==================================================================================");
        }
    }

    #endregion

    // Lớp cơ sở (Base Class) được giữ lại từ cấu trúc trước để đảm bảo tính biên dịch
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
}
