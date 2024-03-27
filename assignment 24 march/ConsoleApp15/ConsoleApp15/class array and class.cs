using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    using System;
    public class Circle
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double TotalArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double TotalPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public bool IsPointInsideCircle(double x, double y)
        {
            double distanceFromCenter = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return distanceFromCenter <= Radius;
        }
    }

    public class CircleManager
    {
        public static Circle[] ArrayOfCircles(int numberOfCircles)
        {
            Circle[] circles = new Circle[numberOfCircles];
            Random random = new Random();
            for (int i = 0; i < numberOfCircles; i++)
            {
                double radius = random.Next(1, 10); // Adjust range as needed
                circles[i] = new Circle(radius);
            }
            return circles;
        }

        public static void PrintCircleInformation(Circle[] circles)
        {
            foreach (var circle in circles)
            {
                Console.WriteLine($"Circle with radius {circle.Radius}:");
                Console.WriteLine($"Area: {circle.TotalArea()}");
                Console.WriteLine($"Perimeter: {circle.TotalPerimeter()}");
                Console.WriteLine();
            }
        }

        public static Tuple<double, double> GetPointFromUser()
        {
            Console.WriteLine("Enter X coordinate:");
            double x = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Y coordinate:");
            double y = double.Parse(Console.ReadLine());

            return Tuple.Create(x, y);
        }

        public static void CheckPointInCircles(Circle[] circles, double x, double y)
        {
            foreach (var circle in circles)
            {
                bool isInside = circle.IsPointInsideCircle(x, y);
                Console.WriteLine($"Point ({x},{y}) is {(isInside ? "inside" : "outside")} the circle with radius {circle.Radius}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of circles:");
            int numberOfCircles = int.Parse(Console.ReadLine());

            Circle[] circles = CircleManager.ArrayOfCircles(numberOfCircles);

            Console.WriteLine("Circle information:");
            CircleManager.PrintCircleInformation(circles);

            Tuple<double, double> point = CircleManager.GetPointFromUser();

            CircleManager.CheckPointInCircles(circles, point.Item1, point.Item2);
        }
    }
}
    

