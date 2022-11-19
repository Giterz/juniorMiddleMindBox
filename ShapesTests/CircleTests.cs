using System;
using ShapesLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShapesTests
{
    [TestClass]
    public class CircleTests
    {
        /// <summary>
        /// Тест на вычисление площади круга
        /// </summary>
        [TestMethod]
        public void Add_R_10_ReturnCorrectResult()
        {
            //Arrange
            double r = 10;
            double expected = 314.15926535897933;
            //Act
            Circle circle = new Circle(r);
            double actual = circle.GetArea();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Тест на ввод отрицательного радиуса
        /// </summary>
        [TestMethod]
        public void Add_NegativeArgument_ThrowsArgumentException()
        {
            //Assert
            Assert.ThrowsException<ArgumentException>(() => new Circle(-15));
        }
    }
}
