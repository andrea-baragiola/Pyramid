﻿namespace PyramidLibrary.Models.Moves;

public class PyramidPyramidMove : IMove
{

    public Card Card1 { get; set; }
    public Card Card2 { get; set; }
    public string Description => $"{Card1.Name} + {Card2.Name}";

    public PyramidPyramidMove(Card card1, Card card2)
    {
        Card1 = card1;
        Card2 = card2;


    }
}
