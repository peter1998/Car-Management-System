using Car_Management_System.Dtos;
using Car_Management_System.Models;
using Car_Management_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Car_Management_System.Controllers
{
    [ApiController]
    [Route("cars")]
    public class CarsController:ControllerBase
    {
        private ICarService _carRepo;
        public CarsController(ICarService carRepo)
        {
            _carRepo = carRepo;
            //_carRepo = new CarRepo();
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarDTO>> GetCars()
        {
            return _carRepo.GetCars()
                .Select(x=> new CarDTO { 
                    Id=x.Id,Model=x.Model,
                    Brand=x.Brand,
                    Registration=x.Registration,
                    HorsePower=x.HorsePower,
                    Owner=x.Owner,
                    Color=x.Color,
                    EngineCapacity=x.EngineCapacity})
                .ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<CarDTO> GetCar(Guid id)
        {
            var car = _carRepo.GetCar(id);

            if (car ==null)
            {
                return NotFound();
            }

            var carDTO = new CarDTO
            {
                Id = car.Id,
                Owner = car.Owner,
                EngineCapacity = car.EngineCapacity,
                Registration = car.Registration,
                HorsePower = car.HorsePower,
                Brand = car.Brand,
                Color = car.Color,
                Model = car.Model
            };

            return carDTO;
        }

        [HttpPost]
        public ActionResult CreateCar(CreateOrUpdateCarDTO car)
        {
            var myCar = new Car();
            myCar.Id = Guid.NewGuid();
            myCar.Owner = car.Owner;
            myCar.EngineCapacity = car.EngineCapacity;
                myCar.HorsePower=car.HorsePower;
            myCar.Brand = car.Brand;
            myCar.Model= car.Model;
            myCar.Color = car.Color;
            myCar.Registration = car.Registration;

            _carRepo.CreateCar(myCar);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCar(Guid id,CreateOrUpdateCarDTO car)
        {
            var myCar = _carRepo.GetCar(id);

            if (myCar==null)
            {
                return NotFound();
            }

            myCar.Owner = car.Owner;
            myCar.EngineCapacity = car.EngineCapacity;
            myCar.HorsePower = car.HorsePower;
            myCar.Brand = car.Brand;
            myCar.Model = car.Model;
            myCar.Color = car.Color;
            myCar.Registration = car.Registration;

            _carRepo.UpdateCar(id, myCar);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCar(Guid id)
        {
            var car = _carRepo.GetCar(id);
            if (car ==null)
            {
               return NotFound();
            }
            _carRepo.DeleteCar(id);
            return Ok();
        }
    }
}
