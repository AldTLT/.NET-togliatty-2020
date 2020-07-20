using CoordinateFormatter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Write(Messages.CoordinateXIntro);
            var XStringFormat = Console.ReadLine();

            Console.Write(Messages.CoordinateYIntro);
            var YStringFormat = Console.ReadLine();

            var parseXResult = double.TryParse(XStringFormat, out double CoordinateX);
            var parseYResult = double.TryParse(YStringFormat, out double CoordinateY);

            if (!parseXResult || !parseYResult)
            {
                Console.WriteLine(Messages.IncorrectlyInsert);
                Console.ReadKey();
                return;
            }

            // Create instance of Coordinate class.
            var coordinate = new Coordinate(CoordinateX, CoordinateY);

            Console.WriteLine(coordinate.ToString());
            Console.ReadKey();
        }
    }
}
