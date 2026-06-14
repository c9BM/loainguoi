using System;

namespace LifeSimulation
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name)
        {
            Name = name;
            Age = 0;
        }

        public void LiveYear()
        {
            Console.WriteLine($"Năm {Age}: {GetLifeEvent(Age)}");
            Age++;
        }

        private string GetLifeEvent(int age)
        {
            return age switch
            {
                0 => "Chào đời.",
                1 => "Tập đi và tập nói.",
                3 => "Bắt đầu khám phá thế giới.",
                6 => "Vào lớp 1.",
                10 => "Học tiểu học.",
                15 => "Học trung học.",
                18 => "Tốt nghiệp THPT.",
                22 => "Tốt nghiệp đại học hoặc học nghề.",
                25 => "Bắt đầu sự nghiệp.",
                30 => "Ổn định công việc và cuộc sống.",
                35 => "Tích lũy kinh nghiệm và tài sản.",
                40 => "Đạt nhiều thành tựu trong nghề nghiệp.",
                45 => "Định hướng tương lai lâu dài.",
                50 => "Bước sang tuổi 50 với nhiều trải nghiệm.",
                _ when age < 6 => "Lớn lên từng ngày.",
                _ when age < 18 => "Học tập và phát triển bản thân.",
                _ when age < 25 => "Chuẩn bị cho cuộc sống trưởng thành.",
                _ when age < 35 => "Xây dựng sự nghiệp.",
                _ when age < 50 => "Phát triển và duy trì cuộc sống.",
                _ => "Tiếp tục hành trình cuộc đời."
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Nguyen Van A");

            Console.WriteLine("=== MÔ PHỎNG CUỘC ĐỜI ===\n");

            while (person.Age <= 50)
            {
                person.LiveYear();
            }

            Console.WriteLine("\nKết thúc mô phỏng đến năm 50 tuổi.");
        }
    }
}