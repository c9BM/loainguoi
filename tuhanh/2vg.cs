using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaVangTuHanh
{
    public class MainForm : Form
    {
        Label lblTitle;
        Label lblLevel;
        Label lblMerit;
        ProgressBar progress;

        Button btnMorning;
        Button btnLecture;
        Button btnMeditation;
        Button btnVolunteer;
        Button btnBreakthrough;

        TextBox txtLog;

        int merit = 0;
        int level = 0;

        string[] levels =
        {
            "Người Mới Tìm Hiểu",
            "Phật Tử Sơ Học",
            "Tinh Tấn",
            "Hộ Trì Tam Bảo",
            "Trưởng Thành Trong Tu Học"
        };

        public MainForm()
        {
            Text = "Hành Trình Tu Học";
            Width = 900;
            Height = 650;
            StartPosition = FormStartPosition.CenterScreen;

            lblTitle = new Label()
            {
                Text = "☸ HÀNH TRÌNH TU HỌC ☸",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                AutoSize = true,
                Top = 20,
                Left = 250
            };

            lblLevel = new Label()
            {
                Text = "Cấp độ: " + levels[level],
                Top = 80,
                Left = 20,
                Width = 500
            };

            lblMerit = new Label()
            {
                Text = "Điểm tinh tấn: 0",
                Top = 110,
                Left = 20,
                Width = 500
            };

            progress = new ProgressBar()
            {
                Top = 140,
                Left = 20,
                Width = 800,
                Height = 25,
                Maximum = 100
            };

            btnMorning = new Button()
            {
                Text = "🌅 Công phu sáng",
                Top = 190,
                Left = 20,
                Width = 180
            };

            btnLecture = new Button()
            {
                Text = "📖 Nghe pháp thoại",
                Top = 190,
                Left = 220,
                Width = 180
            };

            btnMeditation = new Button()
            {
                Text = "🧘 Thiền định",
                Top = 190,
                Left = 420,
                Width = 180
            };

            btnVolunteer = new Button()
            {
                Text = "🤝 Công quả",
                Top = 190,
                Left = 620,
                Width = 180
            };

            btnBreakthrough = new Button()
            {
                Text = "⭐ Tổng kết ngày tu",
                Top = 250,
                Left = 20,
                Width = 250
            };

            txtLog = new TextBox()
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Top = 300,
                Left = 20,
                Width = 830,
                Height = 280
            };

            btnMorning.Click += (s, e) =>
            {
                merit += 15;
                Log("Tham gia thời công phu sáng.");
                UpdateInfo();
            };

            btnLecture.Click += (s, e) =>
            {
                merit += 20;
                Log("Lắng nghe pháp thoại và học giáo lý.");
                UpdateInfo();
            };

            btnMeditation.Click += (s, e) =>
            {
                merit += 20;
                Log("Thực hành thiền định và quán chiếu.");
                UpdateInfo();
            };

            btnVolunteer.Click += (s, e) =>
            {
                merit += 25;
                Log("Tham gia công quả, hỗ trợ đại chúng.");
                UpdateInfo();
            };

            btnBreakthrough.Click += (s, e) =>
            {
                if (merit >= 80 && level < levels.Length - 1)
                {
                    level++;
                    merit = 0;

                    Log("Hoàn thành một giai đoạn tu học.");
                    Log("Tiếp tục rèn luyện giới - định - tuệ.");

                    UpdateInfo();
                }
                else
                {
                    Log("Tiếp tục tinh tấn trong học tập và thực hành.");
                }
            };

            Controls.Add(lblTitle);
            Controls.Add(lblLevel);
            Controls.Add(lblMerit);
            Controls.Add(progress);
            Controls.Add(btnMorning);
            Controls.Add(btnLecture);
            Controls.Add(btnMeditation);
            Controls.Add(btnVolunteer);
            Controls.Add(btnBreakthrough);
            Controls.Add(txtLog);

            Log("Khởi động chương trình mô phỏng một ngày tu học.");
        }

        void UpdateInfo()
        {
            lblMerit.Text = $"Điểm tinh tấn: {merit}";
            progress.Value = Math.Min(merit, 100);
            lblLevel.Text = $"Cấp độ: {levels[level]}";
        }

        void Log(string text)
        {
            txtLog.AppendText(
                $"[{DateTime.Now:HH:mm:ss}] {text}\r\n");
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}