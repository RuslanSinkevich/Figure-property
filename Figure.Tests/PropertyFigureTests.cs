using System.Drawing;
using Figure_area;

namespace Figure_Tests
{
    [TestFixture]
    public class PropertyFigureTests : PropertyFigure
    {
        public Point[] PointPoint, PointSegment, PointTriangle, PointSquare, 
            PointRectangle, PointPolygon, PointPolygon5;
        

        public PropertyFigureTests()
        {
            Point point1 = new Point(1, 1);
            Point point2 = new Point(1, 3);
            Point point3 = new Point(3, 3);
            Point point4 = new Point(3, 1);
            Point point6 = new Point(5, 3);
            Point point7 = new Point(5, 1);
            Point point8 = new Point(6, 1);
            Point point9 = new Point(3, 0);
            PointPoint = new[] { point1};
            PointSegment = new[] { point1, point2 };
            PointTriangle = new[] { point1, point2, point3 };
            PointSquare = new[] { point1, point2, point3, point4 };
            PointRectangle = new[] { point1, point2, point6, point7 };
            PointPolygon = new[] { point1, point2, point6, point8 };
            PointPolygon5 = new[] { point1, point2, point6, point8, point9 };

        }

        [Test]
        public void GetTypeFigure_Return_TypeFigure()
        {
            Assert.That(GetTypeFigure(PointSegment), Is.EqualTo("Отрезок"));
            Assert.That(GetTypeFigure(PointTriangle), Is.EqualTo("Треугольник"));
            Assert.That(GetTypeFigure(PointSquare), Is.EqualTo("Квадрат"));
            Assert.That(GetTypeFigure(PointRectangle), Is.EqualTo("Прямоугольник"));
            Assert.That(GetTypeFigure(PointPolygon), Is.EqualTo("Многоугольник"));
            Assert.That(GetTypeFigure(PointPolygon5), Is.EqualTo("Многоугольник"));
        }

        [Test]
        public void AreaByPoints_return_Area()
        {
            Assert.That(AreaByPoints(PointRectangle), Is.EqualTo(8.0));
            Assert.That(AreaByPoints(PointPolygon5), Is.EqualTo(11.50));
        }

        [Test]
        public void LineTrue_return_more_1()
        {
            Assert.That(LineTrue(PointPoint), Is.EqualTo(false));
            Assert.That(LineTrue(PointSegment), Is.EqualTo(true));
        }

        



        //[Test]_
        //public void GetTypeFigure_InvalidFormat_FormatException()
        //{
        //    TestDelegate action = () => propertyFigure.GetTypeFigure(point_2);
        //    Assert.Throws<FormatException>(action );
        //}

    }
}