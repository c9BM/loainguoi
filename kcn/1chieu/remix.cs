using System;
using System.Collections.Generic;
using System.Threading;

class DuongMotChieu
{
    const int DO_DAI_DUONG = 30;
    const int MAX_XE = 5;           // Số xe tối đa trên đường cùng lúc
    const int DELAY_MS = 300;       // Tốc độ mô phỏng

    static void Main(string[] args)
    {
        Console.Title = "Mô phỏng Đường Một Chiều - C#";
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Queue<int> duong = new Queue<int>(); // Vị trí của các xe
        Random rand = new Random();

        int thoiGian = 0;

        Console.WriteLine("=== MÔ PHỎNG ĐƯỜNG MỘT CHIỀU ===\n");
        Console.WriteLine("Nhấn ESC để thoát...\n");

        while (true)
        {
            // Xác suất xe mới vào (30%)
            if (duong.Count < MAX_XE && rand.Next(100) < 30)
            {
                duong.Enqueue(0); // Xe vào ở vị trí 0
            }

            // Di chuyển tất cả xe sang phải
            int soLuongXe = duong.Count;
            for (int i = 0; i < soLuongXe; i++)
            {
                int viTri = duong.Dequeue();
                viTri++;
                if (viTri < DO_DAI_DUONG)
                {
                    duong.Enqueue(viTri);
                }
                // Nếu viTri >= DO_DAI_DUONG thì xe ra khỏi đường
            }

            // Vẽ đường
            VeDuong(duong);

            thoiGian++;
            Console.WriteLine($"Thời gian: {thoiGian}s | Số xe trên đường: {duong.Count}");

            // Kiểm tra phím ESC để thoát
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape)
                    break;
            }

            Thread.Sleep(DELAY_MS);
        }

        Console.WriteLine("\nKết thúc mô phỏng!");
    }

    static void VeDuong(Queue<int> duong)
    {
        Console.Clear();
        Console.Write("→ ");

        char[] duongVe = new char[DO_DAI_DUONG];
        for (int i = 0; i < DO_DAI_DUONG; i++)
            duongVe[i] = '─';

        foreach (int pos in duong)
        {
            if (pos >= 0 && pos < DO_DAI_DUONG)
                duongVe[pos] = '🚗';
        }

        Console.Write(string.Join("", duongVe));
        Console.WriteLine(" → EXIT");
    }
}