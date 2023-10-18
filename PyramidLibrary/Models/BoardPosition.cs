using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidLibrary.Models
{
    public class BoardPosition : IPosition
    {
        public (int?, int?) Id { get; set; }
        public Card? Card { get; set; }
        public int? Row { get; set; }
        public int? Shift { get; set; }
        public BoardPositionStatus Status { get; set; }


        public BoardPosition(int shift, int row, Card card)
        {
            Id = (row, shift);
            Row = row;
            Shift = shift;
            Card = card;
        }
    }
}
