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
        Deck deck = new Deck();
        Board board = new(numerOfRows, deck);
        // act
        Card card = deck.DrowCard();
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
        Action act = () => deck.DrowCard();
        // assert
        act.Should().Throw<Exception>();
    }
}
