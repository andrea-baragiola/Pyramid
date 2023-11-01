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
        FullDeck deck = new FullDeck();
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
        FullDeck deck = new();

        // act
        Action act = () => deck.DrowCard();
        // assert
        act.Should().Throw<Exception>();
    }

    [Fact]
    public void Test1()
    {
        var board = new Board(5, new FullDeck());

        var move = new 
    }
}
