using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidLibrary.Models
{
    public class Position
    {


        public int Row { get; set; }
        public int Index { get; set; }
        public Position(int row, int index)
        {
            Row = row;
            Index = index;
        }


    }
}
