using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidLibrary.Models;

public class Player
{
    public Board Board { get; set; }

    public Player()
    {
        Board = new(5);
    }

    public void ExecuteMove(Move move)
    {
        Card descardedCard = move.Cohordinates.Item1.Card;

    }
}
