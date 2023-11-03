using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using PyramidLibrary.Models;
using PyramidLibrary.Models.Decks;
using PyramidLibrary.Models.Moves;

namespace PyramidTests.ModelsTests;

public class BoardTests
{
    [Fact]
    public void Board_ShouldCreateCorrectly()
    {
        //arrange
        OneToFourtyDeck oneToFourtyDeck = new();

        //act
        Board board = new(7, oneToFourtyDeck);

        //assert
        board.Deck.Cards.Should().HaveCount(12);
        board.Pyramid.CardRows.Should().HaveCount(8);
        board.Pyramid.CardRows[0][0].Name.Should().Be("1A");
        board.Pyramid.CardRows[3][0].Name.Should().Be("7A");
        board.Pyramid.CardRows[6][6].Name.Should().Be("28A");
    }

    //[Fact]
    //public void GetAllAvailableMoves_ShouldSucceed()
    //{
    //    //arrange
    //    UnshuffledDeck unshuffled = new();

    //    //act
    //    Board board = new(3, unshuffled);

    //    //assert
    //    board.AvailablePyramidPyramidMoves.Should().HaveCount(1);
    //    board.AvailableSinglePyramidMoves.Should().BeEmpty();

    //    PyramidPyramidMove pyramidPyramidMove1 = board.AvailablePyramidPyramidMoves[0];
    //    var cardOneRow = pyramidPyramidMove1.PyramidCardRow1;
    //    var cardOneIndex = pyramidPyramidMove1.PyramidCardIndex1;
    //    var cardTwoRow = pyramidPyramidMove1.PyramidCardRow2;
    //    var cardTwoIndex = pyramidPyramidMove1.PyramidCardIndex2;
    //    board.Pyramid.CardRows[cardOneRow][cardOneIndex].Name.Should().Be("6H");
    //    board.Pyramid.CardRows[cardTwoRow][cardTwoIndex].Name.Should().Be("4H");


    //    var firstMoveDeckCardIndex = board.AvailableDeckPyramidMoves.First().DeckCardIndex;
    //    var lastMoveDeckCardIndex = board.AvailableDeckPyramidMoves.Last().DeckCardIndex;
    //    board.Deck.Cards[firstMoveDeckCardIndex].Name.Should().Be("4D");
    //    board.Deck.Cards[lastMoveDeckCardIndex].Name.Should().Be("6S");
    //}
}
