using System;
using System.Collections.Generic;
using System.Text;

namespace Лабораторная_работа__1_МО.Интерфейс
{
    class Data
    {
        public double x1;

        public double x2;

        public double fx1;

        public double fx2;

        public double a;

        public double b;

        public double difference_ab;

        public double ratioOfIterations;

        public Data(double x1, double x2, double fx1, double fx2, double a, double b, double ratioOfIterationsIlast = 1)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.fx1 = fx1;
            this.fx2 = fx2;
            this.a = a;
            this.b = b;
            difference_ab = Math.Abs(a - b);
            if (ratioOfIterationsIlast == 1)
                ratioOfIterations = 0;
            else
                ratioOfIterations = ratioOfIterationsIlast / difference_ab;
        }

    }
}
