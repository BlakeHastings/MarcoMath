using MarcoMath.Samplers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarcoMath.Distributions.Extensions
{
    public static class DistributionExtension
    {
        public static ShiftedDistribution Shift(this Distribution distribution, double offset)
        {
            return new ShiftedDistribution(offset, distribution);
        }

        public static ScaledDistribution Scale(this Distribution distribution, double scalar)
        {
            return new ScaledDistribution(distribution, scalar);
        }

        public static CombinedDistribution Add(this Distribution distribution, Distribution distribution2)
        {
            return new CombinedDistribution(distribution2, distribution2);
        }

        public static CombinedDistribution AddRange(this Distribution distribution, List<Distribution> distributions)
        {
            distributions.Add(distribution);
            return new CombinedDistribution(distributions);
        }

        public static double Sample(this Distribution distribution, double minAngle, double maxAngle)
        {
            var sampler = new RejectionSampler(minAngle, maxAngle);
            return sampler.Sample(distribution);
        }

        public static double SampleWithNormal(this Distribution distribution, double minAngle, double maxAngle)
        {
            var sampler = new RejectionSampler(minAngle, maxAngle);
            return sampler.SampleWithNormal(distribution);
        }

        public static double[] Evaluate(this Distribution distribution, double minAngle, double maxAngle, int sampling)
        {
            var evaluator = new DistributionEvaluator(minAngle, maxAngle, sampling);
            return evaluator.Evaluate(distribution);
        }

    }
}
