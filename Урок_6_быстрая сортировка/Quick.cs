using static Reconstrucktion;
public static class Quick
{
    public static int[] QuickSort(int[] arr, int left, int rights)
    {
        if (left >= rights)
        {
            return arr;
        }
        int pivot = Shoy_pivot(arr, left, rights);
        QuickSort(arr, left, pivot - 1);
        QuickSort(arr, pivot + 1, rights);
        return arr;
    }
}