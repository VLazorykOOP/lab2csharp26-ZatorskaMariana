using System;

class Tests
{
    public static void RunTest()
    {
        double[] arr = { 1, 5, 10, 15, 20 };

        double expected = 30;

        double actual = Program.SumInRange(arr, 5, 15);

        if (actual == expected)
        {
            Console.WriteLine("Тест пройдено успішно");
        }
        else
        {
            Console.WriteLine("Тест НЕ пройдено");
            Console.WriteLine($"Очікувалось: {expected}");
            Console.WriteLine($"Отримано: {actual}");
        }
    }
}
