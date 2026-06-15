using System;
using System.Collections.Generic;

namespace VietnamBirthPolicy2026
{
    // 1. Định nghĩa các vùng mức sinh theo chính sách quốc gia
    public enum FertilityRegion
    {
        Low,       // Vùng mức sinh thấp (Ví dụ: TP.HCM, Đông Nam Bộ)
        High,      // Vùng mức sinh cao
        Substituted // Vùng mức sinh thay thế (Ổn định)
    }

    // 2. Lớp đại diện cho một Công dân/Cặp vợ chồng
    public class Citizen
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int CurrentChildrenCount { get; set; }
        public FertilityRegion ResidenceRegion { get; set; }
        public double MonthlyInsuranceSalary { get; set; } // Mức lương đóng BHXH (VNĐ)

        public Citizen(string name, int age, int currentChildrenCount, FertilityRegion region, double salary)
        {
            Name = name;
            Age = age;
            CurrentChildrenCount = currentChildrenCount;
            ResidenceRegion = region;
            MonthlyInsuranceSalary = salary;
        }
    }

    // 3. Hệ thống quản lý và tra cứu chính sách dân số mới nhất
    public class BirthPolicyManager
    {
        // Các hằng số định mức áp dụng cho giai đoạn năm 2026
        public const double BASE_SALARY = 2530000; // Mức tham chiếu/Lương cơ sở tạm tính (VNĐ)
        public const string EFFECTIVE_DATE = "01/07/2026"; // Ngày Luật Dân số 2025 có hiệu lực

        public void DisplayGeneralPolicy()
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine($"CHÍNH SÁCH SINH NỞ & DÂN SỐ VIỆT NAM (Áp dụng từ {EFFECTIVE_DATE})");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("* Quyền quyết định: Tự do lựa chọn số con, thời gian và khoảng cách sinh.");
            Console.WriteLine("* Thay đổi cốt lõi: CHÍNH THỨC BÃI BỎ quy định giới hạn 1-2 con trước đây.");
            Console.WriteLine("* Kỷ luật Đảng viên: Bãi bỏ hoàn toàn các hình thức xử lý kỷ luật khi sinh con thứ 3 trở lên.");
            Console.WriteLine("* Trọng tâm quốc gia: Khuyến khích mọi cặp vợ chồng sinh đủ 2 con để duy trì mức sinh thay thế.");
            Console.WriteLine("--------------------------------------------------------------------------\n");
        }

        public void EvaluateBenefits(Citizen citizen, bool isFemale)
        {
            Console.WriteLine($"--- TRA CỨU QUYỀN LỢI CHO: {citizen.Name} ({(isFemale ? "Nữ" : "Nam")}) ---");
            
            // Lần sinh này sẽ là đứa con thứ mấy
            int targetChildOrder = citizen.CurrentChildrenCount + 1;
            Console.WriteLine($"+ Trạng thái: Chuẩn bị sinh con thứ {targetChildOrder}");

            // 1. Kiểm tra chính sách hỗ trợ khuyến khích sinh (Áp dụng vùng sinh thấp & độ tuổi phụ nữ)
            if (isFemale && citizen.Age < 35 && targetChildOrder == 2)
            {
                Console.WriteLine("[KHUYẾN KHÍCH]: Đạt điều kiện thưởng tiền mặt tối thiểu 2.000.000 VNĐ (Phụ nữ sinh đủ 2 con trước 35 tuổi).");
                if (citizen.ResidenceRegion == FertilityRegion.Low)
                {
                    Console.WriteLine("[ĐỊA PHƯƠNG]: Được ưu tiên hỗ trợ mua/thuê nhà ở xã hội và gói quà tặng riêng của tỉnh/thành phố.");
                }
            }

            // 2. Tính toán chế độ thai sản theo Luật Dân số mới và Luật BHXH
            int leaveDays = 0;
            double allowanceOneTime = 2 * BASE_SALARY; // Trợ cấp một lần bằng 2 tháng lương cơ sở/tham chiếu
            double totalMaternitySalary = 0;

            if (isFemale)
            {
                // Lao động nữ sinh con thứ 2 được nghỉ 7 tháng theo Luật mới
                if (targetChildOrder == 2)
                {
                    leaveDays = 7 * 30; 
                    totalMaternitySalary = citizen.MonthlyInsuranceSalary * 7;
                    Console.WriteLine($"[THAI SẢN NỮ]: Nghỉ thai sản 07 THÁNG (Tăng thêm 1 tháng đối với con thứ hai).");
                }
                else
                {
                    leaveDays = 6 * 30;
                    totalMaternitySalary = citizen.MonthlyInsuranceSalary * 6;
                    Console.WriteLine($"[THAI SẢN NỮ]: Nghỉ thai sản 06 THÁNG theo quy định thông thường.");
                }
                Console.WriteLine($"+ Tiền trợ cấp thai sản hàng tháng (BHXH chi trả 100%): {totalMaternitySalary:N0} VNĐ");
                Console.WriteLine($"+ Trợ cấp thai sản 1 lần (đón con): {allowanceOneTime:N0} VNĐ");
            }
            else
            {
                // Chế độ dành cho người chồng khi vợ sinh con
                if (targetChildOrder == 2)
                {
                    leaveDays = 10; // Nghỉ 10 ngày làm việc nếu vợ sinh con thứ 2
                    Console.WriteLine("[THAI SẢN NAM]: Người chồng được nghỉ 10 ngày làm việc khi vợ sinh con thứ hai.");
                }
                else
                {
                    leaveDays = 5; // Sinh thường 1 con đầu, các trường hợp phẫu thuật/sinh đôi sẽ tăng thêm
                    Console.WriteLine("[THAI SẢN NAM]: Người chồng được nghỉ từ 5 đến 7 ngày làm việc (quy định thông thường).");
                }
                double maleAllowance = (citizen.MonthlyInsuranceSalary / 24) * leaveDays;
                Console.WriteLine($"+ Tiền trợ cấp BHXH chi trả cho số ngày nghỉ của chồng: {maleAllowance:N0} VNĐ");
            }

            // 3. Y tế kỹ thuật
            Console.WriteLine("[Y TẾ]: Được Nhà nước hỗ trợ/miễn giảm chi phí sàng lọc trước sinh và sàng lọc sơ sinh theo danh mục quy định.");
            Console.WriteLine();
        }
    }

    // 4. Chương trình chính để thực thi
    class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập hiển thị tiếng Việt có dấu trên Console
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            BirthPolicyManager manager = new BirthPolicyManager();
            
            // In thông tin tổng quan của luật mới
            manager.DisplayGeneralPolicy();

            // Khởi tạo dữ liệu giả lập cho 2 vợ chồng sống tại TP.HCM (Vùng mức sinh thấp)
            // Người vợ: 31 tuổi, đã có 1 con, lương đóng BHXH là 12,000,000đ
            Citizen vo = new Citizen("Nguyễn Thị A", 31, 1, FertilityRegion.Low, 12000000);
            
            // Người chồng: 33 tuổi, lương đóng BHXH là 15,000,000đ
            Citizen chong = new Citizen("Trần Văn B", 33, 1, FertilityRegion.Low, 15000000);

            // Xuất quyền lợi chi tiết khi sinh con thứ hai vào thời điểm luật mới có hiệu lực
            manager.EvaluateBenefits(vo, isFemale: true);
            manager.EvaluateBenefits(chong, isFemale: false);

            Console.ReadLine();
        }
    }
}
