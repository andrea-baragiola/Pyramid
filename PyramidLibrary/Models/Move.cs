using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidLibrary.Models;

public class Move
{
    public (IPosition, IPosition) Cohordinates { get; set; }
    public Move(IPosition pos1, IPosition pos2)
    {
        Cohordinates = (pos1,pos2);
    }
}
