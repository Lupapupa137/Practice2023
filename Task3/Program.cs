namespace PracticeLabs3
{
    class Program
    {
        static void Main(string[] args)
        {

            
            try
            { 
                var arr = new int[] { 13, -7, 48, -13, 6, 4, 78, -101 };
                foreach (var i in arr)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
                var resForArr = arr.Sort(SortingMethods<int>.IncreaseDecrease.Increase,
                             Sorting.SortingType.HeapSort);

                foreach (var j in resForArr)
                {
                    Console.Write($"{j} ");
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"{ex.Message}, {ex.ActualValue}");
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}