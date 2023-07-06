using System;

namespace Practice.Labs
{
    internal class Task1
    {
        static void Main(string[] args)
        {
            try
            {
                var me1 = new Student("Yana", "Kasyanova", "Stanislavovna", "М8О-211Б-21", "");
            }catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }

            var me = new Student("Yana", "Kasyanova", "Stanislavovna", "М8О-211Б-21", "C#");

            Console.WriteLine(me.ToString());

            Console.WriteLine(me.GetHashCode());

            Console.WriteLine(me.Equals(me));

            Console.WriteLine($"Course: {me.Course}");

            Console.WriteLine(me.Group);
        } 
    }
}
