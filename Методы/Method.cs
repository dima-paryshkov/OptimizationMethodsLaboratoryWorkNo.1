using System;
using System.Collections.Generic;
using System.Text;
using Лабораторная_работа__1_МО.Интерфейс;

namespace Лабораторная_работа__1_МО.Методы
{
    class Method
    {
        protected DataTable DataTable;

        protected Data Data;

        protected Function Func;

        protected int NumberOfIterationsObjectiveFunction;

        public int getNumberOfIterationsObjectiveFunction()
        {
            return NumberOfIterationsObjectiveFunction;
        }

        public void ShowTable(double Eps)
        {
            DataTable.DrawTable(Eps);
        }
    }
}
