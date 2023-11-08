using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarcoObject = MarcoMath.Distributions;
using MarcoMath.Distributions;
using MarcoMath.Samplers;

namespace TestApp
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DistributionBenchmark
    {
        double[] _ticks { get; set; }
        int _sampleRate { get; set; }


        [GlobalSetup]
        public void GlobalSetup()
        {
            _sampleRate = 1000;
            _ticks = CreateXTics(-90, 90, _sampleRate);   
        }
        private double[] CreateXTics(int min, int max, int numberCount)
        {
            var range = Math.Abs(max - min);
            float step = (float)range / (float)numberCount;
            var rtnList = new double[numberCount];
            for (int i = 0; i < rtnList.Length; i++)
                rtnList[i] = -90 + i * step;

            return rtnList;
        }

        [Benchmark]
        public void MarcoBenchmark()
        {
            double[] y = new double[_sampleRate];

            var sampler = new RejectionSampler(-90,90);

            List<Distribution> distListarry = new List<Distribution>() {
                new GaussianDistribution(-50, 2, 1),
                new GaussianDistribution(50, 3, 1.5),
                new GaussianDistribution(0, 10, 0.7),
                new GaussianDistribution(50, 0.4, -0.1)
            };
            CombinedDistribution arrayCombiDist = new CombinedDistribution(distListarry);

            var result = sampler.Sample(arrayCombiDist);
        }

    }
}
