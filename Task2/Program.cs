using Practice_Labs2;

namespace Ractice_Labs2
{
    class Programm
    {
        static void Main(string[] args)
        {
            try
            {
                var res = new int[] { 1, 1, 2, 3, 3 }
                    .GenerateCombinations(2, Practice_Labs2.IEqualityComparer.Instance);
                foreach (var set in res)
                {
                    Console.WriteLine($"[{string.Join(", ", set.Select(x => x.ToString()))}]");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("");


            var first = new int[] { 1, 2, 3, 4 }
                    .GenerateCombinations(2, Practice_Labs2.IEqualityComparer.Instance);

            foreach (var set in first)
            {
                Console.WriteLine($"[{string.Join(", ", set.Select(x => x.ToString()))}]");
            }
            Console.WriteLine("");

            var second = new int[] { 1, 2, 3 }
                    .GenerateSubsets(Practice_Labs2.IEqualityComparer.Instance);

            foreach (var set in second)
            {
                Console.WriteLine($"[{string.Join(", ", set.Select(x => x.ToString()))}]");
            }
            Console.WriteLine("");

            var third = new int[] { 1, 2, 3 }
                    .GenerateReshuffles(Practice_Labs2.IEqualityComparer.Instance);

            foreach (var set in third)
            {
                Console.WriteLine($"[{string.Join(", ", set.Select(x => x.ToString()))}]");
            }



        }
    }
}