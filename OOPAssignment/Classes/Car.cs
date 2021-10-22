using OOPAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Classes
{
    public class Car : ICarCommand, Interfaces.IObservable<CarInfo>
    {
        public Guid CarId;

        public Coordinates Coordinates;

        public Direction Direction;

        ISurface Surface;
        public Car(Coordinates coordinates, Direction direction, ISurface surface)
        {
            Coordinates = coordinates;
            Direction = direction;
            Surface = surface;
        }

        private Interfaces.IObserver<CarInfo> Observer;
        public void Attach(Interfaces.IObserver<CarInfo> observer)
        {
            Observer = observer;
            Notify();
        }

        public void Move()
        {
            if (Direction == Direction.N)
            {
                Coordinates.Y++;
            }
            else if (Direction == Direction.S)
            {
                Coordinates.Y--;
            }
            else if (Direction == Direction.E)
            {
                Coordinates.X++;
            }
            else if (Direction == Direction.W)
            {
                Coordinates.Y--;
            }

            Notify();
        }

        public void Notify()
        {
            Observer.Update(new CarInfo(CarId, Coordinates));
        }

        public void TurnLeft()
        {
            if (Direction == Direction.E)
            {
                Direction = Direction.N;
            }
            else if (Direction == Direction.N)
            {
                Direction = Direction.W;
            }
            else if (Direction == Direction.W)
            {
                Direction = Direction.S;
            }
            else if (Direction == Direction.S)
            {
                Direction = Direction.E;
            }

        }

        public void TurnRight()
        {
            if (Direction == Direction.E)
            {
                Direction = Direction.S;
            }
            else if (Direction == Direction.S)
            {
                Direction = Direction.W;
            }
            else if (Direction == Direction.W)
            {
                Direction = Direction.N;
            }
            else if (Direction == Direction.N)
            {
                Direction = Direction.E;
            }
        }
    }
}
