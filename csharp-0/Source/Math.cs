using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
            List<int> fibonnaci = new List<int>();

            int x = 0;
            int y = 1;

            fibonnaci.Add(x);
            fibonnaci.Add(y);

            while (x + y <= 350)
            {
                int auxX = x;
                int auxY = y;

                x = auxY;
                y = auxX + auxY;

                fibonnaci.Add(y);
            }

            return fibonnaci;
        }

        public bool IsFibonacci(int numberToTest)
        {
            List<int> fibonnaci = Fibonacci();

            foreach (int number in fibonnaci)
            {
                Console.WriteLine(number);
                if (number == numberToTest)
                {
                    return true;
                }
            }

            return false;
        }
    }
}


