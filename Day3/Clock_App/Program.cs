
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Clock_App
{
    class Program
    {

        public static void Main(string[] args)
        {
            while (true)
            {

                    Thread.Sleep(1000);
                    Clock clock = new Clock();
                    clock.OnChangeSecondEvent += () => { System.Console.WriteLine(DateTime.Now.ToString()); };
                    clock.Fire();
               
            }
        }

    }
}