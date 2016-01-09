using System;

public class Generator
{
    public static GaussRandom gr = new GaussRandom();
    public static Random rnd = new Random();

    public Generator()
    {
    }

    public static int Next(int from, int to)
    {
        return gr.Next(from, to);
    }

    public static string getUID()
    {
        return System.Guid.NewGuid().ToString();
    }
}

public class GaussRandom : Random
{
    private double cache;
    private bool isCacheFilled = false;

    const double mean = 0.5;
    const double standardDeviation = 0.5 / Math.PI;

    private double Trunc(double value)
    {
        if (value < 0.0 || value >= 1.0) return this.Sample();
        return value;
    }

    protected override double Sample()
    {
        if (isCacheFilled)
        {
            isCacheFilled = false;
            return cache;
        }

        double r = 0.0;
        double x = 0.0;
        double y = 0.0;

        do
        {
            x = 2.0 * base.Sample() - 1.0;
            y = 2.0 * base.Sample() - 1.0;
            r = x * x + y * y;
        }
        while (r >= 1.0 || r == 0.0);

        double z = Math.Sqrt(-2.0 * Math.Log(r) / r);

        cache = Trunc(mean + standardDeviation * x * z);
        isCacheFilled = true;

        return Trunc(mean + standardDeviation * y * z);
    }
}