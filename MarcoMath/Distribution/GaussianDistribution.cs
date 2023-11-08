using System;
using System.Collections.Generic;
using System.Text;

namespace MarcoMath.Distributions
{
    public class GaussianDistribution : Distribution
    {
        private double _mean { get; set; }
        private double _std { get; set; }
        private double _scalar { get; set; }

        public GaussianDistribution(double mean, double std, double scalar) : base()
        {
            _scalar = scalar;
            _mean = mean;
            _std = std;
            CalcUpperLimit();
        }

        protected override void CalcUpperLimit()
        {
            _upperLimit = EvaluateX(_mean);
        }

        public override double EvaluateX(double x)
        {   // 1/(std*sqrt(2*pi))*exp(-(x-2)^2/(2*std^2))
            double exponent = -((Math.Pow((x - _mean), 2)) / (2 * Math.Pow(_std, 2)));
            double coefficient = 1 / ((_std * Math.Sqrt(2 * Math.PI)));
            return coefficient * Math.Exp(exponent) * _scalar;
        }
    }
}
