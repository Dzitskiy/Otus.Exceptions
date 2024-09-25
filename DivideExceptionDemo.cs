using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Exceptions
{

    /// <summary>
    /// Класс демонстрации работы иерархии вызовов ошибок
    /// </summary>
    public static class DivideExceptionDemo
    {

        public static void Demo()
        {
            Console.WriteLine(Divide(4, 2));
            Console.WriteLine("---------------");
            Console.WriteLine(Divide(4, 0));
        }

        static double Divide(int a, int b)
        {
            try
            {
                Console.WriteLine("Я блок try");
                return a / b;
            }
            catch (Exception)
            {
                Console.WriteLine("Произошла ошибка");
                return 0;
            }
            /**/finally
            /**/{
                Console.WriteLine("Я блок finally");
            /**/}
        }


        class SomethingWrongException : Exception
        {
            public DateTime TimeStamp;

            public SomethingWrongException(string message) : base(message) { }
        }

    }
}
