using System;
using System.Collections.Generic;
using System.Text;

namespace Laba3.BLL
{
    class Calculator
    {
        private double z_parameter;
        private double b_parameter;
        private double a_parameter;

        public Calculator(double z, double b, double a)
        {
            z_parameter = z;
            b_parameter = b;
            a_parameter = a;
        }

        private double Function(double x)
        {
            return Math.Sqrt(Math.Abs(x) + Math.Pow(Math.Cos(x), 3) + Math.Pow(z_parameter, 4)) 
                / (Math.Log(x) - Math.Asin(b_parameter * x - a_parameter));
        }

        public Dictionary<double, double> GetArgAndExpr(double from, double to, double step)
        {
            if (step <= 0)
            {
                throw new ArgumentException("Step must be great than 0!");
            }

            var results = new Dictionary<double, double>();

            for (double x = from; x < to; x += step)
            {
                double res = Function(x);
                results.Add(x, res);
            }

            if (results.Count == 0)
            {
                throw new Exception("result is empty!");
            }

            return results;
        }
    }
}
