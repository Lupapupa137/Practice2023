using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class SimpsonMethod: IIntegration
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
            var sum1 = 0d;
            var sum2 = 0d;
            for (var k = 1; k <= accuracy; k++)
            {
                var xk = left + k * height;
                if (k <= accuracy - 1)
                {
                    sum1 += func(xk);
                }

                var xk1 = left + (k - 1) * height;
                sum2 += func((xk + xk1) / 2);
            }

            var res = height / 3d * (1d / 2d * func(left) + sum1 
                        + 2 * sum2 + 1d / 2d * func(right));
            if (flag) res = -res;

            return res;
        }

        public string IntegrationMethod => "Simpson Method";
    }
}
