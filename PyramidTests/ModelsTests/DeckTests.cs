using FluentAssertions;
using PyramidLibrary.Models.Decks;

namespace PyramidTests.ModelsTests;

public class DeckTests
{
    [Fact]
    public void Deck_ShouldHaveRightCount()
    {
        // arrange
        // act
        IDeck deck = new Deck();

        //assert
        deck.Cards.Should().NotBeEmpty()
            .And.HaveCount(40);
    }

    //[Theory]
    //[InlineData(0)]
    //[InlineData(14)]
    //[InlineData(39)]
    //public void RemoveCard_ShouldSucceed(int cardIndex)
    //{
    //    // arrange
    //    Deck deck = new();
    //    // act
    //    deck.RemoveCard(cardIndex);
    //    // assert
    //    deck.Cards[cardIndex].Should().NotBeNull();
    //    card.Should().NotBeNull();
    //    card.Should().BeOfType<Card>();
    //}

    //[Theory]
    //[InlineData(-1)]
    //[InlineData(40)]
    //public void GiveCard_ShouldFail(int cardIndex)
    //{
    //    // arrange
    //    Deck deck = new();

    //    // act
    //    Action act = () => deck.RemoveCard(cardIndex);

    //    // assert
    //    act.Should().Throw<Exception>();
    //}
}