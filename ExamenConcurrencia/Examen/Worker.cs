
using System;
namespace Examen
{

    internal class Worker
    {

        private int fromIndex, toIndex;

        private long result;
        private int[] vector;
        private int[] toFound;

        internal long Result
        {
            get { return this.result; }
        }

        internal int[] ToFound
        {
            get { return toFound; }

            set { toFound = value; }
        }

        public Worker(int[] vector, int[] toFound, int fromIndex, int toIndex)
        {
            this.vector = vector;
            this.toFound = toFound;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
        }

        internal void Compute()
        {
            this.result = 0;
            for (int i = fromIndex; i < Math.Max(vector.Length, toFound.Length); i+=toIndex){
                this.result += vector[i] * toFound[i];
            }

        }

    }

}
