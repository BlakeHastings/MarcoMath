// See https://aka.ms/new-console-template for more information
using MarcoObject = MarcoMath.Distributions;
using ScottPlot;
using ScottPlot.WinForms;
using System.Windows;
using MarcoArray = MarcoMath.Distributions;
using MarcoMath.Distributions;
using MarcoMath.Distributions.Extensions;
using TestApp;
using BenchmarkDotNet.Running;
using MathNet.Numerics.Integration;
using MarcoMath.Samplers;
using MarcoMath.Histogram;
using System.Text;




public static class Programmtester2_wHist{


    public static void main()
    {



        Console.WriteLine("Hello, World!");


        double[] CreateXTics(int min, int max, int numberCount)
        {
            var range = Math.Abs(max - min);
            float step = (float)range / (float)numberCount;
            var rtnList = new double[numberCount];
            for (int i = 0; i < rtnList.Length; i++)
                rtnList[i] = -90 + i * step;

            return rtnList;
        }

        //double[] EvaluteDistributionOnX(double[] xticks, MarcoObject.Distribution distribution)
        //{
        //    double[] results = new double[xticks.Length];
        //    for (int i = 0; i < xticks.Length; i++)
        //        results[i] = distribution.Evaluate(xticks[i]);

        //    return results;
        //}

        void DisplayGraph(double[] ticks, double[] evaluatedDist)
        {
            var plt = new ScottPlot.Plot(400, 300);
            plt.AddScatter(ticks, evaluatedDist);
            new ScottPlot.FormsPlotViewer(plt).ShowDialog();
        }

        void DisplayGraphs(double[] ticks, List<double[]> evaluatedDists)
        {
            var plt = new Plot(400, 300);
            evaluatedDists.ForEach(dist => plt.AddScatter(ticks, dist));
            new FormsPlotViewer(plt).ShowDialog();
        }


        //// original way
        //var t = CreateXTics(-90, 90, 10000);

        //var dist = new MarcoObject.Gaussian(-50, 2, 1).AddRange(new List<MarcoObject.Distribution>{
        //    new MarcoObject.Gaussian(50, 3, 1.5),
        //    new MarcoObject.Gaussian(0, 10, 0.7),
        //    new MarcoObject.Gaussian(50, 0.4, -0.1)
        //});
        //var v3 = EvaluteDistributionOnX(t, dist);

        //DisplayGraph(t, v3);

        int samplingNumber = 10000;
        var x = CreateXTics(-90, 90, samplingNumber);
        double[] y = new double[samplingNumber];
        var evaluator = new DistributionEvaluator(-90, 90, samplingNumber);
        var sampler = new RejectionSampler(-90, 90);

        List<Distribution> distList = new List<Distribution>() {
         new CombinedDistribution(new List<Distribution>() {new GaussianDistribution(0, 6, 1), new GaussianDistribution(20, 6, 1) }).Shift(20),
        new CombinedDistribution(new List<Distribution>() {new GaussianDistribution(0, 6, 1), new GaussianDistribution(20, 6, 1) })};

        var distsToDraw = new List<double[]>();
        distList.ForEach(dist => distsToDraw.Add(evaluator.Evaluate(dist)));
        DisplayGraphs(x, distsToDraw);







        /*//DisplayGraphs(x, distsToDraw);
        double[] doubles = new double[1000];
        var dist = new GaussianDistribution(20, 6, 1);

        for (int i = 0; i < doubles.Length; i++)
        {
            doubles[i] = sampler.Sample(dist);
        }*/





        Distribution arrayCombiDist = distList[1];
        arrayCombiDist.Normalize(-90, 90);

        var y2 = evaluator.Evaluate(arrayCombiDist);

        DisplayGraphs(x, new List<double[]>() { y2 });

        double[] doubles = new double[100000];
        var dist = (Distribution)arrayCombiDist;

        for (int i = 0; i < doubles.Length; i++)
        {
            doubles[i] = sampler.Sample(dist);
        }

        StringBuilder stringBuilder = new StringBuilder();
        doubles.ToList().ForEach(x =>
        {
            stringBuilder.AppendLine(x.ToString());
        });

        File.Delete("C:\\Users\\Marco\\Downloads\\output.txt");
        File.WriteAllText("C:\\Users\\Marco\\Downloads\\output.txt", stringBuilder.ToString());

        uint numberOfBins = 179 * 10;
        var bins = Histogram.GetHistBins(doubles.ToList(), -90, 90, numberOfBins);
        var ticks = CreateXTics(-90, 90, (int)numberOfBins);

        var dBins = new double[bins.Length];
        for (int i = 0; i < bins.Length; i++)
        {
            dBins[i] = (double)bins[i];
        }

        var plt = new Plot(400, 300);
        plt.AddScatter(ticks, dBins);
        new FormsPlotViewer(plt).ShowDialog();

        //DisplayGraphs(x, new List<double[]>() { doubles });


        var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
    }
}