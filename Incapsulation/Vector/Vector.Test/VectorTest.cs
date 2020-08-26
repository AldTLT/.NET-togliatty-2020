using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vector.Test
{
    /// <summary>
    /// Класс представляет тесты класса Vector.
    /// </summary>
    [TestClass]
    public class VectorTest
    {
        /// <summary>
        /// Первый экземпляр вектора для тестирования.
        /// </summary>
        private Vector firstVector;

        /// <summary>
        /// Второй экземпляр вектора для тестирования.
        /// </summary>
        private Vector secondVector;

        /// <summary>
        /// Инициализация векторов.
        /// </summary>
        [TestInitialize]
        public void InitializeVectors()
        {
            firstVector = new Vector(12.5, -3, 67.715);
            secondVector = new Vector(5.6, 39.34, -4.8);
        }

        /// <summary>
        /// Тест проверяет корректность координат вектора.
        /// </summary>
        [TestMethod]
        public void VectorCoordinates_Test()
        {
            var vector = new Vector(2, -56.7, 0.43452);

            Assert.AreEqual(2, vector.X);
            Assert.AreEqual(-56.7, vector.Y);
            Assert.AreEqual(0.43452, vector.Z);
        }

        /// <summary>
        /// Тест проверяет метод Equals класса Vector.
        /// </summary>
        [TestMethod]
        public void Vector_Equals_Test()
        {
            var vectorToEqual = new Vector(5.6, 39.34, -4.8);

            Assert.IsFalse(vectorToEqual.Equals(firstVector));
            Assert.IsTrue(vectorToEqual.Equals(secondVector));
        }

        /// <summary>
        /// Тест проверяет корректность сложения двух векторов.
        /// </summary>
        [TestMethod]
        public void Vector_OperationAdd_Test()
        {
            var expectedVector = new Vector(18.1, 36.34, 62.915);
            var vectorOfAddOperation = firstVector + secondVector;
            var vectorOfAddOperationChanged = secondVector + firstVector;

            Assert.AreEqual(expectedVector, vectorOfAddOperation);
            Assert.AreEqual(expectedVector, vectorOfAddOperationChanged);
        }

        /// <summary>
        /// Тест проверяет корректность вычитания двух векторов.
        /// </summary>
        [TestMethod]
        public void Vector_OperationSub_Test()
        {
            var expectedVector = new Vector(6.9, -42.34, 72.515);
            var vectorOfAddOperation = firstVector - secondVector;

            Assert.AreEqual(expectedVector, vectorOfAddOperation);
        }
    }
}
