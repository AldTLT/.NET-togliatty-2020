using System;

namespace Vector.UI
{
    /// <summary>
    /// Главный класс.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Главный метод.
        /// </summary>
        static void Main()
        {
            // Максимальный пункт меню для выбора.
            const int maxPunktNumber = 2;

            // Минимальныый пункт меню для выбора.
            const int minPunktNumber = 1;

            Console.WriteLine(Messages.Title);

            Console.Write($"\n{Messages.Input_Vector_First}");
            var firstVector = GetVectorFromConsole();

            if (firstVector == null)
            {
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"\n{Messages.Input_Vector_Second}");
            var secondVector = GetVectorFromConsole();

            if (secondVector == null)
            {
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"\n{Messages.Menu}\n{Messages.Menu_1}\n{Messages.Menu_2}");
            var punktMenuString = Console.ReadKey().KeyChar.ToString();

            var parseOk = int.TryParse(punktMenuString, out int punktMenu);

            if (!parseOk || punktMenu > maxPunktNumber || punktMenu < minPunktNumber)
            {
                Console.WriteLine($"\n{Messages.Message_IncorrectPunkt}");
            }
            else
            {
                var resultOfOperation = punktMenu == 1 ? firstVector + secondVector : firstVector - secondVector;
                Console.WriteLine($"{Messages.Output_Result} {resultOfOperation}");
            }            

            Console.ReadKey();
        }

        /// <summary>
        /// Метод возвращает вектор, координаты которого введенны с консоли.
        /// </summary>
        /// <returns>Вектор.</returns>
        static Vector GetVectorFromConsole()
        {
            Console.Write($"\n{Messages.Input_Vector_X} ");
            var coordXString = Console.ReadLine();
            var parseXOk = double.TryParse(coordXString, out double coordX);

            Console.Write($"{Messages.Input_Vector_Y} ");
            var coordYString = Console.ReadLine();
            var parseYOk = double.TryParse(coordYString, out double coordY);

            Console.Write($"{Messages.Input_Vector_Z} ");
            var coordZString = Console.ReadLine();
            var parseZOk = double.TryParse(coordZString, out double coordZ);

            if (!parseXOk || !parseYOk || !parseZOk)
            {
                Console.WriteLine(Messages.Message_IncorrectInput);
                return null;
            }

            return new Vector(coordX, coordY, coordZ);
        }
    }
}
