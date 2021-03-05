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
            int n = 0;

            while (value > F[n++ + 2]) ;

            return n;
        }

        public void Do(double a, double b, double Eps = 0.001)
        {
            DataTable.ClearTable();
            Data.a = a;
            Data.b = b;
            Data.difference_ab = Math.Abs(Data.b - Data.a);

            int n = Definition_n(Data.difference_ab / Eps);
            int k = 0;
            double temp = F[n - k];
            double temp_2 = F[n + 2];
            double temp_3 = temp / temp_2;
            Data.x1 = Data.a + temp_3 * Data.difference_ab;
            temp = F[++n - k + 1];
            temp_3 = temp / temp_2;
            Data.x2 = Data.a + temp_3 * Data.difference_ab;

            Data.fx1 = Func.Value(Data.x1);
            Data.fx2 = Func.Value(Data.x2);
            DataTable.Add(Data.x1, Data.x2, Data.fx1, Data.fx2, Data.a, Data.b);

            NumberOfIterationsObjectiveFunction = 0;
            while (DataTable.Table[NumberOfIterationsObjectiveFunction++].difference_ab > Eps)
            {
                k++;
                if (Data.fx1 < Data.fx2)
                {
                    Data.b = Data.x2;
                    Data.x2 = Data.x1;
                    Data.fx2 = Data.fx1;
                    temp = F[n - k ];
                    temp_2 = F[n + 2];
                    temp_3 = temp / temp_2;
                    Data.x1 = Data.a + temp_3 * Data.difference_ab;
                    Data.fx1 = Func.Value(Data.x1);
                }
                else
                {
                    Data.a = Data.x1;
                    Data.x1 = Data.x2;
                    Data.fx1 = Data.fx2;
                    temp = F[n - k + 1];
                    temp_3 = temp / temp_2;
                    Data.x2 = Data.a + temp_3 * Data.difference_ab;
                    Data.fx2 = Func.Value(Data.x2);
                }
                DataTable.Add(Data.x1, Data.x2, Data.fx1, Data.fx2, Data.a, Data.b);
            }
            
        }
    }
}
