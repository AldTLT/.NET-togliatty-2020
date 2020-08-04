using System;

namespace GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "a";

            while(true)
            {
                Console.WriteLine(s.Length);
                s += s;
            }
        }
    }
}
