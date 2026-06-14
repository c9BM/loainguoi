using System;
using System.Collections.Generic;

namespace FutureMedicalTechnology
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("========================================");
            Console.WriteLine("HỆ THỐNG CÔNG NGHỆ Y TẾ HIỆN ĐẠI");
            Console.WriteLine("========================================");

            var technologies = new List<IMedicalTechnology>
            {
                new AIImaging(),
                new ElectronicHealthRecord(),
                new SurgicalRobot(),
                new HealthIoT(),
                new GenomeSequencing(),
                new Telemedicine(),
                new Bioprinting3D(),
                new StemCellTherapy(),
                new DigitalTwin(),
                new SmartHospital(),
                new DrugDiscoveryAI(),
                new Nanomedicine(),
                new WearableHealthDevice(),
                new RemoteMonitoring(),
                new MedicalBigData(),
                new ARVRMedicalTraining(),
                new SmartAmbulance(),
                new PrecisionMedicine(),
                new MedicalBlockchain(),
                new PredictiveHealthcare()
            };

            foreach (var tech in technologies)
            {
                tech.ShowInfo();
                Console.WriteLine(new string('-', 60));
            }

            Console.WriteLine("Hoàn thành mô phỏng.");
            Console.ReadKey();
        }
    }

    interface IMedicalTechnology
    {
        void ShowInfo();
    }

    class AIImaging : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("AI CHẨN ĐOÁN HÌNH ẢNH");
            Console.WriteLine("- Phân tích X-Ray, CT, MRI.");
            Console.WriteLine("- Hỗ trợ phát hiện sớm ung thư.");
        }
    }

    class ElectronicHealthRecord : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("HỒ SƠ BỆNH ÁN ĐIỆN TỬ");
            Console.WriteLine("- Lưu trữ lịch sử điều trị.");
            Console.WriteLine("- Đồng bộ dữ liệu bệnh viện.");
        }
    }

    class SurgicalRobot : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("ROBOT PHẪU THUẬT");
            Console.WriteLine("- Hỗ trợ phẫu thuật chính xác.");
            Console.WriteLine("- Giảm thời gian hồi phục.");
        }
    }

    class HealthIoT : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("IOT Y TẾ");
            Console.WriteLine("- Theo dõi nhịp tim.");
            Console.WriteLine("- Theo dõi SpO2 và huyết áp.");
        }
    }

    class GenomeSequencing : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("GIẢI TRÌNH TỰ GEN");
            Console.WriteLine("- Phân tích DNA.");
            Console.WriteLine("- Điều trị cá thể hóa.");
        }
    }

    class Telemedicine : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("KHÁM BỆNH TỪ XA");
            Console.WriteLine("- Tư vấn trực tuyến.");
            Console.WriteLine("- Theo dõi bệnh nhân từ xa.");
        }
    }

    class Bioprinting3D : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("IN 3D SINH HỌC");
            Console.WriteLine("- In mô sinh học.");
            Console.WriteLine("- Nghiên cứu cơ quan nhân tạo.");
        }
    }

    class StemCellTherapy : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("TẾ BÀO GỐC");
            Console.WriteLine("- Tái tạo mô.");
            Console.WriteLine("- Hỗ trợ điều trị bệnh mãn tính.");
        }
    }

    class DigitalTwin : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("DIGITAL TWIN");
            Console.WriteLine("- Mô phỏng cơ thể bệnh nhân.");
            Console.WriteLine("- Dự đoán kết quả điều trị.");
        }
    }

    class SmartHospital : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("BỆNH VIỆN THÔNG MINH");
            Console.WriteLine("- Tự động hóa quy trình.");
            Console.WriteLine("- Quản lý thiết bị bằng AI.");
        }
    }

    class DrugDiscoveryAI : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("AI NGHIÊN CỨU THUỐC");
            Console.WriteLine("- Phân tích hàng triệu hợp chất.");
            Console.WriteLine("- Rút ngắn thời gian phát triển thuốc.");
        }
    }

    class Nanomedicine : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("Y HỌC NANO");
            Console.WriteLine("- Vận chuyển thuốc chính xác.");
            Console.WriteLine("- Điều trị mục tiêu.");
        }
    }

    class WearableHealthDevice : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("THIẾT BỊ ĐEO THÔNG MINH");
            Console.WriteLine("- Đồng hồ đo sức khỏe.");
            Console.WriteLine("- Cảnh báo bất thường.");
        }
    }

    class RemoteMonitoring : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("GIÁM SÁT TỪ XA");
            Console.WriteLine("- Theo dõi bệnh nhân 24/7.");
            Console.WriteLine("- Gửi dữ liệu lên đám mây.");
        }
    }

    class MedicalBigData : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("BIG DATA Y TẾ");
            Console.WriteLine("- Phân tích dữ liệu lớn.");
            Console.WriteLine("- Hỗ trợ dự báo dịch bệnh.");
        }
    }

    class ARVRMedicalTraining : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("AR/VR Y TẾ");
            Console.WriteLine("- Đào tạo bác sĩ.");
            Console.WriteLine("- Mô phỏng ca phẫu thuật.");
        }
    }

    class SmartAmbulance : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("XE CẤP CỨU THÔNG MINH");
            Console.WriteLine("- Truyền dữ liệu thời gian thực.");
            Console.WriteLine("- Kết nối trực tiếp bệnh viện.");
        }
    }

    class PrecisionMedicine : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("Y HỌC CHÍNH XÁC");
            Console.WriteLine("- Điều trị theo đặc điểm cá nhân.");
            Console.WriteLine("- Tăng hiệu quả điều trị.");
        }
    }

    class MedicalBlockchain : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("BLOCKCHAIN Y TẾ");
            Console.WriteLine("- Bảo vệ hồ sơ bệnh án.");
            Console.WriteLine("- Chia sẻ dữ liệu an toàn.");
        }
    }

    class PredictiveHealthcare : IMedicalTechnology
    {
        public void ShowInfo()
        {
            Console.WriteLine("Y TẾ DỰ BÁO");
            Console.WriteLine("- Dự đoán nguy cơ bệnh.");
            Console.WriteLine("- Phòng ngừa sớm.");
        }
    }
}