using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Reflection;

namespace Figure_area
{
    public class PropertyFigure
    {
        /// <summary>
        /// Проверяем тип фигуры. 
        /// </summary>
        /// <param name="pointFigures"></param>
        /// <returns>bool</returns>
        public string GetTypeFigure(Point[] pointFigures)
        {
            string typeFigure = "";
            switch (pointFigures.Length)
            {
                case 3:
                    typeFigure = "Треугольник";
                    break;
                case 4:
                    typeFigure = LengthAllIs(pointFigures) ? "Квадрат" : "Прямоугольник";
                    break;
                case > 5:
                    typeFigure = "Многоугольник";
                    break;
            }
            return typeFigure;
        }


        /// <summary>
        /// Вычисляем площадь многоугольна. 
        /// </summary>
        /// <param name="pointFigures">Массив точек</param>
        /// <returns>bool</returns>
        internal double AreaByPoints(Point[] pointFigures)
        {
            double area = 0;
            for (int i = 0; i < pointFigures.Length; i++)
            {
                int j = (i + 1) % pointFigures.Length;
                Point a = pointFigures[i], b = pointFigures[j];

                area += a.X * b.Y - a.Y * b.X;
            }
            return Math.Abs(area) / 2;
        }

        /// <summary>
        /// Проверка, количество точек должно быть больше 1. 
        /// </summary>
        /// <param name="pointFigures">Массив точек</param>
        /// <returns>bool</returns>
        internal bool LineTrue(Point[] pointFigures)
        {
            return pointFigures.Length > 1;
        }

        /// <summary>
        /// Проверка, количество точек больше N
        /// </summary>
        /// <param name="pointFigures">Массив точек</param>
        /// <param name="countPoint">Количество точек</param>
        /// <returns>bool</returns>
        internal bool LineTrue(Point[] pointFigures, int countPoint)
        {
            return pointFigures.Length > --countPoint;
        }

        /// <summary>
        ///  Определить длину отрезка по двум точкам.
        /// <param name="pointA">Точка А</param>
        /// <param name="pointB">Точка Б</param>
        /// </summary>
        internal double LineLength(Point pointA, Point pointB)
        {
            double lineListLength = Math.Sqrt(
                    Math.Pow(pointA.X - pointB.X, 2) +
                    Math.Pow(pointA.Y - pointB.Y, 2));
            return lineListLength;
        }

        /// <summary>
        ///     Проверка, длины всех отрезков  на одинаковость.
        ///     Перебор происходит от начала массива в конец,
        ///     последняя итерация проверяет первую и последнюю точку в массиве.
        /// </summary>
        /// <param name="pointFigures"></param>
        /// <returns>bool</returns>
        internal bool LengthAllIs(Point[] pointFigures)
        {
            if (LineTrue(pointFigures))
            {
               return ListLengthAll(pointFigures).All(x => x == ListLengthAll(pointFigures).FirstOrDefault());
            }
            else
                return false;
        }

        /// <summary>
        /// Список длин всех отрезков
        /// </summary>
        /// <param name="pointFigures"></param>
        /// <returns>bool</returns>
        internal List<double> ListLengthAll(Point[] pointFigures)
        {
            List<double> arr = new List<double>();
            for (int i = 0; i < pointFigures.Length; i++)
            {
                int j = (i + 1) % pointFigures.Length;
                Point a = pointFigures[i], b = pointFigures[j];
                double getSid = LineLength(a, b);
                arr.Add(getSid);
            }
            return arr;
        }

        /// <summary>
        /// Определяем радиус круга по двум точкам.
        /// </summary>
        /// <param name="pointFigures"></param>
        /// <returns>bool</returns>
        internal double RadiusCircel(Point[] pointFigures)
        {
            if (LineTrue(pointFigures))
            {
                Point pointA = pointFigures[0];
                Point pointB = pointFigures[1];
                double lineLength = LineLength(pointA, pointB);
                lineLength = lineLength * lineLength * Math.PI;
                return lineLength;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Определяем радиус круга по длине 
        /// </summary>
        /// <param name="sizeLine"></param>
        /// <returns>bool</returns>
        internal static double RadiusCircel(double sizeLine)
        {
            sizeLine = sizeLine * sizeLine * Math.PI;
                return Math.Round(sizeLine, 2);
        }

        /// <summary>
        /// Определим является ли треугольник прямоугольным
        /// </summary>
        /// <param name="pointFigures"></param>
        /// <returns>bool</returns>
        public List<double> ListAngles(Point[] pointFigures)
        {
            List<double> line = ListLengthAll(pointFigures);
            for (int i = 0; i < line.Count; i++)
            {
                int j = (i + 1) % line.Count;
                Point a = pointFigures[i], b = pointFigures[j];

            }
            return arr;
        }



        ///// <summary>
        /////  Проверка, пересечений линий, true если линии пересекаются
        ///// </summary>
        ///// <param name="pointFigures"></param>
        ///// <returns>bool</returns>
        //internal bool CrossingLines(Point[] pointFigures)
        //{
        //    if (LineTrue(pointFigures, 4))
        //    {
        //        for (int i = 0; i < pointFigures.Length; i++)
        //        {
        //            int j = (i + 1) % pointFigures.Length;
        //            int k = (i + 2) % pointFigures.Length;
        //            int z = (i + 3) % pointFigures.Length;
        //            Point a = pointFigures[i],
        //                b = pointFigures[j],
        //                c = pointFigures[k],
        //                d = pointFigures[z];

        //            double common = (b.X - a.X) * (d.Y - c.Y) - (b.Y - a.Y) * (d.X - c.X);

        //            double rH = (a.Y - c.Y) * (d.X - c.X) - (a.X - c.X) * (d.Y - c.Y);
        //            double sH = (a.Y - c.Y) * (b.X - a.X) - (a.X - c.X) * (b.Y - a.Y);

        //            double r = rH / common;
        //            double s = sH / common;

        //            if (r is >= 0 and <= 1 && s is >= 0 and <= 1)
        //                return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
