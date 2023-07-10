using System;

namespace Task4
{
    public class Program
    {
        private static double Foo(double x)
        {
            return -(x * x) + 5;
        }

        public static void Main(string[] args)
        {
            try
            {
                var imprDelegate = new Func<double, double>(Foo);

                var allMethods = new IIntegration[]
                {
                    new LeftRectangleMethod(), 
                    new RightRectangleMethod(), 
                    new MiddleRectangleMethod(),
                    new TrapezeMethod(),
                    new SimpsonMethod()               
                };

                foreach (var count in allMethods)
                {
                    Console.WriteLine($"{count.CalculateIntegral(imprDelegate, -7, 13, 1000)}");
                    Console.WriteLine($"{count.IntegrationMethod}{Environment.NewLine}");
                }

                foreach (var item in  allMethods)
                {
                    Console.WriteLine($"{item.CalculateIntegral(imprDelegate, -13, 7, -1000000)}");
                    Console.WriteLine($"{item.IntegrationMethod}{Environment.NewLine}");                    
                }
            }
            catch (ArgumentNullException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
            
        }
    }
}