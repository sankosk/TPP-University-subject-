using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntExtension
{

    public static class intExtension{

        public static int reverseNumber(this int num){
            //applying map -> return num.ToString().Reverse().Aggregate(0, (b, x) => 10 * b + x - '0');
           for (int result = 0; ; result = result * 10 + num % 10, num /= 10) if (num == 0) return result;
        }

        public static Boolean isPrime(this int number) {
            if (number < 2) return false;
            for (int i=2; i< number; i++) {
                if (number % i == 0) return false;
            }
            return true;
        }

        //Euclides rocks - found at google, improved/modified by me
        public static int mcd(this int number, int number2){
            int aux;

            if(number < 0 || number2 < 0) {
                number = Math.Abs(number);
                number2 = Math.Abs(number2);
            }

            int min = Math.Min(number, number2);
            int max=0;
            if (min == number)
                max = number2;

            do
            {
                aux = min;
                min = max % min;
                max = aux;
            } while (min != 0);

            return max;
        }

        public static int mcm(this int number, int number2){
            return (number/number2.mcd(number)*number2);
        }

        public static int concat(this int n, int n2) {
            return int.Parse(n.ToString()+n2.ToString());
        }

    }
}
