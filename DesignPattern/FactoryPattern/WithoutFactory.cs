//Problem with this approach is that we cannot have contructor with different name for the same type of arguments.
//The object creation becomes difficult since the client has to read the summary and check what parameters need to be passed in order to initialize an object

using System;
namespace FactoryPattern
{
    namespace WithoutFactoryPattern
    {
        public enum CoordinateSystem
        {
            Cartesian,
            Polar
        }
        public class Point
        {
            private double x;
            private double y;

            /// <summary>
            /// Initialize a point with two values and provide the coordinate system
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <param name="system"></param>
            public Point(double a, double b, CoordinateSystem system)
            {
                switch (system)
                {
                    case CoordinateSystem.Cartesian:
                        this.x = a;
                        this.y = b;
                        break;
                    case CoordinateSystem.Polar:
                        this.x = a * Math.Cos(b);
                        this.y = a * Math.Sin(b);
                        break;
                    default:
                        break;
                }
            }

            public override string ToString()
            {
                return $"value of point x={this.x} and y={this.y}";
            }
        }

        public class WithoutFactory
        {
            public WithoutFactory()
            {
                Point point = new Point(10, 20, CoordinateSystem.Polar);
                Console.WriteLine(point);

                Point point2 = new Point(10, 20, CoordinateSystem.Cartesian);
                Console.WriteLine(point2);
            }
        }
    }
}
