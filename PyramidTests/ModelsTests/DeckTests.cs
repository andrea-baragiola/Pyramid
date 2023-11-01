using PyramidLibrary.Models;
using FluentAssertions;

namespace PyramidTests.ModelsTests;

public class DeckTests
{
    [Fact]
    public void Deck_ShouldHaveRightCount()
    {
        // arrange
        // act
        IDeck deck = new FullDeck();

        //assert
        deck.Cards.Should().NotBeEmpty()
            .And.HaveCount(40);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(14)]
    [InlineData(39)]
    public void GiveCard_ShouldSucceed(int cardIndex)
    {
        // arrange
        FullDeck deck = new();
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
}