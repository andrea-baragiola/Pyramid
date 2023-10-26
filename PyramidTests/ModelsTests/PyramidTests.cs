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
        [InlineData(7)]
        public void CreatePyramid_ShouldSucceed(int numberOfRows)
        {
            // arrange
            // act
            Pyramid pyramid = new(numberOfRows);

            // assert
            pyramid.CardRows.Should().NotBeEmpty()
                .And.HaveCount(numberOfRows + 1);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(3, 3)]
        public void GiveCard_ShouldSucceed(int rowIndex, int cardIndex)
        {
            // arrange
            Pyramid pyramid = new(4);

            // act
            Card givenCard = pyramid.GiveCard(rowIndex, cardIndex);

            // assert
            Card originCard = pyramid.CardRows[rowIndex][cardIndex];
            givenCard.Should().Be(originCard);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 2)]
        [InlineData(5, 0)]
        public void GiveCard_ShouldThrowOutOfRangeException(int rowIndex, int cardIndex)
        {
            // arrange
            Pyramid pyramid = new(4);

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
            Pyramid pyramid = new(4);
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
            Pyramid pyramid = new(4);
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
            Pyramid pyramid = new(4);
            Card receivedCard = new(number, suit);

            // act
            Action act = () => pyramid.ReceiveCard(receivedCard, rowIndex, cardIndex);

            // assert
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
