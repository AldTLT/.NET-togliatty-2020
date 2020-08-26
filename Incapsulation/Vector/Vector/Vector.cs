﻿using System;

namespace Vector
{
    /// <summary>
    /// Класс Вектор.
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// Кол-во разрядов после запятой, до которого округляются координаты в результате операйций.
        /// Значение выбрано произвольно.
        /// </summary>
        const int round = 6;

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
            var sumX = Math.Round((vector1.X + vector2.X), round);
            var sumY = Math.Round((vector1.Y + vector2.Y), round);
            var sumZ = Math.Round((vector1.Z + vector2.Z), round);

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
            var sumX = Math.Round((vector.X + number), round);
            var sumY = Math.Round((vector.Y + number), round);
            var sumZ = Math.Round((vector.Z + number), round);

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

        /// <summary>
        /// Метод возвращает результат вычитания двух векторов.
        /// </summary>
        /// <param name="vector1">Уменьшаемый вектор.</param>
        /// <param name="vector2">Вычитаемый вектор.</param>
        /// <returns>Вектор, являющийся разностью двух векторов.</returns>
        public static Vector operator -(Vector vector1, Vector vector2)
        {
            var divX = Math.Round((vector1.X - vector2.X), round);
            var divY = Math.Round((vector1.Y - vector2.Y), round);
            var divZ = Math.Round((vector1.Z - vector2.Z), round);

            return new Vector(divX, divY, divZ);
        }

        /// <summary>
        /// Метод возвращает результат вычитания числа из вектора.
        /// </summary>
        /// <param name="vector">Уменьшаемый вектор.</param>
        /// <param name="number">Число которое вычитается из вектора.</param>
        /// <returns>Вектор, являющийся разностью вектора с числом.</returns>
        public static Vector operator -(Vector vector, double number)
        {
            var divX = Math.Round((vector.X - number), round);
            var divY = Math.Round((vector.Y - number), round);
            var divZ = Math.Round((vector.Z - number), round);

            return new Vector(divX, divY, divZ);
        }

        /// <summary>
        /// Метод возвращает строковое представление вектора.
        /// </summary>
        /// <returns>Строковое представление вектора.</returns>
        public override string ToString()
        {
            return $"X:{this.X} Y:{this.Y} Z:{this.Z}";
        }

        /// <summary>
        /// Метод определяет эквивалентен ли объект экземпляру Vector.
        /// </summary>
        /// <param name="obj">Объект для проверки на эквивалентность.</param>
        /// <returns>true если объект - Vector и имеет те же значения, иначе - false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var vectorToEqual = obj as Vector;

            return X == vectorToEqual.X && Y == vectorToEqual.Y && Z == vectorToEqual.Z;
        }

        /// <summary>
        /// Метод возвращает хэш-код вектора.
        /// </summary>
        /// <returns>Хэш-код вектора.</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
