using OOPAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Classes
{
    public class Surface : ISurface, ICollidableSurface, Interfaces.IObserver<CarInfo>
    {
        long _width;

        long _height;

        public Surface(long width, long height)
        {
            _width = width;
            _height = height;
        }
        public long Width => _width;
        public long Height => _height;

        private readonly List<CarInfo> ObservablesCars = new List<CarInfo>();
        public List<CarInfo> GetObservables()
        {
            List<CarInfo> GetCars = new List<CarInfo>();
            if (ObservablesCars != null)
            {
                foreach (var item in ObservablesCars)
                {
                    GetCars.Add(item);
                }
            }
            return GetCars;
        }

        public bool IsCoordinatesEmpty(Coordinates coordinates)
        {
            if (ObservablesCars != null)
            {
                foreach (var item in ObservablesCars)
                {
                    if (item.Coordinates.X == coordinates.X && item.Coordinates.Y == coordinates.Y)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsCoordinatesInBounds(Coordinates coordinates)
        {
            if (coordinates.X > Width || coordinates.Y > Height || coordinates.X < 0 || coordinates.Y < 0)
            {
                return false;
            }
            return true;
        }

        public void Update(CarInfo provider)
        {

            if (IsCoordinatesInBounds(provider.Coordinates) == false)
            {
                throw new Exception("Sınır aşıldı");
            }
            var carss = ObservablesCars.FirstOrDefault(c => c.CarId == provider.CarId);
            if (carss != null)
            {
                carss = provider;
            }
            if (IsCoordinatesEmpty(provider.Coordinates) == true)
            {
                ObservablesCars.Add(provider);
            }

            else
            {
                var cars = ObservablesCars.FirstOrDefault(c => c.CarId == provider.CarId);
                if (cars.Coordinates.X == provider.Coordinates.X && cars.Coordinates.Y == provider.Coordinates.Y)
                {
                    throw new Exception("Çakışma");

                }
                else
                    ObservablesCars.Add(provider);
            }

        }
    }
}
