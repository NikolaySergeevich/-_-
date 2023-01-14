// ------------------------------------МОЙ МЕТОД ПУЗЫРЬКОМ-----------------------------
Console.WriteLine("Введите размер массива");
int size = int.Parse(Console.ReadLine()!);

int[] Massiv = new int[size];
for (int i = 0; i < size; i++)
{
    Console.WriteLine("Введите значение элемента массива");
    Massiv[i] = int.Parse(Console.ReadLine()!);
}
Console.WriteLine($"Массив: [{String.Join(", ", Massiv)}]");
int temp = 0;
for (int j = 0; j < size - 1; j++)
{
    if (Massiv[j + 1] < Massiv[j])
    {
        temp = Massiv[j];
        Massiv[j] = Massiv[j + 1];
        Massiv[j + 1] = temp;
        j = -1;
        Console.WriteLine($"Массив ткущий: [{String.Join(", ", Massiv)}]");
    }
}

Console.WriteLine($"Массив: [{String.Join(", ", Massiv)}]");

//-----------------------------------------МЕТОД ПУЗЫРЬКОМ------------------ 

// Console.WriteLine("Введите размер массива");
// int size = int.Parse(Console.ReadLine()!);

// int[] Massiv = new int[size];
// for (int i = 0; i < size; i++)
// {
//     Console.WriteLine("Введите значение элемента массива");
//     Massiv[i] = int.Parse(Console.ReadLine()!);
// }
// Console.WriteLine($"Массив: [{String.Join(", ", Massiv)}]");
// int temp = 0;
// for (int i = 0; i < size; i++)
// {
//     for (int j = 0; j < size - 1 - i; j++) //отнимаем i потому что при каждом проходе
// 										  //максимальное число становится в конец и его 
// 										  //при следующих проходах можно не сравнивать 
//     {
//         if (Massiv[j + 1] < Massiv[j])
//         {
//             temp = Massiv[j];
//             Massiv[j] = Massiv[j + 1];
//             Massiv[j + 1] = temp;
//             Console.WriteLine($"Массив ткущий: [{String.Join(", ", Massiv)}]");
//         }
//     }
// }


// Console.WriteLine($"Массив: [{String.Join(", ", Massiv)}]");