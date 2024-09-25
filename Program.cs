//System.DivideByZeroException: Attempted to divide by zero.
using Otus.Exceptions;
using System.Threading.Tasks.Sources;

var a = 0;
var b = 4;
//Console.WriteLine(b / a);


//System.IndexOutOfRangeException: 'Index was outside the bounds of the array.'
var arr = new[] { 1, 2, 3 };
//Console.WriteLine(arr[5]);

var facnyCar = new Car("asdasad");
facnyCar.Name = "A";

ComplexExceptionDemo.Demo();
//ExceptionLevelsDemo.Demo();

//SomeMethod();


static void SomeMethod()
{
    AnotherOneMethod();
}

static void AnotherOneMethod()
{
    InnerMethod();
}

static void InnerMethod()
{
    Console.WriteLine(Divide(4, 2));
    Console.WriteLine("---------------");
    Console.WriteLine(Divide(4, 0));

    var a = 0;
    var b = 4;

    //if (a == 0)
    //{
    //    Console.WriteLine("Call InnerMethod");

    //    //throw new Exception("Something wrong!");

    //    var ex = new SomethingWrongException("Something wrong!");

    //    ex.TimeStamp = DateTime.Now;

    //    ex.Data.Add("timestamp", DateTime.Now);
    //    ex.Data.Add("a", a);
    //    ex.Data.Add("b", b);

    //    throw ex;
    //}
    //else 
    //{
    //    Console.WriteLine(b / a);
    //}

    //FileStream f;

    try
    {
        //f = new FileStream("f.txt", FileMode.Open);
        //f.Write("dddsds");

        if (b == 0)
        {
            //throw
            new DivideByZeroException("Делим на ноль!");
            //return a / b;
        }
        else
        {
            Console.WriteLine(b / a);


        }

        

    }
    catch (SomethingWrongException ex)
    {
        Console.WriteLine("Обработка ошибки в catch");
        throw;
        //throw ex;


        //return 0.0;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Обработка ошибки в catch");
        throw;
        //throw ex;

       
        //return 0.0;
    }
    //catch {

    //    Console.WriteLine("Ошибка!");
    //}
    //catch (Exception e)
    //{
    //    Console.WriteLine("Произошла ошибка");
    //    //return 0.0;
    //}
    finally
    {
        //f.Dispose();

        Console.WriteLine("Я блок finally ");
    }
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
    finally
    {
        Console.WriteLine("Я блок finally");
    }
}


class SomethingWrongException : Exception 
{
    public DateTime TimeStamp;

    public SomethingWrongException(string message) : base(message) { }
}


/// <summary>
/// Транспортное средство
/// </summary>
class Vehicle
{
    /// <summary>
    /// Название 
    /// </summary>
    public string Name;
}

class Car : Vehicle
{
    public Car(string vin)
    {
        Vin = vin;
    }

    /// <summary>
    /// Vin-номер
    /// </summary>
    public string Vin;

}