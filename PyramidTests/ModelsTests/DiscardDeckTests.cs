using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using PyramidLibrary.Models;

namespace PyramidTests.ModelsTests;

public class DiscardDeckTests
{
    [Theory]
    [InlineData(1, "H")]
    [InlineData(5, "C")]
    [InlineData(10, "D")]
    public void ReceiveCard_ShouldSucceed(int number, string suit)
    {
        // arrange
        DiscardDeck discardDeck = new();
        Card card = new Card(number, suit);

        // act
        discardDeck.ReceiveCard(card);

        // assert
        discardDeck.Cards.Should().NotBeEmpty()
            .And.HaveCount(1);
        discardDeck.Cards[0].Should().Be(card);
    }
}
