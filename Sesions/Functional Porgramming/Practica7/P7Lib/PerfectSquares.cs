using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7Lib
{
    public class PerfectSquares
    {

        public bool IsPerfectSquare(int n) {
            return (n == Math.Sqrt(n*n));
        }

        public IEnumerable<int> EagerPerfectSquares(int from, int to) {
            int n = 1, counter = 0;
            while (counter < from) {
                if (IsPerfectSquare(n))
                    counter++;
                n++;
            }

            IList<int> result = new List<int>();
            counter = 0;
            while (counter < to)
            {
                if (IsPerfectSquare(n))
                {
                    counter++;
                    result.Add(n);
                }
                n++;
            }
            return result;

        }

        public IEnumerable<int> LazyPerfectSquaresGenerator() {
            int n = 1;
            while(true){
                if (IsPerfectSquare(n))
                    yield return n;
                n++;
            }
        }

        public IEnumerable<int> LazyPerfectSquares(int from, int toTake) {
            return LazyPerfectSquaresGenerator().Skip(from).Take(toTake);
        }
    }
}
