using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== ЛАБОРАТОРНА РОБОТА =====");
            Console.WriteLine("1 - Завдання 1 (інтервал)");
            Console.WriteLine("2 - Завдання 2 (між min і max)");
            Console.WriteLine("3 - Завдання 3 (2D масив, рядки)");
            Console.WriteLine("4 - Завдання 4 (східчастий масив)");
            Console.WriteLine("0 - Вихід");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": Task1(); break;
                case "2": Task2(); break;
                case "3": Task3(); break;
                case "4": Task4(); break;
                case "0": return;
                default: Console.WriteLine("Невірний вибір"); break;
            }

            Console.WriteLine("\nНатисніть Enter...");
            Console.ReadLine();
        }
    }

    // ================= ЗАВДАННЯ 1 =================
    static void Task1()
    {
        Console.Write("Розмір масиву: ");
        int n = int.Parse(Console.ReadLine());

        double[] arr = new double[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"arr[{i}] = ");
            arr[i] = double.Parse(Console.ReadLine());
        }

        Console.Write("Початок інтервалу: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Кінець інтервалу: ");
        double b = double.Parse(Console.ReadLine());

        double sum = 0;

        for (int i = 0; i < n; i++)
        {
            if (arr[i] >= a && arr[i] <= b)
                sum += arr[i];
        }

        Console.WriteLine($"Сума: {sum}");
    }

    // ================= ЗАВДАННЯ 2 =================
    static void Task2()
    {
        Console.Write("Розмір масиву: ");
        int n = int.Parse(Console.ReadLine());

        double[] arr = new double[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"arr[{i}] = ");
            arr[i] = double.Parse(Console.ReadLine());
        }

        double min = arr[0], max = arr[0];
        int minI = 0, maxI = 0;

        for (int i = 1; i < n; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
                minI = i;
            }
            if (arr[i] > max)
            {
                max = arr[i];
                maxI = i;
            }
        }

        if (maxI > minI)
        {
            Console.WriteLine("Максимальний елемент пізніше мінімального!");
        }
        else
        {
            double sum = 0;
            for (int i = maxI + 1; i < minI; i++)
                sum += arr[i];

            Console.WriteLine($"Сума між ними: {sum}");
        }
    }

    // ================= ЗАВДАННЯ 3 =================
    static void Task3()
    {
        Console.Write("Розмір n (n x n): ");
        int n = int.Parse(Console.ReadLine());

        int[,] arr = new int[n, n];

        // Ввід
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"[{i},{j}] = ");
                arr[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Якщо парна кількість рядків
        if (n % 2 == 0)
        {
            for (int i = 0; i < n; i += 2)
            {
                for (int j = 0; j < n; j++)
                {
                    int temp = arr[i, j];
                    arr[i, j] = arr[i + 1, j];
                    arr[i + 1, j] = temp;
                }
            }
        }

        // Вивід
        Console.WriteLine("Результат:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(arr[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    // ================= ЗАВДАННЯ 4 =================
    static void Task4()
    {
        Console.Write("Кількість рядків: ");
        int n = int.Parse(Console.ReadLine());

        int[][] arr = new int[n][];

        // Ввід східчастого масиву
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Скільки елементів у рядку {i}: ");
            int m = int.Parse(Console.ReadLine());

            arr[i] = new int[m];

            for (int j = 0; j < m; j++)
            {
                Console.Write($"[{i}][{j}] = ");
                arr[i][j] = int.Parse(Console.ReadLine());
            }
        }

        // Знаходимо максимальну кількість стовпців
        int maxCols = 0;
        for (int i = 0; i < n; i++)
            if (arr[i].Length > maxCols)
                maxCols = arr[i].Length;

        int[] result = new int[maxCols];

        for (int j = 0; j < maxCols; j++)
        {
            result[j] = -1;

            for (int i = n - 1; i >= 0; i--)
            {
                if (j < arr[i].Length && arr[i][j] % 2 != 0)
                {
                    result[j] = i;
                    break;
                }
            }
        }

        Console.WriteLine("Результат:");
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine($"Стовпець {i}: рядок {result[i]}");
        }
    }
}
