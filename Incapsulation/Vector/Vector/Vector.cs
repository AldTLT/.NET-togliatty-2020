using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    /// <summary>
    /// Класс Вектор.
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// Координата X вектора
        /// </summary>
        public double X { get; private set; }

        /// <summary>
        /// Координата Y вектора
        /// </summary>
        public double Y { get; private set; }

        /// <summary>
        /// Координата Z вектора
        /// </summary>
        public double Z { get; private set; }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Метод возвращает результат суммирования двух векторов.
        /// </summary>
        /// <param name="vector1">Первый вектор для суммирования.</param>
        /// <param name="vector2">Второй вектор для суммирования.</param>
        /// <returns>Вектор, являющийся суммой двух векторов.</returns>
        public static Vector operator +(Vector vector1, Vector vector2)
        {
            var sumX = vector1.X + vector2.X;
            var sumY = vector1.Y + vector2.Y;
            var sumZ = vector1.Z + vector2.Z;

            return new Vector(sumX, sumY, sumZ);
        }

        /// <summary>
        /// Метод возвращает результат суммирования вектора с числом.
        /// </summary>
        /// <param name="vector">Вектор с которым суммируется число.</param>
        /// <param name="number">Число для суммирования с вектором.</param>
        /// <returns>Вектор, являющийся суммой вектора с числом.</returns>
        public static Vector operator +(Vector vector, double number)
        {
            var sumX = vector.X + number;
            var sumY = vector.Y + number;
            var sumZ = vector.Z + number;

            return new Vector(sumX, sumY, sumZ);
        }

        /// <summary>
        /// Метод возвращает результат суммирования вектора с числом.
        /// </summary>
        /// <param name="number">Число для суммирования с вектором.</param>
        /// <param name="vector">Вектор с которым суммируется число.</param>
        /// <returns>Вектор, являющийся суммой вектора с числом.</returns>
        public static Vector operator +(double number, Vector vector)
        {
            return vector + number;
        }
    }
}
