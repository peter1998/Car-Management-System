using Car_Management_System.Models;

namespace Car_Management_System.Services
{

    public class CarService : ICarService
    {
        private List<Car> _cars;
        public CarService()
        {
            _cars = new() { new Car { Id = Guid.NewGuid(), Owner = "Mr. Miyagi", Brand = Data.Enums.CarBrand.GTA, Model = Data.Enums.CarModel.Jeep, Color = "blue", EngineCapacity = 1200, Registration = "08-TN-231053", HorsePower = 200 } };
        }

        public void CreateCar(Car car)
        {
            _cars.Add(car);
        }

        public void DeleteCar(Guid id)
        {
            var carIndex = _cars.FindIndex(x => x.Id == id);

            if (carIndex > -1)
            {
                _cars.RemoveAt(carIndex);
            }
        }

        public Car GetCar(Guid id)
        {
            var car = _cars.Where(x => x.Id == id).SingleOrDefault();
            return car;
        }

        public IEnumerable<Car> GetCars()
        {
            return _cars;
        }

        public void UpdateCar(Guid id, Car car)
        {
            var carIndex = _cars.FindIndex(x => x.Id == id);
            if (carIndex>-1)
            {
                _cars[carIndex] = car;
            }
            
        }
    }
}
