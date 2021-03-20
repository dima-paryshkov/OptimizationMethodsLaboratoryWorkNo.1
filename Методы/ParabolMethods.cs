using System;
using System.Collections.Generic;
using System.Text;
using Лабораторная_работа__1_МО.Интерфейс;

namespace Лабораторная_работа__1_МО.Методы
{
    class ParabolMethods : Method
    {

        public ParabolMethods()
        {
            DataTable = new DataTable();
            Func = new Function();
        }

        double func(double x)
        {
            return Func.Value(x);
        }

        public void Do(double a, double b, double Eps)
        {
            DataTable.ClearTable();
            NumberOfIterationsObjectiveFunction = 0;
            double x1, x2, x3, f1, f2, f3, a1, a2, x, fx, xp;

            x1 = a;
            x2 = (a + b) / 2;
            x3 = b;
            x = 0;
            f1 = func(x1);
            f2 = func(x2);
            f3 = func(x3);
            NumberOfIterationsObjectiveFunction += 3;
            DataTable.Add(x1, x2, f1, f3, a, b);
            do
            {
                xp = x;
                a1 = (f2 - f1) / (x2 - x1);
                a2 = (1 / (x3 - x2)) * ((f3 - f1) / (x3 - x1) - (f2 - f1) / (x2 - x1));
                x = 0.5 * (x1 + x2 - (a1 / a2));
                fx = func(x);
                NumberOfIterationsObjectiveFunction++;
                if (x1 < x && x < x2 && x2 < x3)
                    if (fx >= f2)
                    {
                        x1 = x;
                        f1 = func(x1);
                        NumberOfIterationsObjectiveFunction++;
                    }
                    else
                    {
                        x3 = x2;
                        x2 = x;
                        f2 = func(x2);
                        f3 = func(x3);
                        NumberOfIterationsObjectiveFunction += 2;
                    }
                else 
                    if (x1 < x2 && x2 < x && x < x3)
                        if (fx >= f2)
                        {
                            x3 = x;
                            f3 = func(x3);
                            NumberOfIterationsObjectiveFunction++;
                        }
                        else
                        {
                            x1 = x2;
                            x2 = x;
                            f1 = func(x1);
                            f2 = func(x2);
                            NumberOfIterationsObjectiveFunction += 2;
                        }
                DataTable.Add(x1, x2, f1, f3, a, b);
            }
            while (Math.Abs(xp - x) > Eps);
            
        }
    }
}
