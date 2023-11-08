using System;
using System.Collections.Generic;
using System.Text;

namespace MarcoMath.Distributions
{
    public class UnitaryDistribution: Distribution
    {   private double _start {  get; set; }  
        private double _end { get; set; } 
        private double _scalar { get; set; }
        
        public UnitaryDistribution(double start, double end,double scalar) {
            _start = start;
            _end = end;
            _scalar = scalar;
            CalcUpperLimit();
        }
        protected override void CalcUpperLimit(){
            _upperLimit = _scalar;
        }
        public override double EvaluateX(double x) => (_start < x && x < _end) ? _scalar : 0;
       

    }
}
