using System;
using Лабораторная_работа__1_МО.Интерфейс;
using Лабораторная_работа__1_МО.Методы;

namespace Лабораторная_работа__1_МО
{
    class Research
    {
        public static void allIteration(double a, double b)
        {
            DichometricsMethod DichometricsMethod = new DichometricsMethod();
            GoldenSectionMethod GoldenSectionMethod = new GoldenSectionMethod();
            FibonacciMethod FibonacciMethod = new FibonacciMethod();
            ParabolMethods ParabolMethods = new ParabolMethods();

            double Eps = 1E-1;
            int N = 7;
            Console.WriteLine("{0,20} {1,10} {2,10} {3,10} {4,10} {5,8} {6,9} {7,9}", "Name Method | Eps", 1E-1, 1E-2, 1E-3, 1E-4, 1E-5, 1E-6, 1E-7);

            Console.Write("{0,20}", "Dichometrics      ");
            for (int i = 0; i < 7; i++)
            {
                DichometricsMethod.Do(a, b, Eps);
                Console.Write("{0,10}", DichometricsMethod.getNumberOfIterationsObjectiveFunction());
                Eps /= 1E+1;
            }
            Console.WriteLine();

            Eps = 1E-1;
            Console.Write("{0,20}", "Golden Section      ");
            for (int i = 0; i < 7; i++)
            {
                GoldenSectionMethod.Do(a, b, Eps);
                Console.Write("{0,10}", GoldenSectionMethod.getNumberOfIterationsObjectiveFunction());
                Eps /= 1E+1;
            }
            Console.WriteLine();

            Eps = 1E-1;
            Console.Write("{0,20}", "Fibonacci      ");
            for (int i = 0; i < 7; i++)
            {
                FibonacciMethod.Do(a, b, Eps);
                Console.Write("{0,10}", FibonacciMethod.getNumberOfIterationsObjectiveFunction());
                Eps /= 1E+1;
            }
            Console.WriteLine();

            Eps = 1E-1;
            Console.Write("{0,20}", "Parabol      ");
            for (int i = 0; i < 7; i++)
            {
                ParabolMethods.Do(a, b, Eps);
                Console.Write("{0,10}", ParabolMethods.getNumberOfIterationsObjectiveFunction());
                Eps /= 1E+1;
            }
            Console.WriteLine();
        }

        public static void showTable(double a, double b, double Eps)
        {
            DichometricsMethod DichometricsMethod = new DichometricsMethod();
            GoldenSectionMethod GoldenSectionMethod = new GoldenSectionMethod();
            FibonacciMethod FibonacciMethod = new FibonacciMethod();
            ParabolMethods ParabolMethods = new ParabolMethods();


            Console.WriteLine("Dichometrics Method: ");
            DichometricsMethod.Do(a, b, Eps);
            Console.WriteLine("Number Of Iterations: " + DichometricsMethod.getNumberOfIterationsObjectiveFunction());
            DichometricsMethod.ShowTable(Eps);

            Console.WriteLine("GoldenSection Method: ");
            GoldenSectionMethod.Do(a, b, Eps);
            Console.WriteLine("Number Of Iterations: " + GoldenSectionMethod.getNumberOfIterationsObjectiveFunction());
            GoldenSectionMethod.ShowTable(Eps);

            Console.WriteLine("Fibonacci Method: ");
            FibonacciMethod.Do(a, b, Eps);
            Console.WriteLine("Number Of Iterations: " + FibonacciMethod.getNumberOfIterationsObjectiveFunction());
            FibonacciMethod.ShowTable(Eps);

            Console.WriteLine("Parabol Method: ");
            ParabolMethods.Do(a, b, Eps);
            Console.WriteLine("Number Of Iterations: " + ParabolMethods.getNumberOfIterationsObjectiveFunction());
            ParabolMethods.ShowTable(Eps);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Number Of Iterations Objective Function: ");
            allIteration(-2, 20);
            Console.WriteLine();
            showTable(-2, 20, 1E-7);

            Console.WriteLine("Finding an interval containing a minimum: ");
            IntervalSearch IntervalSearch = new IntervalSearch();
            IntervalSearch.Search(0, 1E-2);
            IntervalSearch.ShowResult();

            Console.ReadLine();
        }
    }
}
