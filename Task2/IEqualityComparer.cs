
namespace Practice_Labs2
{
    public class IEqualityComparer :
        IEqualityComparer<int>
    {
        private static IEqualityComparer? _instance;

        private IEqualityComparer()
        {

        }

        public static IEqualityComparer Instance =>
            _instance ??= new IEqualityComparer();

        public bool Equals(int x, int y)
        { 
            return x == y; 
        }

        public int GetHashCode(int obj) 
        {
            return obj.GetHashCode(); 
        }

    }
}
