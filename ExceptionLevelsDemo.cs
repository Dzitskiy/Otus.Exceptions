using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Exceptions
{
    enum WhatToThrow
    {
        Red,
        Purple,
        Blue,
    }




    /// <summary>
    /// Обобшенный класс исключение-болезнь
    /// </summary>
    class IllnessException : Exception { }

    /// <summary>
    /// Частный случай исключения-болезни (IllnessException)
    /// Микробная болезнь
    /// </summary>
    class MicrobeException : IllnessException { }


    /// <summary>
    /// Частный случай исключения-болезни (IllnessException)
    /// Вирусная болезнь
    /// </summary>
    class VirusException : IllnessException { }





    /// <summary>
    /// Красная ошибка
    /// </summary>
    class RedException : Exception
    {
        public RedException() : base("CODE KRASNIY")
        {
        }

        public RedException(string message) : base(message)
        {
        }
    }


    /// <summary>
    /// Фиолетовая ошибка 
    /// Наследуется от Красной ошибки
    /// (частный случай Фиолетовой ошибки)
    /// </summary>
    class PurpleException : RedException
    {
        public PurpleException() : base("CODE FIOLETOVIY")
        {

        }
    }



    /// <summary>
    /// Класс демонстрации рабоыт иерархии вызовово ошиюкт
    /// </summary>
    public static class ExceptionLevelsDemo
    {

        public static void Demo()
        {
            // Демрнстрация обработки ошибок,
            // Которые наследуются друг от друга
            // DemoCure();

            //return;
            // Демонстрация обрабртки ошибок
            // Появляющихся во внутренних функция
            InheritDemo();


        }


        /// <summary>
        /// Демонстрация перехвата
        /// наследуемых исключений
        /// </summary>
        static void InheritDemo()
        {
            Level1(WhatToThrow.Purple);

            Console.WriteLine();
            Console.WriteLine();

            Level1(WhatToThrow.Red);

            Console.WriteLine();
            Console.WriteLine();

            Level1(WhatToThrow.Blue);
        }



        /// <summary>
        /// Функция, в зависимости от a пробрасывающая исключение
        /// </summary>
        /// <param name="a"></param>
        static void Throw(WhatToThrow a)
        {
            switch (a)
            {
                case WhatToThrow.Red:
                    throw new RedException();
                case WhatToThrow.Purple:
                    throw new PurpleException();
                default:
                    throw new InvalidOperationException($"Unknow exception, sorry");
            }
        }


        /// <summary>
        /// Функция уровня 2, обрабатывает ошибки,
        /// которые произощли в функции Trhow
        /// </summary>
        /// <param name="a"></param>
        static void Level2(WhatToThrow a)
        {
            try
            {
                Throw(a);
            }
            // Верхнеуровневая ошибка
            // вызывающая функцию Level2 функция Level1 о ней даже не узнает
            catch (PurpleException e)
            {
                // обрабатывается на месте простым выводом текста
                Console.WriteLine($"LEVEL2: WAITING FOR PURPLE '{e.Message}'");
            }

            // Ошибка Red, родительская по отношению к Purple
            // обрабаытвается здесь
            catch (RedException e)
            {
                // вывод текста
                Console.WriteLine($"LEVEL2: WAITING FOR RED '{e.Message}'");

                // НО при этом мы пробрасываем RedException выше
                // ожидая, что выше ее тоже обработают
                throw;
            }

            // выше мы обработали ошибки RedException, и PurpleException
            // Все остальные ошибки уйдут необработанными уровенем выше (в функцию Level1)
        }



        /// <summary>
        /// Функция уровня 1
        /// обрабатывающая все ошибки в Level2
        /// </summary>
        /// <param name="a"></param>
        static void Level1(WhatToThrow a)
        {

            // тут мы ожидаем, что могут быть ошибки в Level2
            try
            {
                Level2(a);
            }
            // А тут мы их ловим,
            // В функции Level2 обрабатывается
            // без проброса ТОЛЬКО PurpleException
            // Все остальные - обрабатываются тут
            catch (Exception e)
            {
                Console.WriteLine($"Level1: ANY EXCEPTION '{e.Message}'");
            }
        }




        /// <summary>
        ///  Функция обработки исключений-болезни
        /// </summary>
        static void DemoCure()
        {
            try
            {
                Live();
            }

            // Любое вирусное исключение обрабатываем тут
            catch (VirusException e)
            {
                Console.WriteLine("Лечу вирус противовирусными");
            }
            // Все исключения, наследумые от IllnessException (В нашем случае - MicrobeException)
            // Обрабатываем тут
            //
            // КРОМЕ VirusException, его мы обработали выше
            catch (IllnessException)
            {
                Console.WriteLine("Лечу болезнь лекарствами");
            }

            // Все ОСТАЛЬНЫЕ исключения
            // обрабываем тут
            catch (Exception e)
            {
                Console.WriteLine("Организм справится сам");
            }

        }

        /// <summary>
        /// Функция Жить :)
        /// </summary>
        static void Live()
        {
            throw new MicrobeException();
            //throw new MicrobeException();
            // Можно так же проверить (раскомментировать следующие две строки

            var array = new int[] { 1, 2, };
            var f = array[5];


            // Или эту ошибку
            // throw new MicrobeException();

        }





    }
}
