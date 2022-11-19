using System;

namespace ShapesLib
{
    /// <summary>
    /// Абстрактный класс "Геометрическая фигура"
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Тип фигуры
        /// </summary>
        public abstract string ShapeType { get; }

        /// <summary>
        /// Вычисление площади геометрической фигуры
        /// </summary>
        /// <returns>Площадь геометрической фигуры</returns>
        public abstract double GetArea();

        /// <summary>
        /// Информация о фигуре (для переопределения)
        /// </summary>
        /// <returns>Строкое описание фигуры</returns>
        public virtual string GetInfo()
        {
            return ShapeType;
        }
    }

    /// <summary>
    /// Треугольник
    /// </summary>
    public class Triangle : Shape
    {
        /*public enum TriangleType
        {
            Rectangular,
            SharpAngled,
            ObtuseAngle            
        }*/

        /// <summary>
        /// Тип треугольника
        /// </summary>
        public struct TriangleType
        {
            public const string Rectangular = "Прямоугольный";
            public const string SharpAngled = "Остроугольный";
            public const string ObtuseAngle = "Тупоугольный";
        }

        #region Реализация доступа к полям через методы

        private double SideA { get; set; }
        private double SideB { get; set; }
        private double SideC { get; set; }

        public override string ShapeType
        {
            get
            {
                return GetTriangleType() + " треугольник";
                //if (IsRectangular()) return "Прямоугольный треугольник";
                //else return "Треугольник";
            }
        }

        //Getters
        public double GetSizeA()
        {
            return SideA;
        }
        public double GetSizeB()
        {
            return SideB;
        }
        public double GetSizeC()
        {
            return SideC;
        }
        #endregion               

        /// <summary>
        /// Реализация треугольника по 3-м сторонам
        /// </summary>
        /// <param name="sideA">Первая сторона</param>
        /// <param name="sideB">Вторая сторона</param>
        /// <param name="sideC">Третья сторона</param>
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Стороны треугольника должны быть больше 0");
            }
            else if ((sideA >= sideB + sideC) || (sideB >= sideA + sideC) || (sideC >= sideA + sideB))
            {
                throw new ArgumentException("Треугольник с такими сторонами не может существовать");
            }
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        #region Методы класса
        /// <summary>
        /// Проверка на то, является ли треугольник прямоугольным
        /// </summary>
        /// <returns>True or False</returns>
        public bool IsRectangular()
        {
            double[] ar = new[] { SideA, SideB, SideC };
            Array.Sort(ar);
            if (Math.Pow(ar[2], 2) == (Math.Pow(ar[0], 2) + Math.Pow(ar[1], 2)))
                return true;
            else return false;
        }

        /// <summary>
        /// Определение типа треугольника 
        /// </summary>
        /// <returns>Тип треугольника</returns>
        public string GetTriangleType()
        {
            double[] ar = new[] { SideA, SideB, SideC };
            Array.Sort(ar);
            if (Math.Pow(ar[2], 2) == (Math.Pow(ar[0], 2) + Math.Pow(ar[1], 2)))
                return TriangleType.Rectangular;
            else if (Math.Pow(ar[2], 2) > (Math.Pow(ar[0], 2) + Math.Pow(ar[1], 2)))
                return TriangleType.ObtuseAngle;
            else return TriangleType.SharpAngled;
        }

        /// <summary>
        /// Формула Герона
        /// </summary>
        /// <returns>Площадь треугольника</returns>
        public override double GetArea() =>
            Math.Sqrt(CalculateSemiperimeter(SideA, SideB, SideC) * (CalculateSemiperimeter(SideA, SideB, SideC) - SideA) * (CalculateSemiperimeter(SideA, SideB, SideC) - SideB) * (CalculateSemiperimeter(SideA, SideB, SideC) - SideC));

        /// <summary>
        /// Вычисление полупериметра треугольника
        /// </summary>
        /// <param name="a">Первая сторона</param>
        /// <param name="b">Вторая сторона</param>
        /// <param name="c">Третья сторона</param>
        /// <returns>Полупериметр треугольника</returns>
        private double CalculateSemiperimeter(double a, double b, double c) => (a + b + c) / 2;

        /// <summary>
        /// Описание реализованного треугольника
        /// </summary>
        /// <returns>Строковое описание треугольника</returns>
        public override string GetInfo()
        {
            return base.GetInfo() + $" со сторонами a={SideA}, b={SideB}, c={SideC}";
        }
        #endregion
    }

    /// <summary>
    /// Круг
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Радиус круга
        /// </summary>
        public double R { get; set; }

        public override string ShapeType { get { return "Круг"; } }

        /// <summary>
        /// Реализация круга через радиус
        /// </summary>
        /// <param name="r">Радиус круга</param>
        public Circle(double r)
        {
            if (r < 0)
            {
                throw new ArgumentException("Радиус должен быть положительным");
            }
            R = r;
        }

        public override double GetArea() => Math.Pow(R, 2) * Math.PI;
        public override string GetInfo()
        {
            return base.GetInfo() + $" с радиусом r={R}";
        }
    }
}