using OOPAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Classes
{
    public class CarStringCommandExecutor : CarCommandExecutorBase, IStringCommand
    {
        public CarStringCommandExecutor(ICarCommand carCommand) : base(carCommand)
        {

        }
        public void ExecuteCommand(string commandObject)
        {
            if (string.IsNullOrEmpty(commandObject))
            {
                throw new Exception();
            }

            foreach (var item in commandObject)
            {
                if (item == 'M')
                {
                    CarCommand.Move();
                }
                else if (item == 'R')
                {
                    CarCommand.TurnRight();
                }
                else if (item == 'L')
                {
                    CarCommand.TurnLeft();
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }
}
