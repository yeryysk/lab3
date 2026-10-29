using System;

class Program
{
    static void PrintMatrix(int[,] a)
    {
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
                Console.Write(a[i, j] + "\t");

            Console.WriteLine();
        }
    }

    static void Transpose(int[,] a)
    {
        int n = a.GetLength(0);

        for (int i = 0; i < n; i++)
            for (int j = i + 1; j < n; j++)
            {
                int temp = a[i, j];
                a[i, j] = a[j, i];
                a[j, i] = temp;
            }
    }

    static void FindSaddlePoints(int[,] a)
    {
        int rows = a.GetLength(0);
        int cols = a.GetLength(1);
        bool found = false;

        for (int i = 0; i < rows; i++)
        {
            int min = a[i, 0];
            int col = 0;

            for (int j = 1; j < cols; j++)
                if (a[i, j] < min)
                {
                    min = a[i, j];
                    col = j;
                }

            bool saddle = true;

            for (int k = 0; k < rows; k++)
                if (a[k, col] > min)
                    saddle = false;

            if (saddle)
            {
                Console.WriteLine(
                    $"Седловая точка: {min}, " +
                    $"строка {i + 1}, столбец {col + 1}");
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("Седловых точек нет.");
    }

    static void Main()
    {
        int[,] a =
        {
            { 12, 14, 11, 15 },
            { 8, 10, 6, 9 },
            { 20, 22, 19, 25 },
            { 5, 7, 4, 6 }
        };

        Console.WriteLine("Исходная матрица:");
        PrintMatrix(a);

        Console.WriteLine("\nСедловые точки:");
        FindSaddlePoints(a);

        Console.WriteLine("\nТранспонированная матрица:");
        Transpose(a);
        PrintMatrix(a);
    }
}
