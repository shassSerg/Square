using System;

namespace ConsoleApp25
{
    class Program
    {
        static int counterCase = 1;
        private static void compareValues(double a1,double a2)
        {
            if (a1 != a2)
                Console.WriteLine("Error.");
            else
                Console.WriteLine("Okay.");
        }
        private static void callCompareValues(double[] _params, double a)
        {
            Console.Write("Case: " + counterCase+". ");
            try
            {
                compareValues(Square.getSquere(_params),a);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: "+e.Message);
            }
            counterCase++;
        }
        private static double getSquareTriangle(double[] _params)
        {
            double p = (_params[0] + _params[1] + _params[2]) / 2.0d;
            return Math.Sqrt(p * (p - _params[0]) * (p - _params[1]) * (p - _params[2]));
        }
        private static double getSquareCircle(double[] _params)
        {
            return Math.Pow(_params[0], 2) * Math.PI;
        }

        /*
         triangle:
            Case: 1. Exception: Value does not fall within the expected range.
            Case: 2. Okay.
            Case: 3. Okay.
            Case: 4. Exception: Value does not fall within the expected range.
         circle:
            Case: 5. Exception: Value does not fall within the expected range.
            Case: 6. Exception: Value does not fall within the expected range.
            Case: 7. Exception: Value does not fall within the expected range.
            Case: 8. Exception: Value does not fall within the expected range.
            Case: 9. Okay.
            Case: 10. Exception: Value does not fall within the expected range.
            Case: 11. Exception: Value does not fall within the expected range.
            Case: 12. Okay.
            Case: 13. Okay.

         */
        static void Main(string[] args)
        {
            Console.WriteLine("triangle:");
            try
            {
                callCompareValues(new double[] { 0.0d },0.0d);
                callCompareValues(new double[] { double.MaxValue }, double.PositiveInfinity);
                callCompareValues(new double[] { 5.0d }, getSquareCircle(new double[] { 5.0d }));
                callCompareValues(new double[] { double.PositiveInfinity }, 0.0d);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("circle:");
            try
            {
                callCompareValues(new double[] { 0.0d,0.0d,0.0d }, 0.0d);
                callCompareValues(new double[] { double.MaxValue, 0.0d, 0.0d }, 0.0d);
                callCompareValues(new double[] { 0.0d,double.MaxValue, 0.0d }, 0.0d);
                callCompareValues(new double[] { 0.0d, 0.0d,double.MaxValue }, 0.0d);
                callCompareValues(new double[] { double.MaxValue, double.MaxValue, double.MaxValue }, double.PositiveInfinity);
                callCompareValues(new double[] { double.MaxValue, double.MaxValue, 0.0d }, double.PositiveInfinity);
                callCompareValues(new double[] { double.PositiveInfinity,0.0d,0.0d }, 0);
                callCompareValues(new double[] { 1.0d, 1.0d, 1.0d }, getSquareTriangle(new double[] { 1.0d, 1.0d, 1.0d }));
                callCompareValues(new double[] { 3.0d, 4.0d, 5.0d }, getSquareTriangle(new double[] { 3.0d, 4.0d, 5.0d }));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
