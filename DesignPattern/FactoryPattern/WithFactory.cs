//This is much better approach. Make the constructor private and provide public static api with better names and simpler parameters.
//Makes the creation of objects much more simpler. Better naming of methods and parameters inside the functions.

using System;
namespace FactoryPattern
{
    namespace WithFactoryPattern
    {
        public class Point
        {
            private double x;
            private double y;

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

            private Point(double a, double b)
            {
                this.x = a;
                this.y = b;
            }

            public override string ToString()
            {
                return $"value of point x={this.x} and y={this.y}";
            }
        }

        public class WithFactory
        {
            public WithFactory()
            {
                Point point = Point.NewPolarPoint(10,20);
                Console.WriteLine(point);

                Point point2 = Point.NewCartesianPoint(10,20);
                Console.WriteLine(point2);
            }
        }
    }
}
