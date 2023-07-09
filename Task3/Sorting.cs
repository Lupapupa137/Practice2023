namespace PracticeLabs3
{

    public static class Sorting
    {
        public enum SortingType
        {
            Insertion,
            Selection,
            HeapSort,
            QSort,
            Merge
        } // third param

        public static T?[] Sort<T>(this T?[] array,
                                   SortingMethods<T>.IncreaseDecrease direction,
                                   SortingType type)
            where T : IComparable<T>
        {
            if (array is null) 
                throw new ArgumentNullException(nameof(T));

            int Comparison(T x, T y) => x.CompareTo(y);

            if (array.Clone() is not T[] res) 
                throw new AggregateException("Cloning error :)");

            ChooseAlgorithm(res, direction, type, Comparison);

            return res;
        }

        public static T?[] Sort<T>(this T?[] array,
                                   SortingMethods<T>.IncreaseDecrease direction,
                                   SortingType type,
                                   IComparer<T?> comparer)
        {
            if (array == null) 
                throw new ArgumentNullException(nameof(array));
            if (comparer == null) 
                throw new ArgumentNullException(nameof(comparer));

            var comparison = new Comparison<T?>(comparer.Compare);

            if (array.Clone() is not T[] res) 
                throw new AggregateException("Cloning error :)");
            
            ChooseAlgorithm(res, direction, type, comparison);

            return res;

        }

        public static T?[] Sort<T>(T?[] array,
                                   SortingMethods<T>.IncreaseDecrease direction,
                                   SortingType type,
                                   Comparer<T> comparer)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            var comparison = new Comparison<T?>(comparer.Compare);

            if (array.Clone() is not T[] res)
                throw new AggregateException("Cloning error :)");

            ChooseAlgorithm(res, direction, type, comparison);

            return res;


        }

        public static T?[] Sort<T>(this T?[] array,
                                   SortingMethods<T>.IncreaseDecrease direction,
                                   SortingType type,
                                   Comparison<T?> comparer)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            if (array.Clone() is not T[] res)
                throw new AggregateException("Cloning error :)");

            ChooseAlgorithm(res, direction, type, comparer);

            return res;

        }

        private static void ChooseAlgorithm<T>(T?[] array,
                                               SortingMethods<T>.IncreaseDecrease direction,
                                               SortingType type,
                                               Comparison<T?> comparer)
        {
            switch (type)
            {
                case SortingType.Insertion:
                    SortingMethods<T>.InsertionSort(array, comparer, direction);
                    break;
                case SortingType.Selection:
                    SortingMethods<T>.SelectionSort(array, comparer, direction);
                    break;
                case SortingType.HeapSort:
                    SortingMethods<T>.HeapSort(array, comparer, direction);
                    break;
                case SortingType.QSort:
                    SortingMethods<T>.QSort(array, comparer, direction);
                    break;
                case SortingType.Merge:
                    SortingMethods<T>.MergeSort(array, comparer, direction);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type),
                                                          type,
                                                          "Invalid algorithm type!");
            }
        }
    }
}