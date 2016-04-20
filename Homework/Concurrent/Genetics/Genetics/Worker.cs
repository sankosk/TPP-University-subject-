
namespace Genetics
{

    internal class Worker
    {

        private int fromIndex, toIndex;

        private long result;
        private char[] vector;
        private char[] toFound;

        internal long Result
        {
            get { return this.result; }
        }

        internal char[] ToFound
        {
            get { return toFound; }

            set { toFound = value; }
        }

        public Worker(char[] vector, char[] toFound, int fromIndex, int toIndex)
        {
            this.vector = vector;
            this.toFound = toFound;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
        }

        internal void Compute()
        {
            this.result = 0;
            for (int i=fromIndex; i<=toIndex; i++) {
                int j = 0;  int aux = i;
                while (vector[aux].Equals(toFound[j])) {
                    j++;    aux++;
                    if(j == toFound.Length){ result++;   break; }
                }
            }

        }

    }

}
