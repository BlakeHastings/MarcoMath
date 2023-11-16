using System;
using System.Collections.Generic;
using System.Text;

namespace MarcoMath.Histogram
{
    public class Histogram
    {

        private uint GetLargestBinSum(uint[] bins)
        {
            // get largets bin sum
            uint largestBinSum = 0;
            for (int i = 0; i < bins.Length; i++)
            {
                if (bins[i] > largestBinSum)
                {
                    largestBinSum = bins[i];
                }
            }
            return largestBinSum;
        }

        public static uint[] GetHistBins(List<double> angledatapoints, double minAngle = -90, double maxAngle = 90, uint numberOfBins = 179)
        {
            float bininterval = (float)(maxAngle - minAngle) / (numberOfBins - 1);
            uint[] bins = new uint[numberOfBins];

            angledatapoints.Sort();

            // sort angles into bins
            uint currBin = 0;
            double _currentanlge;
            for (int i = 0; i < angledatapoints.Count; i++)
            {
                if (angledatapoints[i] > minAngle + bininterval * (currBin))
                {
                    _currentanlge = angledatapoints[i];
                    currBin++;
                    i--;
                    continue;
                }
                bins[currBin-1]++;
            }
            return bins;
        }

    }
}
