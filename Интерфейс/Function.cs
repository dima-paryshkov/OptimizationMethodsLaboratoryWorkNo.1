using System;
using System.Collections.Generic;
using System.Text;

namespace Лабораторная_работа__1_МО.Интерфейс
{
    class Function
    {
        public double Value(double x)
        {
            //return (x - 5) * (x - 5);
            return 0.5 - x / 2 * Math.Exp(-x * x / 4);
        }
    }
}
