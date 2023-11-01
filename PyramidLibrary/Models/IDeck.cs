﻿namespace PyramidLibrary.Models
{
    public interface IDeck
    {
        List<Card> Cards { get; }

        Card DrowCard();
        Card GiveCard(int x);

        IEnumerable<Card> DrowCards(int numberOfCards);
    }
}