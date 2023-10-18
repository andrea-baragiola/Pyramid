using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidLibrary.Models
{
    public class BoardPosition : IPosition
    {
        public (string?, int?) Id { get; set; }
        public Card? Card { get; set; }
        public string? Row { get; set; }
        public int? Shift { get; set; }
        public BoardPositionStatus Status { get; set; }


        public BoardPosition(string row, int shift, BoardPositionStatus status, Card card)
        {
            Id = (row, shift);
            Row = row;
            Shift = shift;
            Status = status;
            Card = card;
        }
    }
}
