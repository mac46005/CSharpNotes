using System;

namespace DelegatesPart3
{
    class Program
    {
        delegate void LogIceCarDetails(ICECar iCECar);
        delegate void LogEVCarDetails(EVCar eVCar);
        static void Main(string[] args)
        {

            CarFactoryDel carFactoryDel = CarFactory.ReturnICECar;

            Car iceCar = carFactoryDel(1,"Audi R8");


            Console.WriteLine($"Object type: {iceCar.GetType()}");
            Console.WriteLine($"Car Details: {iceCar.GetCarDetails()}");


            carFactoryDel = CarFactory.ReturnEVCar;
            Car evCar = carFactoryDel(32, "Tesla Model - 3");

            Console.WriteLine($"Object type: {evCar.GetType()}");
            Console.WriteLine($"Car Details: {evCar.GetCarDetails()}");

            Console.ReadKey();

            Console.WriteLine();


            Console.WriteLine("Hello World!");



        }
    }
    delegate Car CarFactoryDel(int id, string name);
    public static class CarFactory
    {
        public static ICECar ReturnICECar(int id,string name)
        {
            return new ICECar { Id = id, Name = name };
        }

        public static EVCar ReturnEVCar(int id,string name)
        {
            return new EVCar { Id = id, Name = name };
        }

    }

    public abstract class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual string GetCarDetails()
        {
            return $"{Id} - {Name}";
        }

    }

    public class ICECar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Internal Combustion Engine";
        }
    }

    public class EVCar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Electric";
        }
    }

}
