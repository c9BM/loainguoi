using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationCalculator
{
    // ============ 1. DATA MODELS ============
    public class SelectionProblem
    {
        public int TotalItems { get; set; }          // Tổng số lựa chọn (N)
        public int SelectCount { get; set; }         // Số lượng cần chọn mỗi ngày (K)
        public long TotalCombinations { get; set; }  // Tổng số cách chọn (C(N,K))
        public List<List<string>> SampleCombinations { get; set; } // Mẫu các tổ hợp
        public string Description { get; set; }
        public TimeSpan CalculationTime { get; set; }
    }

    public class SelectionResult
    {
        public List<SelectionProblem> Problems { get; set; }
        public DateTime GeneratedAt { get; set; }
        public string Summary { get; set; }
    }

    // ============ 2. COMBINATION CALCULATOR ============
    public class CombinationCalculator
    {
        // Tính số tổ hợp chập K của N: C(N,K) = N! / (K! * (N-K)!)
        public long CalculateCombinations(int n, int k)
        {
            if (k < 0 || k > n) return 0;
            if (k == 0 || k == n) return 1;
            
            // Tối ưu: chọn K nhỏ hơn để giảm số lần tính
            k = Math.Min(k, n - k);
            
            long result = 1;
            for (int i = 1; i <= k; i++)
            {
                result = result * (n - k + i) / i;
            }
            return result;
        }

        // Sinh các tổ hợp (dùng cho mẫu nhỏ)
        public List<List<int>> GenerateCombinations(int n, int k, int maxSamples = 5)
        {
            var results = new List<List<int>>();
            if (k > n || k <= 0) return results;

            int[] combination = new int[k];
            for (int i = 0; i < k; i++)
                combination[i] = i;

            int count = 0;
            while (count < maxSamples)
            {
                results.Add(new List<int>(combination));
                count++;

                // Tìm vị trí có thể tăng
                int pos = k - 1;
                while (pos >= 0 && combination[pos] == n - k + pos)
                    pos--;

                if (pos < 0) break;

                combination[pos]++;
                for (int i = pos + 1; i < k; i++)
                    combination[i] = combination[i - 1] + 1;
            }

            return results;
        }

        // Giải bài toán cho từng trường hợp
        public SelectionProblem SolveProblem(int n, int k, string description)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            
            var problem = new SelectionProblem
            {
                TotalItems = n,
                SelectCount = k,
                Description = description,
                TotalCombinations = CalculateCombinations(n, k)
            };

            // Sinh mẫu các tổ hợp (tối đa 5 mẫu)
            var combos = GenerateCombinations(n, k, 5);
            problem.SampleCombinations = combos.Select(c => 
                string.Join(", ", c.Select(x => $"Lựa chọn {x + 1}"))
            ).ToList();

            stopwatch.Stop();
            problem.CalculationTime = stopwatch.Elapsed;

            return problem;
        }
    }

    // ============ 3. MAIN PROGRAM ============
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=" .PadRight(80, '='));
            Console.WriteLine("🧮 CHƯƠNG TRÌNH TÍNH TOÁN SỐ LỰA CHỌN TỔ HỢP");
            Console.WriteLine("=" .PadRight(80, '='));
            Console.WriteLine();

            var calculator = new CombinationCalculator();
            var results = new SelectionResult
            {
                Problems = new List<SelectionProblem>(),
                GeneratedAt = DateTime.Now
            };

            // ============ CÁC KỊCH BẢN ============
            
            // Kịch bản 1: 5 lựa chọn, mỗi ngày chọn 10 (KHÔNG HỢP LỆ)
            Console.WriteLine("📌 KỊCH BẢN 1: N = 5, K = 10");
            Console.WriteLine("   ⚠️ Lưu ý: Không thể chọn 10 từ 5 lựa chọn!");
            var problem1 = calculator.SolveProblem(5, 10, "5 lựa chọn, chọn 10 mỗi ngày (không khả thi)");
            results.Problems.Add(problem1);
            PrintProblem(problem1);
            Console.WriteLine();

            // Kịch bản 2: 10 lựa chọn, mỗi ngày chọn 5
            Console.WriteLine("📌 KỊCH BẢN 2: N = 10, K = 5");
            Console.WriteLine("   ✅ Hợp lệ: Chọn 5 từ 10 lựa chọn mỗi ngày");
            var problem2 = calculator.SolveProblem(10, 5, "10 lựa chọn, chọn 5 mỗi ngày");
            results.Problems.Add(problem2);
            PrintProblem(problem2);
            Console.WriteLine();

            // Kịch bản 3: 10 lựa chọn, mỗi ngày chọn 10 (chọn tất cả)
            Console.WriteLine("📌 KỊCH BẢN 3: N = 10, K = 10");
            Console.WriteLine("   ✅ Hợp lệ: Chọn tất cả 10 mỗi ngày");
            var problem3 = calculator.SolveProblem(10, 10, "10 lựa chọn, chọn 10 mỗi ngày (chọn hết)");
            results.Problems.Add(problem3);
            PrintProblem(problem3);
            Console.WriteLine();

            // Kịch bản 4: 15 lựa chọn, mỗi ngày chọn 5
            Console.WriteLine("📌 KỊCH BẢN 4: N = 15, K = 5");
            Console.WriteLine("   ✅ Hợp lệ: Chọn 5 từ 15 lựa chọn mỗi ngày");
            var problem4 = calculator.SolveProblem(15, 5, "15 lựa chọn, chọn 5 mỗi ngày");
            results.Problems.Add(problem4);
            PrintProblem(problem4);
            Console.WriteLine();

            // Kịch bản 5: 15 lựa chọn, mỗi ngày chọn 10
            Console.WriteLine("📌 KỊCH BẢN 5: N = 15, K = 10");
            Console.WriteLine("   ✅ Hợp lệ: Chọn 10 từ 15 lựa chọn mỗi ngày");
            var problem5 = calculator.SolveProblem(15, 10, "15 lựa chọn, chọn 10 mỗi ngày");
            results.Problems.Add(problem5);
            PrintProblem(problem5);
            Console.WriteLine();

            // Kịch bản 6: 15 lựa chọn, mỗi ngày chọn 15 (chọn tất cả)
            Console.WriteLine("📌 KỊCH BẢN 6: N = 15, K = 15");
            Console.WriteLine("   ✅ Hợp lệ: Chọn tất cả 15 mỗi ngày");
            var problem6 = calculator.SolveProblem(15, 15, "15 lựa chọn, chọn 15 mỗi ngày (chọn hết)");
            results.Problems.Add(problem6);
            PrintProblem(problem6);
            Console.WriteLine();

            // ============ TỔNG KẾT ============
            results.Summary = GenerateSummary(results);
            Console.WriteLine("=" .PadRight(80, '='));
            Console.WriteLine("📊 TỔNG KẾT KẾT QUẢ");
            Console.WriteLine("=" .PadRight(80, '='));
            Console.WriteLine(results.Summary);
            Console.WriteLine();

            Console.WriteLine($"🕐 Thời gian tạo báo cáo: {results.GeneratedAt:dd/MM/yyyy HH:mm:ss}");
            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }

        static void PrintProblem(SelectionProblem problem)
        {
            Console.WriteLine($"   📊 Tổng số cách chọn: {problem.TotalCombinations:N0}");
            Console.WriteLine($"   ⏱️ Thời gian tính toán: {problem.CalculationTime.TotalMilliseconds:F2} ms");
            
            if (problem.SampleCombinations.Count > 0 && problem.TotalCombinations > 0)
            {
                Console.WriteLine($"   📝 Mẫu 5 tổ hợp đầu tiên:");
                foreach (var sample in problem.SampleCombinations)
                {
                    Console.WriteLine($"      • {sample}");
                }
            }
            else if (problem.TotalCombinations == 0)
            {
                Console.WriteLine("   ⚠️ Không có tổ hợp hợp lệ!");
            }
        }

        static string GenerateSummary(SelectionResult result)
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            
            // Bảng so sánh
            sb.AppendLine("┌─────────────┬──────────────┬──────────────────────┬─────────────┐");
            sb.AppendLine("│ Tổng (N)    │ Chọn mỗi ngày│ Số cách chọn (C(N,K))│ Hợp lệ?     │");
            sb.AppendLine("│             │ (K)          │                      │             │");
            sb.AppendLine("├─────────────┼──────────────┼──────────────────────┼─────────────┤");

            foreach (var p in result.Problems)
            {
                string valid = p.TotalCombinations > 0 ? "✅ Có" : "❌ Không";
                sb.AppendLine($"│ {p.TotalItems,11} │ {p.SelectCount,12} │ {p.TotalCombinations,20:N0} │ {valid,11} │");
            }

            sb.AppendLine("└─────────────┴──────────────┴──────────────────────┴─────────────┘");
            sb.AppendLine();

            // Phân tích kết quả
            sb.AppendLine("📌 PHÂN TÍCH:");
            sb.AppendLine($"   • Với 10 lựa chọn, chọn 5 mỗi ngày: {result.Problems[1].TotalCombinations:N0} cách");
            sb.AppendLine($"   • Với 15 lựa chọn, chọn 5 mỗi ngày: {result.Problems[3].TotalCombinations:N0} cách");
            sb.AppendLine($"   • Với 15 lựa chọn, chọn 10 mỗi ngày: {result.Problems[4].TotalCombinations:N0} cách");
            sb.AppendLine();

            // Giải thích công thức
            sb.AppendLine("📐 CÔNG THỨC TỔ HỢP:");
            sb.AppendLine("   C(N,K) = N! / (K! × (N-K)!)");
            sb.AppendLine("   Trong đó: N = Tổng số lựa chọn, K = Số lượng cần chọn");
            sb.AppendLine();
            sb.AppendLine("   ⚡ Nếu N < K: Không thể chọn, kết quả = 0");
            sb.AppendLine("   ⚡ Nếu K = 0 hoặc K = N: Chỉ có 1 cách chọn");

            return sb.ToString();
        }
    }
}