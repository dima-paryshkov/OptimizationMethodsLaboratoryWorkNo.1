using System;
using System.Collections.Generic;
using System.Text;
using Лабораторная_работа__1_МО.Интерфейс;

namespace Лабораторная_работа__1_МО.Методы
{
    class DichometricsMethod : Method
    {
        public DichometricsMethod()
        {
            DataTable = new DataTable();
            Func = new Function();
            Data = new Data(0, 0, 0, 0, 0, 1);
        }

        public void Do(double a, double b, double Eps = 0.001)
        {
            DataTable.ClearTable();
            double Delta = Eps / 10;
            Data.a = a;
            Data.b = b;
            Data.x1 = (Data.a + Data.b - Delta) / 2;
            Data.x2 = (Data.a + Data.b + Delta) / 2;
            Data.fx1 = Func.Value(Data.x1);
            Data.fx2 = Func.Value(Data.x2);
            DataTable.Add(Data.x1, Data.x2, Data.fx1, Data.fx2, Data.a, Data.b);

            NumberOfIterationsObjectiveFunction = 0;
            while (DataTable.Table[NumberOfIterationsObjectiveFunction++].difference_ab > Eps)
            {
                if (Data.fx1 < Data.fx2)
                    Data.b = Data.x2;
                else
                    Data.a = Data.x1;
                Data.x1 = (Data.a + Data.b - Delta) / 2;
                Data.x2 = (Data.a + Data.b + Delta) / 2;
                Data.fx1 = Func.Value(Data.x1);
                Data.fx2 = Func.Value(Data.x2);
                DataTable.Add(Data.x1, Data.x2, Data.fx1, Data.fx2, Data.a, Data.b);
            }
            NumberOfIterationsObjectiveFunction *= 2;
        }
    }
}
