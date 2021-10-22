using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Classes
{
    public class CarInfo
    {
        public Guid CarId;

        public Coordinates Coordinates;
        public CarInfo(Guid carId, Coordinates coordinates)
        {
            CarId = carId;
            Coordinates = coordinates;
        }
    }
}
