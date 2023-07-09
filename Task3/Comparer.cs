namespace PracticeLabs3
{
    internal class Comparer :
        IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if ((x & 1) == 0 && (y & 1) == 1)
            {
                return 1;
            }

            if ((x & 1) == 1 && (y & 1) == 0)
            {
                return -1;
            }

            return x.CompareTo(y);
        }
    }
}