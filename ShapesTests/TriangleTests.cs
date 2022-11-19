using System;
using ShapesLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShapesTests
{
    [TestClass]
    public class TriangleTests
    {
        /// <summary>
        /// Тест на вычисление площади треугольника
        /// </summary>
        [TestMethod]
        public void Add_Sides_3_4_5_ReturnCorrectResult()
        {
            //Arrange
            double a = 3;
            double b = 4;
            double c = 5;
            double expected = 6;
            //Act
            Triangle triangle = new Triangle(a, b, c);
            double actual = triangle.GetArea();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Тест на определение прямоугольного прямоугольника
        /// </summary>
        [TestMethod]
        public void Add_Sides_3_4_5_ReturnTrue()
        {
            //Arrange
            double a = 3;
            double b = 4;
            double c = 5;
            //Act
            Triangle triangle = new Triangle(a, b, c);
            //Assert
            Assert.IsTrue(triangle.IsRectangular());
        }

        /// <summary>
        /// Тест на ввод аргументов
        /// </summary>
        [TestMethod]
        public void Add_NegativeArgument_ThrowsArgumentException()
        {
            //Assert
            Assert.ThrowsException<ArgumentException>(() => new Triangle(-3, 4, 5));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(3, -4, 5));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(3, 4, -5));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(3, 4, 0));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(0, 4, 5));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(3, 0, 5));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(3, 7, 10));
        }
    }
}
