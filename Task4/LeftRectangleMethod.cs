namespace Task4
{
    public class LeftRectangleMethod : IIntegration
    {
        public double CalculateIntegral(Func<double, double> func,
                                        double left,
                                        double right,
                                        int accuracy) 
        {
            var flag = false;
            if (func == null) 
                throw new ArgumentNullException(nameof(func));
            if (accuracy <= 0) 
                throw new ArgumentException("Invalid accuracy!",
                                            nameof(accuracy));
            
            if (left.CompareTo(right) == 0) return 0d;
            if (left.CompareTo(right) > 0)
            {
                (left, right) = (right, left);
                flag = true;
            }

            var height = (right - left) / accuracy;
            var sum = 0d;
            for (var i = 0; i < accuracy; ++i)
            {
                var x = left + i * height;
                sum += func(x);
            }
            
            var res = height * sum;
            if (flag) res = -res;

            return res;
        }

        public string IntegrationMethod => "Left Rectangle Method";
    }
}
