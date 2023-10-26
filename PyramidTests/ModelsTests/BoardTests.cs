using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using PyramidLibrary.Models;

namespace PyramidTests.ModelsTests;

public class BoardTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(7)]
    public void TakeCorrectAmountOfCardsFromDeck_ShouldSucceed(int numerOfRows)
    {
        // arrange
        Board board = new(numerOfRows);
        // act
        Card card = deck.GiveCard(cardIndex);
        // assert
        card.Should().NotBeNull();
        card.Should().BeOfType<Card>();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(40)]
    public void GiveCard_ShouldFail(int cardIndex)
    {
        // arrange
        Deck deck = new();

        // act
        Action act = () => deck.DrowCard(cardIndex);
        // assert
        act.Should().Throw<Exception>();
    }
}
