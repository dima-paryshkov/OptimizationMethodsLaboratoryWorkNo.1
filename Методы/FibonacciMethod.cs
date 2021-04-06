using System;
using System.Collections.Generic;
using System.Text;
using Лабораторная_работа__1_МО.Интерфейс;

namespace Лабораторная_работа__1_МО.Методы
{
    class FibonacciMethod : Method
    {
        List<int> F;
        public FibonacciMethod()
        {
            DataTable = new DataTable();
            Func = new Function();
            Data = new Data(0, 0, 0, 0, 0, 1);
            F = new List<int>();
            F.Add(1);
            F.Add(1);

            const int n = 150;
            for (int i = 0; i < n; i++)
                F.Add(F[i] + F[i + 1]);
        }

        int Definition_n(double value)
        {
            int n = 1;

            while (value > F[n]) n++;

            return n ;
        }


        public void Do2(double ac, double bc, double Eps = 0.001)
        {
            double a = ac, b = bc;
            NumberOfIteration = 1;
            DataTable.ClearTable();
            NumberOfIterationsObjectiveFunction = 0;
            int i = 1;
            int k = 0;
            double res = (b - a) / Eps;
            while (res >= F[i])
                i++;

            i = i - 2 - 1;

            double temp = F[i];
            double temp_2 = F[i + 2];
            double temp_3 = temp / temp_2;
            double x1 = a + temp_3 * (b - a);
            double x2 = a + b - x1;
            double s;

            double f1 = Func.Value(x1);
            double f2 = Func.Value(x2);

            while (Math.Abs(b - a) > Eps)
            {
                if (f1 < f2)
                {
                    b = x2;
                    x2 = x1;
                    f2 = f1;
                    temp = F[i - k + 1];
                    temp_2 = F[i - k + 3];
                    temp_3 = temp / temp_2;
                    x1 = a + temp_3 * (b - a);
                    f1 = Func.Value(x1);
                }
                else
                {
                    a = x1;
                    x1 = x2;
                    f1 = f2;
                    temp = F[i - k + 2];
                    temp_2 = F[i - k + 3];
                    temp_3 = temp / temp_2;
                    x2 = a + temp_3 * (b - a);
                    f2 = Func.Value(x2);
                }
                k++;
                NumberOfIteration++;
                DataTable.Add(x1, x2, f1, f2, a, b);
                NumberOfIterationsObjectiveFunction++;
            }
        }

        public void Do(double a, double b, double Eps = 0.001)
        {
            NumberOfIteration = 1;
            DataTable.ClearTable();
            Data.a = a;
            Data.b = b;
            Data.difference_ab = Math.Abs(Data.b - Data.a);

            int n = 1;
            while (Data.difference_ab / Eps > F[n]) 
                n++;
            // МЕНЯТЬ ТУТ
            n = n - 2 - 1;
            // МЕНЯТЬ ТУТ
            int k = 0;
            double temp = F[n];
            double temp_2 = F[n + 2];
            double temp_3 = temp / temp_2;
            Data.x1 = Data.a + temp_3 * Data.difference_ab;
            Data.x2 = Data.a + Data.b - Data.x1;

            Data.fx1 = Func.Value(Data.x1);
            Data.fx2 = Func.Value(Data.x2);

            NumberOfIterationsObjectiveFunction = 1;
            while (Math.Abs(Data.b - Data.a) > Eps )
            {
                if (Data.fx1 < Data.fx2)
                {
                    Data.b = Data.x2;
                    Data.x2 = Data.x1;
                    Data.fx2 = Data.fx1;
                    temp = F[n - k + 1];
                    temp_2 = F[n - k + 3];
                    temp_3 = temp / temp_2;
                    Data.x1 = Data.a + temp_3 * Math.Abs(Data.b - Data.a);
                    Data.fx1 = Func.Value(Data.x1);
                }
                else
                {
                    Data.a = Data.x1;
                    Data.x1 = Data.x2;
                    Data.fx1 = Data.fx2;
                    temp = F[n - k + 2];
                    temp_2 = F[n - k + 3];
                    temp_3 = temp / temp_2;
                    Data.x2 = Data.a + temp_3 * Math.Abs(Data.b - Data.a);
                    Data.fx2 = Func.Value(Data.x2);
                }
                k++;
                NumberOfIteration++;
                DataTable.Add(Data.x1, Data.x2, Data.fx1, Data.fx2, Data.a, Data.b);
                NumberOfIterationsObjectiveFunction++;
            }
        }
    }
}

