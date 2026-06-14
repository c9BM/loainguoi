using System;
using System.Drawing;
using System.Windows.Forms;

namespace DaoHuuTuHanh
{
    public class MainForm : Form
    {
        private Label lblTitle;
        private Label lblRealm;
        private Label lblVirtue;
        private Button btnMeditate;
        private Button btnReadScripture;
        private Button btnBreakthrough;
        private TextBox txtLog;

        private int virtue = 0;
        private int realm = 1;

        private readonly string[] realms =
        {
            "Phàm Nhân",
            "Luyện Khí",
            "Trúc Cơ",
            "Kim Đan",
            "Nguyên Anh",
            "Hóa Thần",
            "Độ Kiếp",
            "Phi Thăng"
        };

        public MainForm()
        {
            Text = "Đạo Hữu Tu Hành";
            Width = 800;
            Height = 600;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(30, 30, 40);

            lblTitle = new Label
            {
                Text = "☯ HỆ THỐNG TU HÀNH ☯",
                ForeColor = Color.Gold,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(220, 20)
            };

            lblRealm = new Label
            {
                Text = $"Cảnh Giới: {realms[realm - 1]}",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12),
                AutoSize = true,
                Location = new Point(30, 90)
            };

            lblVirtue = new Label
            {
                Text = $"Công Đức: {virtue}",
                ForeColor = Color.LightGreen,
                Font = new Font("Segoe UI", 12),
                AutoSize = true,
                Location = new Point(30, 130)
            };

            btnMeditate = new Button
            {
                Text = "🧘 Tĩnh Tâm",
                Size = new Size(150, 50),
                Location = new Point(30, 180)
            };

            btnReadScripture = new Button
            {
                Text = "📜 Đọc Kinh",
                Size = new Size(150, 50),
                Location = new Point(200, 180)
            };

            btnBreakthrough = new Button
            {
                Text = "⚡ Đột Phá",
                Size = new Size(150, 50),
                Location = new Point(370, 180)
            };

            txtLog = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Location = new Point(30, 260),
                Size = new Size(720, 260),
                BackColor = Color.Black,
                ForeColor = Color.LawnGreen,
                Font = new Font("Consolas", 10)
            };

            btnMeditate.Click += (s, e) =>
            {
                virtue += 10;
                UpdateInfo();
                Log("Đạo hữu tĩnh tâm một canh giờ, công đức +10.");
            };

            btnReadScripture.Click += (s, e) =>
            {
                virtue += 20;
                UpdateInfo();
                Log("Đạo hữu lĩnh ngộ kinh văn cổ, công đức +20.");
            };

            btnBreakthrough.Click += (s, e) =>
            {
                int required = realm * 100;

                if (virtue >= required && realm < realms.Length)
                {
                    virtue -= required;
                    realm++;

                    UpdateInfo();
                    Log($"🌟 Đột phá thành công! Tiến vào cảnh giới {realms[realm - 1]}.");
                }
                else
                {
                    Log($"❌ Công đức chưa đủ. Cần {required} công đức để đột phá.");
                }
            };

            Controls.Add(lblTitle);
            Controls.Add(lblRealm);
            Controls.Add(lblVirtue);
            Controls.Add(btnMeditate);
            Controls.Add(btnReadScripture);
            Controls.Add(btnBreakthrough);
            Controls.Add(txtLog);

            Log("Chào mừng đạo hữu bước vào con đường tu hành.");
        }

        private void UpdateInfo()
        {
            lblVirtue.Text = $"Công Đức: {virtue}";
            lblRealm.Text = $"Cảnh Giới: {realms[realm - 1]}";
        }

        private void Log(string message)
        {
            txtLog.AppendText(
                $"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}