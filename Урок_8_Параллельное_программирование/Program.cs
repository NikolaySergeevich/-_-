const int N = 1000; //размер матрицы
const int THREADS_NUMBER = 10; // кол-во потоков

int[,] serialMulRes = new int[N, N]; //результат выполнения умножения матриц в однопотоке
int[,] threadMulRes = new int[N, N]; //результат параллельного умножения матриц

int[,] firstMatrix = MatrixGenerator(N, N);
int[,] secondMatrix = MatrixGenerator(N, N);

SerialMatrixMul(firstMatrix, secondMatrix);
PrepareParallelMatrixMul(firstMatrix, secondMatrix);
Console.WriteLine(EqualityMatrix(serialMulRes, threadMulRes));



int[,] MatrixGenerator(int rows, int columns) // Создание и заполнение матрицы
{
    Random _rand = new Random();               //создание объекта рандомного заполнения
    int[,] res = new int[rows, columns];
    for (int i = 0; i < res.GetLength(0); i++)
    {
        for (int j = 0; j < res.GetLength(1); j++)
        {
            res[i, j] = _rand.Next(-100, 100);
        }
    }
    return res;
}

void SerialMatrixMul(int[,] a, int[,] b) //перемножение матриц
{
    if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Нельзя умножить такие матрицы");

    for (int i = 0; i < a.GetLength(0); i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                serialMulRes[i, j] += a[i, k] * b[k, j];
            }
        }
    }
}

void PrepareParallelMatrixMul(int[,] a, int[,] b) //готовит параллельные вычисления. распределяет по потокам
{
    if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Нельзя умножить такие матрицы");
    int eachThreadCalc = N / THREADS_NUMBER; // кол-во вычислений на отдельный поток
    Thread[] arr = new Thread[2];
    var threadsList = new List<Thread>(); //создали колекцию, в которой будут храниться потоки
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * eachThreadCalc; //для начала i-го потока
        int endPos = (i + 1) * eachThreadCalc;// для конца i-го потока
        //если последний поток
        if (i == THREADS_NUMBER - 1) endPos = N; //для последнего потока, он всебя доберает то, что в остатке при делении N на THREADS_NUMBER
        threadsList.Add(new Thread(() => ParallelMatrixMul(a, b, startPos, endPos))); // к колекции 'threadsList' добавляем 'Add' поток 'new Thread' и передаём в него функцию....
        threadsList[i].Start();
    }
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        threadsList[i].Join();
    }
}
// Получается, что каждый поток перемножает матрицу в своём диапазоне. А эти потоки запускаютя один за другим, но не последовательно,
// а пости одновременно, один за другим. Создался один поток(58 строка) и запустился(59 строка). Создаётся следующий поток и запускается,
// а предыдущий/ее могут ещё выполняться.

void ParallelMatrixMul(int[,] a, int[,] b, int startPos, int endPos) //перемножает матрицы в диапазоне startPos и endPos. 
{
    for (int i = startPos; i < endPos; i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                threadMulRes[i, j] += a[i, k] * b[k, j];
            }
        }
    }
}

bool EqualityMatrix(int[,] fmatrix, int[,] smatrix)// этот метот сравнивает две матрицы и выдаёт true или foals
{
    bool res = true;

    for (int i = 0; i < fmatrix.GetLength(0); i++)
    {
        for (int j = 0; j < fmatrix.GetLength(1); j++)
        {
            res = res && (fmatrix[i, j] == smatrix[i, j]);
        }
    }

    return res;
}

