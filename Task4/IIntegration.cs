namespace Task4
{
    public interface IIntegration
    {
        public double CalculateIntegral(Func<double, double> func,
                                        double left,
                                        double right,
                                        int accuracy);

        string IntegrationMethod  { get; }
    }
}