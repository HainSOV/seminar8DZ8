// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)
void PrintMassive(int[,,] matrix)
{
    for (int k = 0; k < 2; k++)
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.Write(" " + matrix[i, j, k]);
            }
        }
        Console.WriteLine();
    }
}

int[,,] GenerateMassive(int[] array)
{
    int size = array.Length;
    int[,,] matrix = new int[2,2,2];
    for (int i = 0; i < 2; i++)
    {
        for (int j = 0; j < 2; j++)
        {
            for (int k = 0; k < 2; k++)
            {
                int l = new Random().Next(1, size); // метод Фишера-Йетса
                matrix[i, j, k] = array[l];
                array[size-1]= array[l];
                size--;
            }
        }
    }
    return matrix;
}

int[] array = Enumerable.Range(10, 90).ToArray();// Создан массив с 1 до 100

int[,,] matrix = GenerateMassive(array);
PrintMassive(matrix);