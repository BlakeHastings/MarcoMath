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

    }
}
