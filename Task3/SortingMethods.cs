// вспомогательные методы ниже видов сортировки

namespace PracticeLabs3
{
    public static class SortingMethods<T>
    {
        public enum IncreaseDecrease
        {
            Increase,
            Decrease
        } // second param

        // сортировка вставкой
        public static T?[] InsertionSort(T?[] array,
                                  Comparison<T> comparer,
                                  IncreaseDecrease direction)
        {
            var size =  array.Length;

            for (var i = 1; i < size; i++)
            {
                var k = array[i];
                var j = i;

                while (j > 0 && ((direction == IncreaseDecrease.Increase)
                    ? comparer(k, array[j - 1]) < 0
                    : comparer(k, array[j - 1]) > 0))
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = k;
            }
            return array;
        }

        // сортировка выбором
        public static T?[] SelectionSort(T?[] array,
                                  Comparison<T> comparer,
                                  IncreaseDecrease direction)
        {
            for (int i = 0; i < array.Length - 1; i++)
            { 
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (direction == IncreaseDecrease.Increase
                        ? comparer(array[j], array[min]) < 0
                        : comparer(array[j], array[min]) > 0)
                    {
                        min = j;
                    }
                }
                //обмен элементов
                (array[i], array[min]) = (array[min], array[i]);
            }
            return array;
        }
    

        // пирамидальная сортировка
        public static T?[] HeapSort(T?[] array,
                                  Comparison<T> comparer,
                                  IncreaseDecrease direction)
        {
            var size = array.Length;

            for (var i = size / 2 - 1; i >= 0; i--)
            {
                Heapify(array, size, i, direction, comparer);
            }

            for (var i = size - 1; i >= 0; i--)
            {
                (array[0], array[i]) = (array[i], array[0]);
                Heapify(array, i, 0, direction, comparer);
            }
            return array;
        }


        // быстрая сортировка
        public static T?[] QSort(T?[] array,
                                  Comparison<T> comparer,
                                  IncreaseDecrease direction)
        {
            return QSortAdd(array, 0, array.Length - 1, direction, comparer);
        }

        // сортировка слиянием
        public static T?[] MergeSort(T?[] array,
                                  Comparison<T> comparer,
                                  IncreaseDecrease direction)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            return MergeSortAdd(array, 0, array.Length - 1, direction, comparer);
        }


        //
        private static void Heapify(T[] array,
                                    int size,
                                    int root,
                                    IncreaseDecrease direction,
                                    Comparison<T> comparer)
        {
            var maxMin = root;

            var left = 2 * root + 1;
            var right = 2 * root + 2;


            if (left < size && (direction == IncreaseDecrease.Increase
                ? comparer(array[left], array[maxMin]) > 0
                : comparer(array[left], array[maxMin]) < 0)) { maxMin = left; }


            if (right < size && (direction == IncreaseDecrease.Increase 
                ? comparer(array[right], array[maxMin]) > 0 
                : comparer(array[right], array[maxMin]) < 0))   { maxMin = right; }
            
            if (maxMin != root)
            {
                (array[root], array[maxMin]) = (array[maxMin], array[root]);
                Heapify(array, size, maxMin, direction, comparer);
            }

        }

        //
        private static T[] QSortAdd(T[] collection,
                                    int minInd,
                                    int maxInd,
                                    IncreaseDecrease direction,
                                    Comparison<T> comparer)
        { 
            if (minInd >= maxInd)
            {
                return collection;
            }

            var addInd = Partition(collection, minInd, maxInd, direction, comparer);
            QSortAdd(collection, minInd, addInd - 1, direction, comparer);
            QSortAdd(collection, addInd + 1, maxInd, direction, comparer);

            return collection;
        }

        //
        private static int Partition(T[] array,
                              int minInd,
                              int maxInd,
                              IncreaseDecrease direction,
                              Comparison<T> comparer)
        {
            var add = minInd - 1;
            for (var i = minInd; i < maxInd; i++)
            {
                if (direction == IncreaseDecrease.Increase
                    ? comparer(array[i], array[maxInd]) < 0
                    : comparer(array[i], array[maxInd]) > 0)
                {
                    add++;
                    (array[add], array[i]) = (array[i], array[add]);
                }
            }

            add++;
            (array[add], array[maxInd]) = (array[maxInd], array[add]);
            return add;
        }

        //
        private static T[] MergeSortAdd(T[] array,
                                        int lowInd,
                                        int highInd,
                                        IncreaseDecrease direction,
                                        Comparison<T> comparer)
        {
            if (lowInd < highInd)
            {
                var middleInd = (lowInd + highInd) / 2;
                MergeSortAdd(array, lowInd, middleInd, direction, comparer);
                MergeSortAdd(array, middleInd + 1, highInd, direction, comparer);
                Merge(array, lowInd, middleInd, highInd, direction, comparer);
            }

            return array;
        }

        private static void Merge(T[] array,
                                  int lowInd,
                                  int middleInd,
                                  int highInd,
                                  IncreaseDecrease direction,
                                  Comparison<T> comparer)
        {
            var left = lowInd;
            var right = middleInd + 1;
            var tempArray = new T[highInd - lowInd + 1];
            var index = 0;

            while ((left <= middleInd) && (right <= highInd))
            {
                if (direction == IncreaseDecrease.Increase ?
                    comparer(array[left], array[right]) < 0
                    : comparer(array[left], array[right]) > 0)
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }
                index++;
            }

            for (var i = left; i <= middleInd; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highInd; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowInd + i] = tempArray[i];
            }
        }
    }
}
