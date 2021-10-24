using System;

namespace ClassLibraryTask2
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int EngineCapacity { get; set; }

        public Car()
        {

        }

        public static bool GetIsBigger(Car car) =>
            car.EngineCapacity > 2 ? true : false;
    }
}
