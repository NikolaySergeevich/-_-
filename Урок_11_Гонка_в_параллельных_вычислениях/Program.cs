const int THREADS_NUMBER = 4; //число потоков
const int N = 100000; //размер массива
object lock_object = new object();

//сортировка подсчетом
//int[] array = {-10, -5, -9, 0, 2, 5, 1, 3, 1, 0, 1};
//int[] sortedArray = CountingSortExtended(array);
Random rand = new Random(); // рандомная переменная
int[] resSerial = new int[N].Select(r => rand.Next(0, 5)).ToArray();// N - размер массива; r => rand.Next(0, 5) - через рандомную
                                                                // переменную задаётся значение от 0 до 5 и передаётся в переменную r;
                                                                // r передётся в массив; ToArray() - приводит всё это к обычному массиву.
                                                                // r объявлять не нужно
int[] resParallel = new int[N];

Array.Copy(resSerial, resParallel, N); // копирует массив resSerial и вставляет его в resParallel. Теперь каждый массив занимает свою
                                    // ячейку памяти. Через присвоение не нужно, потому что будет ссылка

//Console.WriteLine(string.Join(", ", resSerial));

CountingSortExtended(resSerial);
PrepareParallelCountingSort(resParallel);
Console.WriteLine(EqualityMatrix(resSerial, resParallel));

//Console.WriteLine(string.Join(", ", resSerial));
//Console.WriteLine(string.Join(", ", resParallel));



void PrepareParallelCountingSort(int[] inputArray)
{
    int max = inputArray.Max();
    int min = inputArray.Min();

    int offset = -min;
    int[] counters = new int[max + offset + 1];

    int eachThreadCalc = N / THREADS_NUMBER;
    var threadsParall = new List<Thread>();

    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * eachThreadCalc;
        int endPos = (i + 1) * eachThreadCalc;
        if (i == THREADS_NUMBER - 1) endPos = N;
        threadsParall.Add(new Thread(() => CountingSortParallel(inputArray, counters, offset, startPos, endPos)));
        threadsParall[i].Start();
    }

    foreach(var thread in threadsParall)
    {
        thread.Join();
    }

    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            inputArray[index] = i - offset;
            index++;
        }
    }
}


void CountingSortParallel(int[] inputArray, int[] counters, int offset, int startPos, int endPos)//метод заполняющий дополнительный массив
                                                                                                //через свой поток
{
    for (int i = startPos; i < endPos; i++)
    {
        lock (lock_object) //не допускает "гонки" потоков. Пока один поток работает с кодом в скобках, то остальные потоки ждут,
                        // если они тоже в это время хотят с этим кодом порабоать
        {
            counters[inputArray[i] + offset]++;
        }
    }
}

void CountingSortExtended(int[] inputArray)// обычная сортировка подсчётом
{
    int max = inputArray.Max();
    int min = inputArray.Min();

    int offset = -min;
    int[] counters = new int[max + offset + 1];


    for (int i = 0; i < inputArray.Length; i++)
    {
        counters[inputArray[i] + offset]++;
    }

    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            inputArray[index] = i - offset;
            index++;
        }
    }
}

bool EqualityMatrix(int[] fmatrix, int[] smatrix) //метод сравнивания массивов
{
    bool res = true;

    for (int i = 0; i < N; i++)
    {
        res = res && (fmatrix[i] == smatrix[i]);
    }

    return res;
}