//Seperate the concern of actually creating and instantiating the object by creating an inner factory class

using System;
namespace FactoryPattern
{
    namespace WithFactoryClassPattern
    {

        public class Point
        {
            private double x;
            private double y;

            private Point(double a, double b)
            {
                this.x = a;
                this.y = b;
            }

            public override string ToString()
            {
                return $"value of point x={this.x} and y={this.y}";
            }

            public class Factory
            {
                public static Point NewCartesianPoint(double x, double y)
                {
                    Point point = new Point(x, y);
                    return point;
                }

                public static Point NewPolarPoint(double rho, double theta)
                {
                    double coord_1 = rho * Math.Cos(theta);
                    double coord_2 = rho * Math.Sin(theta);
                    Point point = new Point(coord_1, coord_2);
                    return point;

                }
            }
        }

        public class WithFactoryClass
        {
            public WithFactoryClass()
            {
                Point point = Point.Factory.NewPolarPoint(10, 20);
                Console.WriteLine(point);

                Point point2 = Point.Factory.NewCartesianPoint(10, 20);
                Console.WriteLine(point2);
            }
        }
    }
}
