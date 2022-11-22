using System.Drawing;

namespace Figure_area
{
    public abstract class Figure : PropertyFigure
    {
        public abstract string NameFigure { get; set; }

        public abstract string TypeFigure(Point[] pointFigure);

        public abstract double AreaFigure(Point[] pointFigure);

    }

    public class Circel : Figure
    {

        public override string NameFigure { get; set; } = "Круг";

        public override string TypeFigure(Point[] pointFigure)
        {
            bool lineTrue = LineTrue(pointFigure);
            return lineTrue ? GetTypeFigure(pointFigure) : "тип неизвестен";
        }

        //площадь
        public override double AreaFigure(Point[] pointFigure)
        {
            return RadiusCircel(SizeLine(pointFigure));
        }

        // Длина отрезка (радиуса)
        public double SizeLine(Point[] pointFigure)
        {
            double sizeLine = LineLength(pointFigure[0], pointFigure[1]);
            return sizeLine;
        }
    }

    public class Triangle : Figure
    {
        public override string NameFigure { get; set; } = "Треугольник";
        public override string TypeFigure(Point[] pointFigure)
        {
            bool lineTrue = LineTrue(pointFigure);
            return lineTrue ? GetTypeFigure(pointFigure) : "тип неизвестен";
        }

        //площадь
        public override double AreaFigure(Point[] pointFigure)
        {
            // Определим что количество точек позволит построить треугольник
            bool lineTrue = LineTrue(pointFigure, 3);
            return lineTrue ? AreaByPoints(pointFigure) : 0;
        }

        // Проверка, равносторонний
        public bool LineLenghtAll(Point[] pointFigure)
        {
            bool lineLenghtAll = LengthAllIs(pointFigure);
            return lineLenghtAll;
        }

        /// <summary>
        /// Определяем является ли треугольник прямоугольным
        /// </summary> 
        public bool Rectangular(Point[] pointFigure)
        {
            // Определим что количество точек позволит построить треугольник
            bool lineTrue = LineTrue(pointFigure, 3);
            return lineTrue && ListAngles(pointFigure).Contains(90);
        }
    }

    public class UnidentifiedFigure : Figure
    {
        public override string TypeFigure(Point[] pointFigure)
        {
            return  GetTypeFigure(pointFigure);
        }

        public override string NameFigure { get; set; } = "Неизвестная фигура";

        public override double AreaFigure(Point[] pointFigure)
        {
            bool lineTrue = LineTrue(pointFigure, 3);
            return lineTrue ? AreaByPoints(pointFigure) : 0;
        }
    }
}

