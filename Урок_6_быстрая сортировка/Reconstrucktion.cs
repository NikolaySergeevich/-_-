public static class Reconstrucktion
{

    public static int[] CreatMas( int size)
    {
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = new Random().Next(1, 10);
        }
        return array;
    }
    public static void PrintMas( int[] mas)
    {
        Console.WriteLine($"[{String.Join(", ", mas)}]");
    }
    public static int Shoy_pivot(int[] ar, int left, int rights)
    {
        int pivot = left - 1;
        int temp = 0;
        for (int i = left; i < rights; i++)
        {
            if (ar[i] < ar[rights])
            {
                pivot++;
                temp = ar[pivot];
                ar[pivot] = ar[i];
                ar[i] = temp;
            }
        }
        pivot++;
        temp = ar[pivot];
        ar[pivot] = ar[rights];
        ar[rights] = temp;
        return pivot;
    }

}