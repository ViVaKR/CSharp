namespace MathEg;

public class VivIntegral
{
    public static double Run(double a, double b, double c, double xa, double xb, int h)
    {
        double xp, y, s, result = 0, g = (xb - xa) / h;
        for (int i = 0; i < h; i++)
        {
            xp = xa + g;
            y = (a * Math.Pow(xp, 2)) + (b * xp) + c;
            s = g * y;
            result += s;
        }
        return result;
    }

    public static double Run(int n)
    {

        double a = 12;
        double b = a + 4.0;
        double area = 0;
        double[] x = new double[n + 1];
        double[] y = new double[n];
        for (int i = 0; i < n; i++)
        {
            double k = (b - a) / n;
            x[i] = Math.Cos(a + 1) + Math.Sin(a) + a;
            Console.WriteLine(x[i + 1]);
            y[i] = (x[i + 1] + x[i]) / 2 * k;
            a += k;
        }

        for (int i = 0; i < n; i++)
        {
            area += y[i];
        }
        return area;
    }
}
