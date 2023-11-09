using MarcoMath.Distributions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarcoMath.Distributions
{
    public class DistributionEvaluator
    {
        private double _minAngle { get; set; }
        private double _maxAngle { get; set; }
        private int _samplingNumber { get; set; }

        public DistributionEvaluator(double minAngle, double maxAngle, int sampling)
        {
            _minAngle = minAngle;
            _maxAngle = maxAngle;
            _samplingNumber = sampling;
        }

        public double[] Evaluate(Distribution distribution)
        {
            double[] y = new double[_samplingNumber];
            if (y.Length != _samplingNumber)
                throw new Exception("Distribution results array length must be the same as sampling number");
            double x;
            double step = (_maxAngle - _minAngle) / (y.Length);
            for (int i = 0; i < y.Length; i++)
            {
                x = _minAngle + i * step;
                y[i] = distribution.EvaluateX(x);
            }
            return y;
        }
        public double[] AddEvaluate(double[] y, Distribution distribution)
        {
            if (y.Length != _samplingNumber)
                throw new Exception("Distribution results array length must be the same as sampling number");
            double x;
            double step = (_maxAngle - _minAngle) / (y.Length);
            for (int i = 0; i < y.Length; i++)
            {
                x = _minAngle + i * step;
                y[i] = Math.Max(y[i] + distribution.EvaluateX(x), 0);
            }
            return y;
        }
        public double[] MinusEvaluate(double[] y, Distribution distribution)
        {
            if (y.Length != _samplingNumber)
                throw new Exception("Distribution results array length must be the same as sampling number");
            double x;
            double step = (_maxAngle - _minAngle) / (y.Length);
            for (int i = 0; i < y.Length; i++)
            {
                x = _minAngle + i * step;
                y[i] = Math.Max(y[i] + distribution.EvaluateX(x), 0);
            }
            return y;
        } 

    }
}
