using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarcoMath.Distributions {
    public class CombinedDistribution : Distribution
    {
        private List<Distribution> _distributions { get; set; }
        

        public CombinedDistribution(List<Distribution> distributions) : base()
        {
            _distributions = distributions;
            _normalizationFactor = 1;
            CalcUpperLimit();
        }

        protected override void CalcUpperLimit()
        {
            _upperLimit = _distributions.Sum(dist => dist.GetUpperLimit());
        }

        public override double EvaluateX(double x)
        {
            double rtnSum = 0;
            _distributions.ForEach(distribution => rtnSum += _normalizationFactor * distribution.EvaluateX(x));
            return Math.Max(rtnSum,0);
        }

        
    }
}
