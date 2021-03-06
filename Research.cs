﻿using System;
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
            Console.WriteLine("{0,20} {1,13} {2,13} {3,13} {4,13} {5,12} {6,14} {7,12" +
                "}", "Name Method | Eps", 1E-1, 1E-2, 1E-3, 1E-4, 1E-5, 1E-6, 1E-7);

            Console.Write("{0,20}", "Dichometrics      ");
            for (int i = 0; i < 7; i++)
            {
                DichometricsMethod.Do(a, b, Eps);
                Console.Write("{0,10}({1,2})", DichometricsMethod.getNumberOfIterationsObjectiveFunction(), DichometricsMethod.NumberOfIteration);
                Eps /= 1E+1;
            }
            Console.WriteLine();

            Eps = 1E-1;
            Console.Write("{0,20}", "Golden Section      ");
            for (int i = 0; i < 7; i++)
            {
                GoldenSectionMethod.Do(a, b, Eps);
                Console.Write("{0,10}({1,2})", GoldenSectionMethod.getNumberOfIterationsObjectiveFunction(), GoldenSectionMethod.NumberOfIteration);
                Eps /= 1E+1;
            }
            Console.WriteLine();

            Eps = 1E-1;
            Console.Write("{0,14}      ", "Fibonacci");
            for (int i = 0; i < 7; i++)
            {
                FibonacciMethod.Do(a, b, Eps);
                Console.Write("{0,10}({1,2})", FibonacciMethod.getNumberOfIterationsObjectiveFunction(), FibonacciMethod.NumberOfIteration);
                Eps /= 1E+1;
            }
            Console.WriteLine();

            Eps = 1E-1;
            Console.Write("{0,20}", "Parabol      ");
            for (int i = 0; i < 7; i++)
            {
                ParabolMethods.Do(a, b, Eps);
                Console.Write("{0,10}({1,2})", ParabolMethods.getNumberOfIterationsObjectiveFunction(), ParabolMethods.NumberOfIteration);
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
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Number Of Iterations Objective Function: ");
            //allIteration(-2, 20);
            Console.WriteLine();
            showTable(-2, 20, 1E-7);


            //ParabolMethods ParabolMethods = new ParabolMethods();
            //Console.WriteLine("Parabol Method: ");
            //ParabolMethods.Do(2, 5, 1E-7);
            //Console.WriteLine("Number Of Iterations: " + ParabolMethods.getNumberOfIterationsObjectiveFunction());
            //ParabolMethods.ShowTable(1E-7);

            //Console.WriteLine("Finding an interval containing a minimum: ");
            //IntervalSearch IntervalSearch = new IntervalSearch();
            //IntervalSearch.Search(0, 1E-2);
            //IntervalSearch.ShowResult();

            Console.ReadLine();
        }
    }
}
