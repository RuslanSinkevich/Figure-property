using System.Drawing;

namespace Figure_area
{
    public abstract class Figure: PropertyFigure
    {
        public abstract Point[] Points { get; set; }

        public abstract string? NameFigure { get; set; }

        public abstract double AreaFigure();
    }

    public class Circle : Figure
    {
        public sealed override Point[] Points { get; set; }
        
        public sealed override string? NameFigure { get; set; }

        public Circle(Point[] points)
        {
            Points = points;
            NameFigure = "Круг";
        }

        /// <summary>
        /// Площадь фигуры
        /// </summary> 
        public override double AreaFigure()
        {
            LineTrue(Points);
            return RadiusCircle(SizeLine());
        }

        /// <summary>
        /// Длина отрезка (радиуса)
        /// </summary> 
        public double SizeLine()
        {
            if (LineTrue(Points))
            {
                double sizeLine = LineLength(Points[0], Points[1]);
                return sizeLine;
            }
            return 0;
        }
    }

    public class Triangle : Figure
    {
        public Triangle(Point[] points)
        {
            Points = points;
            NameFigure = "Треугольник";
        }

        public sealed override Point[] Points { get; set; }

        public sealed override string? NameFigure { get; set; }

        /// <summary>
        /// Площадь фигуры
        /// </summary> 
        public override double AreaFigure()
        {
            // Определим что количество точек позволит построить треугольник
            bool lineTrue = LineTrue(Points, 3);
            return lineTrue ? AreaByPoints(Points) : 0;
        }

        /// <summary>
        /// Определяем все стороны равны (равносторонний)
        /// </summary> 
        public bool LineLengthAll()
        {
            bool lineLengthAll = LengthAllIs(Points);
            return lineLengthAll;
        }

        /// <summary>
        /// Определяем является ли треугольник прямоугольным
        /// </summary> 
        public bool Rectangular()
        {
            // Определим что количество точек позволит построить треугольник
            bool lineTrue = LineTrue(Points, 3);
            return lineTrue && ListAngles(Points).Contains(90);
        }
    }

    public class UnidentifiedFigure
    {
        Figure figure = null;

        public UnidentifiedFigure(Point[] points)
        {
            Points = points;
            Sw();
        }

        private Figure Sw()
        {
            switch (Points.Length)
            {
                case 3: figure = new Circle(Points); break;


            }
            return  figure;
            
        }

        public Point[] Points { get; set; }

    }

}

