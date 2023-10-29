using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using PyramidLibrary.CustomExceptions;
using PyramidLibrary.Models;

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
            CustomDeck customDeck = new();

            // act
            Pyramid pyramid = new(customDeck, numberOfRows);

            // assert
            pyramid.CardRows.Should().NotBeEmpty()
                .And.HaveCount(numberOfRows + 1);
            customDeck.Cards.Last<Card>().Name.Should().Be("40A");
            pyramid.CardRows[0][0].Name.Should().Be("1A");


        }

        [Fact]
        public void GiveCard_FirstCardShouldSucceed()
        {
            // arrange
            CustomDeck customDeck = new();
            Pyramid pyramid = new(customDeck, 5);

            // act
            Card givenCard = pyramid.GiveCard(0, 0);

            // assert
            givenCard.Name.Should().Be("1A");
            pyramid.CardRows[0][0].Should().BeNull();
        }

        [Fact]
        public void GiveCard_MiddleCardShouldSucceed()
        {
            // arrange
            CustomDeck customDeck = new();
            Pyramid pyramid = new(customDeck, 5);

            // act
            Card givenCard = pyramid.GiveCard(3, 1);

            // assert
            givenCard.Name.Should().Be("8A");
            pyramid.CardRows[3][1].Should().BeNull();
        }


        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 2)]
        [InlineData(5, 0)]
        public void GiveCard_ShouldThrowOutOfRangeException(int rowIndex, int cardIndex)
        {
            // arrange
            Pyramid pyramid = new(new Deck(), 4);

            // act
            Action act = () => pyramid.GiveCard(rowIndex, cardIndex);

            // assert
            act.Should().Throw<ArgumentOutOfRangeException>();
        }


        [Theory]
        [InlineData(1, "C", 0, 0)]
        [InlineData(10, "D", 3, 2)]
        [InlineData(5, "H", 3, 0)]
        public void ReceiveCard_ShouldSucceed(int number, string suit, int rowIndex, int cardIndex)
        {
            // arrange
            Pyramid pyramid = new(new Deck(), 4);
            Card receivedCard = new(number, suit);

            // act
            pyramid.ReceiveCard(receivedCard, rowIndex, cardIndex);

            // assert
            Card cardInPyramid = pyramid.CardRows[rowIndex][cardIndex];
            cardInPyramid.Should().Be(receivedCard);
        }

        [Theory]
        [InlineData(1, "C", 0, 0)]
        [InlineData(10, "D", 3, 2)]
        [InlineData(5, "H", 3, 0)]
        public void ReceiveCard_ShouldThrowSpotNotNullException(int number, string suit, int rowIndex, int cardIndex)
        {
            // arrange
            Pyramid pyramid = new(new Deck(), 4);
            Card receivedCard = new(number, suit);
            pyramid.ReceiveCard(receivedCard, rowIndex, cardIndex);

            // act
            Action act = () => pyramid.ReceiveCard(receivedCard, rowIndex, cardIndex);

            // assert
            act.Should().Throw<SpotNotNullException>();
        }

        [Theory]
        [InlineData(1, "C", 0, 1)]
        [InlineData(10, "D", 1, 2)]
        [InlineData(5, "H", 5, 0)]
        public void ReceiveCard_ShouldThrowArgumentOutOfRangeException(int number, string suit, int rowIndex, int cardIndex)
        {
            // arrange
            Pyramid pyramid = new(new Deck(), 4);
            Card receivedCard = new(number, suit);

            // act
            Action act = () => pyramid.ReceiveCard(receivedCard, rowIndex, cardIndex);

            // assert
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
