using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Exceptions
{
    /// <summary>
    /// Демонстрация условных исключений
    /// </summary>
    public static class ComplexExceptionDemo
    {

        /// <summary>
        /// Демо
        /// </summary>
        public static void Demo()
        {
            // Массив для получения элементов
            int[] array = new int[] { 1, 2, 3, 4, 5 };


            // Получение нулевого элемента массива
            GetItem(array, 0);

            // Получение минус первого элемента (Исключение)

            GetItem(array, -1);

            GetItem(array, 3);

            // получение 11 элемента массив (Исключение)
            GetItem(array, 11);

            // Получение 11 элемента из нула (Исключение)
            GetItem(null, 11);
        }


        static string Print(int[] arr)
        {
            if (arr == null)
            {
                return "[]";
            }
            return $"[{string.Join(',', arr)}]";
        }


        /// <summary>
        /// Получение элемента под индексом из массива
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        static int GetItem(int[] arr, int index)
        {

            // Пытается получить элемент массив
            try
            {
                Console.WriteLine();
                Console.WriteLine($"array={Print(arr)} index={index}");
                return arr[index];

            }
            //catch (IndexOutOfRangeException)
            //{
            //	if (index < 0)
            //	{
            //                 Console.WriteLine("Less than zero");
            //             }
            //	else
            //	{
            //                 Console.WriteLine("Out of range");
            //             }
            //}



            // Если ушли за границу массива   И индекс меньше 0 (напрмиер -1)
            catch (IndexOutOfRangeException) when (index < 0)
            {
                // обрабатываем так
                Console.WriteLine("Less than zero");
            }
            // Если ушли за границу массива при других значениях индекса (например 11й элемент)
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Out of range");
            }
            // Если получили другую ошибку (NullReferenceException)
            catch
            {
                Console.WriteLine("Other");
            }
            return 0;
        }

    }
}
