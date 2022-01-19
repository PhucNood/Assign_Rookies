
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PrimeApp
{

    class Program
    {

        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            List<int> list = GetListPrimeNumber(0,100).Result;
            foreach (int i in list){
                System.Console.Write("{0} ",i);
                
            }
            System.Console.WriteLine();
            System.Console.WriteLine("Total number of prime numbers {0}\n time: {1} ms", list.Count,sw.ElapsedMilliseconds);



        }


        private static async Task<List<int>> GetListPrimeNumber(int min, int max)
        {
            List<int> primeNumbers = new List<int>();
            return await Task.Run(() =>
            {

                for (int i = min; i < max; i++)
                {
                    if(isPrime(i)) primeNumbers.Add(i);;
                   
                }
                return primeNumbers;
            });
            
        }




        private static bool isPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }


    }

}


