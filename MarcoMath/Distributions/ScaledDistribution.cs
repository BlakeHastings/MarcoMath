using System;
using System.Collections.Generic;
using System.Text;

namespace MarcoMath.Distributions
{
    public class ScaledDistribution : Distribution
    {

        private Distribution _distribution;
        private double _scalar;

        public ScaledDistribution(Distribution distribution, double scalar) {
            _distribution = distribution;
            _scalar = scalar;
        }

        public override double EvaluateX(double x)
        {
            return _distribution.EvaluateX(x * _scalar);
        }

        protected override void CalcUpperLimit()
        {
            _upperLimit = _distribution.GetUpperLimit();   
        }
    }
}
