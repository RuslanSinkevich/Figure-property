using System.Drawing;
using Figure_area;

namespace Figure.Tests
{
    [TestFixture]
    public class PropertyFigureTests : PropertyFigure
    {
        public Point[] PointPoint, PointSegment, PointTriangle, PointSquare, 
            PointRectangle, PointPolygon, PointPolygon5, Radius, PointCrossing;
        

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
            Radius = new[] { point1, point6 };
            PointCrossing = new[] { point1, point2, point3, point4, point2 };
        }

        [Test]
        public void Point_arr_return_type_figure()
        {
            Assert.That(GetTypeFigure(PointSegment), Is.EqualTo("Отрезок"));
            Assert.That(GetTypeFigure(PointTriangle), Is.EqualTo("Треугольник"));
            Assert.That(GetTypeFigure(PointSquare), Is.EqualTo("Квадрат"));
            Assert.That(GetTypeFigure(PointRectangle), Is.EqualTo("Прямоугольник"));
            Assert.That(GetTypeFigure(PointPolygon), Is.EqualTo("Четырехугольник"));
            Assert.That(GetTypeFigure(PointPolygon5), Is.EqualTo("Многоугольник"));
        }

        [Test]
        public void Area_by_points_return_Area()
        {
            Assert.That(AreaByPoints(PointRectangle), Is.EqualTo(8.0).Within(1).Percent);
            Assert.That(AreaByPoints(PointPolygon5), Is.EqualTo(11.50).Within(1).Percent);
        }

        [Test]
        public void If_line_return_true()
        {
            Assert.That(LineTrue(PointPoint), Is.EqualTo(false));
            Assert.That(LineTrue(PointSegment), Is.EqualTo(true));
        }

        [Test]
        public void Length_all_line_equals_return_true()
        {
            Assert.That(LengthAllIs(PointSquare), Is.EqualTo(true));
            Assert.That(LengthAllIs(PointRectangle), Is.EqualTo(false));
        }

        [Test]
        public void List_length_all_sides_equals_return_true()
        {
            List<double> listAngSquare = ListLengthAll(PointSquare);
            Assert.That(listAngSquare.All(x => Math.Abs(x - listAngSquare.FirstOrDefault()) < 0.01),
                Is.EqualTo(true));
            List<double> listAngPointTriangle = ListLengthAll(PointTriangle);
            Assert.That(listAngPointTriangle.All(x => Math.Abs(x - listAngPointTriangle.FirstOrDefault()) < 0.01), 
                Is.EqualTo(false));

        }

        [Test]
        public void List_all_angles_equals_return_true()
        {
            List<double> pointSquare = ListAngles(PointSquare);
            Assert.That(pointSquare.All(x => Math.Abs(x - pointSquare.FirstOrDefault()) < 0.01), 
                Is.EqualTo(true));
            List<double> pointRectangle = ListAngles(PointRectangle);
            Assert.That(pointRectangle.All(x => Math.Abs(x - pointRectangle.FirstOrDefault()) < 0.01),
                Is.EqualTo(true));
            List<double> pointPolygon5 = ListAngles(PointPolygon5);
            Assert.That(pointPolygon5.All(x => Math.Abs(x - pointPolygon5.FirstOrDefault()) < 0.01), 
                Is.EqualTo(false));
        }

        [Test]
        public void Radius_circle_return_area_circle()
        {
            Assert.That(RadiusCircle(PointSegment), Is.EqualTo(12.56).Within(1).Percent);
            Assert.That(RadiusCircle(Radius), Is.EqualTo(62.77).Within(1).Percent);
        }

        [Test]
        public void Crossing_Lines_return_true()
        {
            Assert.That(CrossingLines(PointPolygon5), Is.EqualTo(false));
            Assert.That(CrossingLines(PointCrossing), Is.EqualTo(true));
        }

        //[Test]_
        //public void GetTypeFigure_InvalidFormat_FormatException()
        //{
        //    TestDelegate action = () => propertyFigure.GetTypeFigure(point_2);
        //    Assert.Throws<FormatException>(action );
        //}

    }
}