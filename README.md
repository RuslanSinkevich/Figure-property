# Класс Фигуры

Собран в виде dll библиотеки, разбит на 2 файла 

Figure - составляет классы конкретных фигур

PropertyFigure - свойства фигур

## Использование
### Доступные классы и методы
```c#
Point point1 = new Point(1, 1);
Point point2 = new Point(1, 3);
Point point3 = new Point(3, 3);
Point point4 = new Point(3, 1);
Point point6 = new Point(5, 3);
Point point7 = new Point(5, 1);
Point point8 = new Point(6, 1);
Point point9 = new Point(3, 0);
Point[] point_1 = { point1 };
Point[] point_2 = { point1, point2 };
Point[] point_3 = { point1, point2, point3 };
Point[] point_4 = { point1, point2, point6, point7 };
Point[] point_5 = { point1, point2, point3, point4 };

Circle circle = new (point_2);
Console.WriteLine(circle.NameFigure);
Console.WriteLine("длинна радиуса = " + Math.Round( circle.SizeLine(),2));
Console.WriteLine("площадь = " + circle.AreaFigure());

Triangle triangle = new Triangle(point_3);
Console.WriteLine(triangle.NameFigure);
Console.WriteLine("площадь = " + triangle.AreaFigure());
Console.WriteLine(triangle.Rectangular() ? "прямоугольный" : "не прямоугольный");

// Определение фигуры исходя из количества точек
UnidentifiedFigure unidentifiedFigure = new UnidentifiedFigure(point_3);
Console.WriteLine(unidentifiedFigure.FindFigure()?.NameFigure);
Console.WriteLine("площадь = " + unidentifiedFigure.FindFigure()!.AreaFigure());

// Определение фигуры исходя из количества точек
UnidentifiedFigure unidentifiedFigure2 = new UnidentifiedFigure(point_4);
Console.WriteLine(unidentifiedFigure2.FindFigure()?.NameFigure);
Console.WriteLine("площадь = " + unidentifiedFigure2.FindFigure()!.AreaFigure());
```
