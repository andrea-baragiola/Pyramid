using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using PyramidLibrary.CustomExceptions;
using PyramidLibrary.Models;

namespace PyramidTests.ModelsTests;

public class PyramidTests
{
    [Fact]
    public void Test1()
    {
        var deck = new FullDeck();
        var sut = new Pyramid(deck, 5);

        var card = sut.Peek(1, 1);
        card.Should().NotBeNull();
        card.Number.Should().Be(1);

    }

    [Fact]
    public void Test2()
    {
        var deck = new FullDeck();
        var sut = new Pyramid(deck, 5);

        Action act = () => sut.Peek(1, 2);

        act.Should().Throw<InvalidCardPositionException>();
    }

    [Fact]
    public void Test3()
    {
        var deck = new FullDeck();
        var sut = new Pyramid(deck, 5);

        Action act = () => sut.Peek(6, 2);

        act.Should().Throw<InvalidCardPositionException>();
    }

    [Fact]
    public void Test4()
    {
        var deck = new FullDeck();
        var sut = new Pyramid(deck, 5);

        var card = sut.Peek(5, 5);
        card.Should().NotBeNull();
        card.Number.Should().Be(4);

    }

}
