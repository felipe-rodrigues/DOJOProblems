using System;
using System.Collections.Generic;

namespace ShortestPath1ToN
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfTests = int.Parse(Console.ReadLine());

            var ends = new List<int>();
            
            for(int i =0; i< numberOfTests; i++)
            {
                ends.Add(int.Parse(Console.ReadLine()));
            }


            var results = new List<int>();
            foreach (var item in ends)
            {
                var n = item;
                var count = 0;
                while(n > 1)
                {
                    if(n % 3 ==0)
                    {
                        n /= 3;
                    }
                    else
                    {
                        n--;     
                    }
                    count++;
                }

                results.Add(count);
            }


            results.ForEach(r =>
            {
                Console.WriteLine($"> {r}");
            });
        }
    }
}
