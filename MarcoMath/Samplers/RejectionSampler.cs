using MarcoMath.Distributions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarcoMath.Samplers
{
    public class RejectionSampler
    {
        private double _minAngle { get; set; }
        private double _maxAngle { get; set; }

        public RejectionSampler(double minAngle, double maxAngle)
        {
            _minAngle = minAngle;
            _maxAngle = maxAngle;
        }

        public double SampleWithNormal(Distribution distribution)
        {
            return Sample(distribution.Normalize(_minAngle, _maxAngle));
        }

        public double Sample(Distribution distribution)
        {
            Random random = new Random();
            var angleDif = (_maxAngle - _minAngle);
            var middle = (_minAngle + _maxAngle) / 2;
            double _upperlimit = distribution.GetUpperLimit();

            for (int i = 0; i < 9000; i++)
            {
                //remove
                double unitaryRandom = random.NextDouble() * angleDif + _minAngle;
                double y = random.NextDouble() *_upperlimit;
                var result = distribution.EvaluateX(unitaryRandom);
                if (result > y)
                    return unitaryRandom;
            }

            throw new Exception("No valid sample found");
        }

    }
}
