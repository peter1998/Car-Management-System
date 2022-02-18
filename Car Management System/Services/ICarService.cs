using Car_Management_System.Models;

namespace Car_Management_System.Services
{
    public interface ICarService
    {
        public IEnumerable<Car> GetCars();

        public Car GetCar(Guid id);

        public void CreateCar(Car car);

        public void UpdateCar(Guid id, Car car);
        public void DeleteCar(Guid id);


    }
}
