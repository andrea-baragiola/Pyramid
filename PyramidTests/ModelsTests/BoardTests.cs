using FluentAssertions;
using PyramidLibrary.Models;

namespace PyramidTests.ModelsTests;

public class BoardTests
{
    [Fact]
    public void BoardDeck_ShouldHave39Cards()
    {
        // arrange
        List<Card> cardList = new();
        foreach (int number in Enumerable.Range(1, 40))
        {
            cardList.Add(new Card(number, "A"));
        }
        CustomDeck deck = new (cardList);
        
        // act
        CustomBoard board = new CustomBoard(1, deck);

        // assert
        board.Deck.Cards.Should().HaveCount(39);
        board.Pyramid.CardRows[0][0].Name.Should().Be("1A");
    }

    [Fact]
    public void BoardDeck_ShouldHave25Cards()
    {
        // arrange
        List<Card> cardList = new();
        foreach (int number in Enumerable.Range(1, 40))
        {
            cardList.Add(new Card(number, "A"));
        }
        CustomDeck deck = new(cardList);

        // act
        CustomBoard board = new CustomBoard(5, deck);

        // assert
        board.Deck.Cards.Should().HaveCount(25);
        board.Pyramid.CardRows[0][0].Name.Should().Be("1A");
        board.Pyramid.CardRows[1][1].Name.Should().Be("3A");
        board.Pyramid.CardRows[3][3].Name.Should().Be("10A");
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(40)]
    public void GiveCard_ShouldFail(int cardIndex)
    {
        // arrange
        Deck deck = new();

        // act
        Action act = () => deck.GiveCard(cardIndex);
        // assert
        act.Should().Throw<Exception>();
    }
}
