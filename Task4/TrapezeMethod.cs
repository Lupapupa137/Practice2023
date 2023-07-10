using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class TrapezeMethod : IIntegration
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
                throw new ArgumentException("Invalid accuracy!", nameof(accuracy));
            if (left.CompareTo(right) == 0) return 0d;
            if (left.CompareTo(right) > 0)
            {
                (left, right) = (right, left);
                flag = true;
            }

            var height = (right - left) / accuracy;
            var sum = func(left) + func(right);
            for (var i = 1; i <= accuracy - 1; ++i)
                sum += 2 * func(left + i * height);

            var res = sum * (height / 2);
            if (flag) res = -res;

            return res;
        }

        public string IntegrationMethod => "Trapeze Method";
    }
}
