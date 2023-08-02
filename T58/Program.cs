// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int[,] ProducTwoMatrix(int[,] matrix1, int[,] matrix2)
{
    int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++) // цикл перебирает строки первой матрицы
    {
        for (int j = 0; j < matrix2.GetLength(1); j++) // цикл перебирает столбцы второй матрицы
        {
            for (int k = 0; k < matrix1.GetLength(1); k++) // цикл выполняет суммирование произведений элементов
            {
                result[i, j] += matrix1[i, k] * matrix2[k, j];
            }
        }
    }
    return result;
}

void PrintArray2D(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
}

int[,] GenerateRandomArray2D(int rows, int columns, int from, int to)
{
    int[,] array = new int[rows, columns];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(from, to);
        }
    }
    return array;
}

int PromptNumber(string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int rows1 = PromptNumber("Введите количество строк 1-й матрицы: ");
int cols1 = PromptNumber("Введите количество столбцов 1-й матрицы: ");
int rows2 = PromptNumber(@"Введите количество строк 2-й матрицы.
Оно должно быть равно количеству столбцов для 1-й матрицы: "); // {Environment.NewLine} перенос строки
int cols2 = PromptNumber("Введите количество столбцов 2-й матрицы: ");
Console.WriteLine();
if (cols1 != rows2)
{
    Console.WriteLine(@"Количество строк 2-й матрицы должно быть равно количеству столбцов 1-й!
Повторите ввод.");
    return;
}
int[,] mas1 = GenerateRandomArray2D(rows1, cols1, 1, 10);
int[,] mas2 = GenerateRandomArray2D(rows2, cols2, 1, 10);
int[,] resultMas = ProducTwoMatrix(mas1, mas2);
Console.WriteLine("Первая матрица");
PrintArray2D(mas1);
Console.WriteLine();
Console.WriteLine("Вторая матрица");
PrintArray2D(mas2);
Console.WriteLine();
Console.WriteLine("Результирующая матрица");
PrintArray2D(resultMas);