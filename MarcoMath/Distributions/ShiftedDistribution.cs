﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MarcoMath.Distributions
{
    public class ShiftedDistribution : Distribution
    {
        private Distribution _distribution { get; set; }
        private double _offset { get; set; }

        public ShiftedDistribution(double offset, Distribution distribution) : base()
        {
            
            _distribution = distribution;
            _offset = offset;
            CalcUpperLimit();
            //_upperLimit = distribution.GetUpperLimit();
            
            
        }

        public override double EvaluateX(double x)
        {
            return _distribution.EvaluateX(x - _offset);
        }

        protected override void CalcUpperLimit()
        {
            _upperLimit = _distribution.GetUpperLimit();
        }
    }
}
