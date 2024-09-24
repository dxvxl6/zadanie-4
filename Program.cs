using System.Diagnostics;

namespace zadanie_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) // Бесконечный цикл для повторного выбора действия
            {
                Console.WriteLine("Выберите действия :");
                Console.WriteLine("1. Вывести текущий процесс.");
                Console.WriteLine("2. Получить id процессов, который представляют запущенные экземпляры Visual Studio.");
                Console.WriteLine("3. Получить все запущенные процессы.");
                Console.WriteLine("4. Выход.");
                Console.Write("Введите номер действия: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        var current_process = Process.GetCurrentProcess();
                        Console.WriteLine($"Id: {current_process.Id}");
                        Console.WriteLine($"Name: {current_process.ProcessName}");
                        Console.WriteLine($"VirtualMemory: {current_process.VirtualMemorySize64}");
                        break;

                    case "2":
                        Process[] vsProcs = Process.GetProcessesByName("devenv");
                        if (vsProcs.Length > 0)
                        {
                            foreach (var proc in vsProcs)
                            {
                                Console.WriteLine($"ID: {proc.Id}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Запущенные экземпляры Visual Studio не найдены.");
                        }
                        break;

                    case "3":
                        foreach (Process process in Process.GetProcesses())
                        {
                            Console.WriteLine($"ID: {process.Id}  Name: {process.ProcessName}");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Выход из программы.");
                        return;

                    default:
                        Console.WriteLine("Неверный ввод. Пожалуйста, попробуйте снова.");
                        break;
                }

                Console.WriteLine(); // Печатаем пустую строку для разделения выводов
            }
        }
    }
}
