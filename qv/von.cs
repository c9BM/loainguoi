using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapitalManager
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool IsIncome { get; set; }
    }

    public class MainForm : Form
    {
        private decimal currentCapital = 10000000m;

        private Label lblCapital;
        private Label lblRevenue;
        private Label lblExpense;
        private Label lblProfit;

        private TextBox txtDescription;
        private TextBox txtAmount;

        private Button btnIncome;
        private Button btnExpense;
        private Button btnReset;

        private DataGridView grid;

        private List<Transaction> transactions =
            new List<Transaction>();

        public MainForm()
        {
            InitializeUI();
            UpdateStatistics();
        }

        private void InitializeUI()
        {
            Text = "Quản Lý Quay Vòng Vốn";
            Width = 1100;
            Height = 700;
            StartPosition = FormStartPosition.CenterScreen;

            Font = new Font("Segoe UI", 10);

            lblCapital = new Label
            {
                Left = 20,
                Top = 20,
                Width = 500
            };

            lblRevenue = new Label
            {
                Left = 20,
                Top = 50,
                Width = 500
            };

            lblExpense = new Label
            {
                Left = 20,
                Top = 80,
                Width = 500
            };

            lblProfit = new Label
            {
                Left = 20,
                Top = 110,
                Width = 500
            };

            Controls.Add(lblCapital);
            Controls.Add(lblRevenue);
            Controls.Add(lblExpense);
            Controls.Add(lblProfit);

            Label lblDesc = new Label
            {
                Text = "Mô tả",
                Left = 20,
                Top = 170
            };

            txtDescription = new TextBox
            {
                Left = 100,
                Top = 165,
                Width = 250
            };

            Label lblAmt = new Label
            {
                Text = "Số tiền",
                Left = 380,
                Top = 170
            };

            txtAmount = new TextBox
            {
                Left = 450,
                Top = 165,
                Width = 150
            };

            btnIncome = new Button
            {
                Text = "➕ Thu",
                Left = 620,
                Top = 160,
                Width = 100
            };

            btnExpense = new Button
            {
                Text = "➖ Chi",
                Left = 730,
                Top = 160,
                Width = 100
            };

            btnReset = new Button
            {
                Text = "Làm Mới",
                Left = 840,
                Top = 160,
                Width = 120
            };

            Controls.Add(lblDesc);
            Controls.Add(txtDescription);

            Controls.Add(lblAmt);
            Controls.Add(txtAmount);

            Controls.Add(btnIncome);
            Controls.Add(btnExpense);
            Controls.Add(btnReset);

            grid = new DataGridView
            {
                Left = 20,
                Top = 230,
                Width = 1030,
                Height = 380,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill
            };

            grid.Columns.Add("Date", "Ngày");
            grid.Columns.Add("Desc", "Mô tả");
            grid.Columns.Add("Type", "Loại");
            grid.Columns.Add("Amount", "Số tiền");

            Controls.Add(grid);

            btnIncome.Click += AddIncome;
            btnExpense.Click += AddExpense;
            btnReset.Click += ResetData;
        }

        private void AddIncome(object sender, EventArgs e)
        {
            AddTransaction(true);
        }

        private void AddExpense(object sender, EventArgs e)
        {
            AddTransaction(false);
        }

        private void AddTransaction(bool income)
        {
            if (!decimal.TryParse(
                txtAmount.Text,
                out decimal amount))
            {
                MessageBox.Show(
                    "Số tiền không hợp lệ");
                return;
            }

            Transaction t = new Transaction
            {
                Date = DateTime.Now,
                Description = txtDescription.Text,
                Amount = amount,
                IsIncome = income
            };

            transactions.Add(t);

            if (income)
                currentCapital += amount;
            else
                currentCapital -= amount;

            grid.Rows.Add(
                t.Date.ToString("dd/MM/yyyy HH:mm"),
                t.Description,
                income ? "Thu" : "Chi",
                amount.ToString("N0"));

            txtDescription.Clear();
            txtAmount.Clear();

            UpdateStatistics();
        }

        private void UpdateStatistics()
        {
            decimal revenue =
                transactions
                .Where(x => x.IsIncome)
                .Sum(x => x.Amount);

            decimal expense =
                transactions
                .Where(x => !x.IsIncome)
                .Sum(x => x.Amount);

            decimal profit =
                revenue - expense;

            lblCapital.Text =
                $"Vốn hiện tại: {currentCapital:N0} VNĐ";

            lblRevenue.Text =
                $"Tổng thu: {revenue:N0} VNĐ";

            lblExpense.Text =
                $"Tổng chi: {expense:N0} VNĐ";

            lblProfit.Text =
                $"Lợi nhuận: {profit:N0} VNĐ";
        }

        private void ResetData(
            object sender,
            EventArgs e)
        {
            var result =
                MessageBox.Show(
                    "Xóa toàn bộ dữ liệu?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                transactions.Clear();
                grid.Rows.Clear();

                currentCapital = 10000000m;

                UpdateStatistics();
            }
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(
                new MainForm());
        }
    }
}