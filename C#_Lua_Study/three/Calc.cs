using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace three
{
    class Calc
    {
        public static string name = "Calc计算器类";

        public static int Jia(int a, int b)
        {
            return a + b;
        }

        public static int Jian(int a, int b)
        {
            return a - b;
        }

        public static int Cheng(int a, int b)
        {
            return a * b;
        }

        public static int Chu(int a, int b)
        {
            return a / b;
        }

        public static void Show()
        {
            Console.WriteLine("Calc类内的方法");
        }
    }
}
