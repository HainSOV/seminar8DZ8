// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

void PrintArray2D(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j].ToString("D2")} ");
        }
        Console.WriteLine();
    }
}

int[,] CreateAndFillArraySpiralize2D(int rows, int columns)
{
    int[,] array = new int[rows, columns];
    int size = rows * columns;
    int number = 1; 
    int currentRow = 0;
    int currentColumn = 0;
    int currentDirection = 0;
    int[] directions = { 0, 1, 0, -1, 0 }; // вправо, вниз, влево, вверх, вправо

    while (number <= size) // заполняем, пока число не превысит размер массива
    {
        array[currentRow, currentColumn] = number;
        number++;

        // Определяем следующую ячейку в зависимости от текущего направления
        int nextRow = currentRow + directions[currentDirection];
        int nextColumn = currentColumn + directions[currentDirection + 1];

        // Проверяем, достигли ли границы массива или уже заполнили ячейку
        if (nextRow < 0 || nextRow >= rows || nextColumn < 0 ||
            nextColumn >= columns || array[nextRow, nextColumn] != 0)
        {
            // Изменяем направление движения по часовой стрелке
            currentDirection = (currentDirection + 1) % 4;
        }
        currentRow += directions[currentDirection];
        currentColumn += directions[currentDirection + 1];
    }
    return array;
}

int PromptNumber(string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int m = PromptNumber("Введите количество строк: ");
int n = PromptNumber("Введите количество столбцов: ");
int[,] matrix = CreateAndFillArraySpiralize2D(m, n);
Console.WriteLine("Сгенерирован спирально заполненный массив:");
PrintArray2D(matrix);