using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Interfaces
{
    public interface ISurface
    {
        long Width { get; }
        long Height { get; }
        bool IsCoordinatesInBounds(Coordinates coordinates);
    }
}
