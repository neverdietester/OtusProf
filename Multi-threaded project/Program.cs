using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] arraySizes = { 100000, 1000000, 10000000 };
        foreach (var size in arraySizes)
        {
            int[] numbers = GenerateRandomArray(size);
            MeasureExecutionTimes(numbers);
        }
    }

    static int[] GenerateRandomArray(int size)
    {
        Random rand = new Random();
        return Enumerable.Range(1, size).Select(_ => rand.Next(1, 100)).ToArray();
    }

    static void MeasureExecutionTimes(int[] numbers)
    {
        Stopwatch stopwatch = new Stopwatch();

        // Sequential Sum
        stopwatch.Start();
        int sequentialSum = numbers.Sum();
        stopwatch.Stop();
        Console.WriteLine($"Sequential Sum: {sequentialSum}, Time: {stopwatch.ElapsedMilliseconds} ms");

        // Parallel Sum with Threads
        stopwatch.Restart();
        int threadSum = ParallelSumWithThreads(numbers);
        stopwatch.Stop();
        Console.WriteLine($"Thread Sum: {threadSum}, Time: {stopwatch.ElapsedMilliseconds} ms");

        // Parallel Sum with LINQ
        stopwatch.Restart();
        int linqSum = numbers.AsParallel().Sum();
        stopwatch.Stop();
        Console.WriteLine($"LINQ Sum: {linqSum}, Time: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine();
    }

    static int ParallelSumWithThreads(int[] numbers)
    {
        int numThreads = Environment.ProcessorCount;
        int length = numbers.Length;
        int blockSize = length / numThreads;
        int[] partialSums = new int[numThreads];
        Thread[] threads = new Thread[numThreads];

        for (int i = 0; i < numThreads; i++)
        {
            int start = i * blockSize;
            int end = (i == numThreads - 1) ? length : start + blockSize;
            int threadIndex = i; 

            threads[i] = new Thread(() =>
            {
                int sum = 0;
                for (int j = start; j < end; j++)
                {
                    sum += numbers[j];
                }
                partialSums[threadIndex] = sum;
            });

            threads[i].Start();
        }

        foreach (var thread in threads)
        {
            thread.Join(); 
        }

        return partialSums.Sum(); 
    }
}