using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using PyramidLibrary.Models;

namespace PyramidTests.ModelsTests
{
    public class CardTests
    {
        [Theory]
        [InlineData(1, "H")]
        [InlineData(5, "C")]
        [InlineData(10, "S")]
        public void Card_ShouldBeCreatedCorrectly(int number, string suit)
        {
            // arrange
            // act
            Card card = new(number, suit);

            //assert
            card.Suit.Should().Be(suit);
            card.Number.Should().Be(number);
            card.Name.Should().Be(number.ToString() + suit);

        }
    }
}
