using System;
using System.Threading;

namespace Examen
{

    public class Master
    {

        private int numberOfThreads;
        private int[] vector;


        public Master(int[] vector, int numberOfThreads)
        {
            if (numberOfThreads < 1 || numberOfThreads > vector.Length)
                throw new ArgumentException("The number of threads must be lower or equal to the number of elements in the vector.");
            this.vector = vector;
            this.numberOfThreads = numberOfThreads;
        }

        public double ComputeModulus(int[] toFound)
        {
            Worker[] workers = new Worker[this.numberOfThreads];
            int itemsPerThread = this.vector.Length / numberOfThreads;
            for (int i = 0; i < this.numberOfThreads; i++)
                workers[i] = new Worker(this.vector,
                    toFound,
                    i, numberOfThreads);

            Thread[] threads = new Thread[workers.Length];
            for (int i = 0; i < workers.Length; i++)
            {
                threads[i] = new Thread(workers[i].Compute);
                threads[i].Name = "Worker Count " + (i + 1);
                threads[i].Priority = ThreadPriority.BelowNormal;
                threads[i].Start();
            }

            for (int i = 0; i < workers.Length; i++)
            {
                threads[i].Join();
            }

            long result = 0;
            foreach (Worker worker in workers)
            {
                result += worker.Result;
            }
            return result;
        }

    }

}
