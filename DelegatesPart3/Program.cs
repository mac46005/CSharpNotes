using System;
using System.IO;

namespace DelegatesPart3
{
    class Program
    {
        delegate void LogIceCarDetailsDel(ICECar iCECar);
        delegate void LogEVCarDetailsDel(EVCar eVCar);
        static void Main(string[] args)
        {

            //               Covariance
            CarFactoryDel carFactoryDel = CarFactory.ReturnICECar;

            Car iceCar = carFactoryDel(1, "Audi R8");



            carFactoryDel = CarFactory.ReturnEVCar;
            Car evCar = carFactoryDel(32, "Tesla Model - 3");

            



            //              Contravariance
            LogIceCarDetailsDel logIceCarDetailsDel = LogCarDetails;

            logIceCarDetailsDel(iceCar as ICECar);


            LogEVCarDetailsDel logEvCarDetailsDel = LogCarDetails;

            logEvCarDetailsDel(evCar as EVCar);


            Console.ReadKey();

        }

        static void LogCarDetails(Car car)
        {
            if(car is ICECar)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "IceDetails.txt")))
                {
                    sw.WriteLine($"Object Type: {car.GetType()}");
                    sw.WriteLine($"Car Details: {car.GetCarDetails()}");
                }
            }
            else if(car is EVCar)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EVDetails.txt")))
                {
                    sw.WriteLine($"Object Type: {car.GetType()}");
                    sw.WriteLine($"Car Details: {car.GetCarDetails()}");
                }
            }
            else
            {
                throw new ArgumentException("Not a Car object!");
            }



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
