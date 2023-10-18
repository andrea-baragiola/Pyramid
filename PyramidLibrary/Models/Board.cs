using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidLibrary.Models
{
    public class Board
    {
        public List<BoardPosition> RowA { get; set; }
        public List<BoardPosition> RowB { get; set; }
        public List<BoardPosition> RowC { get; set; }
        public List<BoardPosition> RowD { get; set; }

        public List<BoardPosition> AllPositions { get; set; }

    }
}
