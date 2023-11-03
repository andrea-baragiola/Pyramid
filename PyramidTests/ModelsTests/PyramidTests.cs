using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using PyramidLibrary.CustomExceptions;
using PyramidLibrary.Models;
using PyramidLibrary.Models.Decks;

namespace PyramidTests.ModelsTests
{
    public class PyramidTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(8)]
        public void CreatePyramid_ShouldSucceed(int numberOfRows)
        {
            // arrange
            OneToFourtyDeck customDeck = new();

            // act
            Pyramid pyramid = new(customDeck, numberOfRows);

            // assert
            pyramid.CardRows.Should().NotBeEmpty()
                .And.HaveCount(numberOfRows + 1);
            customDeck.Cards.Last<Card>().Name.Should().Be("40A");
            pyramid.CardRows[0][0].Name.Should().Be("1A");
            pyramid.CardRows[numberOfRows][0].Should().BeNull();
            pyramid.CardRows[numberOfRows][numberOfRows].Should().BeNull();


        }

        //[Fact]
        //public void GiveCard_FirstCardShouldSucceed()
        //{
        //    // arrange
        //    OneToFourtyDeck customDeck = new();
        //    Pyramid pyramid = new(customDeck, 5);

        //    // act
        //    Card givenCard = pyramid.RemoveCard(0, 0);

        //    // assert
        //    givenCard.Name.Should().Be("1A");
        //    pyramid.CardRows[0][0].Should().BeNull();
        //}

        //[Fact]
        //public void GiveCard_MiddleCardShouldSucceed()
        //{
        //    // arrange
        //    OneToFourtyDeck customDeck = new();
        //    Pyramid pyramid = new(customDeck, 5);

        //    // act
        //    Card givenCard = pyramid.RemoveCard(3, 1);

        //    // assert
        //    givenCard.Name.Should().Be("8A");
        //    pyramid.CardRows[3][1].Should().BeNull();
        //}


        //[Theory]
        //[InlineData(0, 1)]
        //[InlineData(1, 2)]
        //[InlineData(5, 0)]
        //public void GiveCard_ShouldThrowOutOfRangeException(int rowIndex, int cardIndex)
        //{
        //    // arrange
        //    Pyramid pyramid = new(new Deck(), 4);

        //    // act
        //    Action act = () => pyramid.GiveCard(rowIndex, cardIndex);

        //    // assert
        //    act.Should().Throw<ArgumentOutOfRangeException>();
        //}
    }
}
