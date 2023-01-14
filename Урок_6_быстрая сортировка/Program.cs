using static Reconstrucktion;
using static Quick;

Console.WriteLine("Введите размер массива");
int sizeze = int.Parse(Console.ReadLine()!);

int[] mass = CreatMas(sizeze);
PrintMas(mass);
Console.WriteLine();
QuickSort(mass, 0, mass.Length - 1);
PrintMas(mass);
//////////////////////////////////////////////////////////



