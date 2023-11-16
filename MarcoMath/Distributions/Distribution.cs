using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.Integration;
using MathNet.Numerics;

namespace MarcoMath.Distributions
{
    public abstract class Distribution
    {
        protected double _normalizationFactor { get; set; } = 1;
        protected double _upperLimit { get; set; }

        public Distribution() {
        }
        public Distribution(double normalizationFactor) 
        {
            _normalizationFactor = normalizationFactor;
            CalcUpperLimit();
        }

        public abstract double EvaluateX(double x);

        protected abstract void CalcUpperLimit();
        protected void SetUpperLimit(double limit)
        {
            _upperLimit = limit;
        }

        public double GetUpperLimit()
        {
            return _upperLimit;
        }

        public Distribution Normalize(double minAngle, double maxAngle)
        {
            double area = SimpsonRule.IntegrateComposite(x => EvaluateX(x), minAngle, maxAngle, 4);
            _normalizationFactor *= 1 / area;
            SetUpperLimit(_upperLimit * 1 / area);
            return this;
        }

        public Distribution SetNormalizationFactor(double NormalizationFactor)
        {
            _normalizationFactor = NormalizationFactor;
            return this;
        }

    }
}
