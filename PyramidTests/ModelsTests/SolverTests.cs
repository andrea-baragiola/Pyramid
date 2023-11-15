using FluentAssertions;
using PyramidLibrary.Models;
using PyramidLibrary.Models.Decks;
using PyramidLibrary.Solver;

namespace PyramidTests.ModelsTests
{
    public class SolverTests
    {
        [Fact]
        public void Solve_ShoudFindValidSolution()
        {
            // arrange
            Card[] cardList = 
            {
                new Card(10, "A"),

                new Card(9, "B"),
                new Card(1, "C"),

                new Card(10, "D"),
                new Card(7, "E"),
                new Card(3, "F"),

                new Card(9, "G"),
                new Card(1, "H"),
                new Card(2, "I"),
                new Card(7, "L"),

                new Card(3, "M"),
                new Card(8, "N"),

                new Card(15, "O"),
            };

            CustomDeck customDeck = new(cardList);
            Board board = new(4, customDeck);
            Solver solver = new Solver(board, 4, cardList);

            // act
            bool solvable = solver.Solve(out List<int> winnerPath, out TimeSpan timeTaken);

            // assert
            solvable.Should().Be(true);
            winnerPath.Should().ContainInConsecutiveOrder(0,0,0,0,0,0,0);
        }

        [Fact]
        public void Solve_ShoudIterateAndFindValidSolution()
        {
            // arrange
            Card[] cardList = 
            {
                new Card(10, "A"),

                new Card(10, "B"),
                new Card(1, "C"),

                new Card(10, "D"),
                new Card(7, "E"),
                new Card(8, "F"),

                new Card(9, "G"),
                new Card(10, "H"),
                new Card(10, "I"),
                new Card(10, "L"),

                new Card(1, "M"),
                new Card(2, "N"),
                new Card(3, "O"),
            };

            CustomDeck customDeck = new(cardList);
            Board board = new(4, customDeck);
            Solver solver = new Solver(board, 4, cardList);

            // act
            bool solvable = solver.Solve(out List<int> winnerPath, out TimeSpan timeTaken);

            // assert
            solvable.Should().Be(true);
            winnerPath.Should().Contain(1);
        }

        [Fact]
        public void Solve_ShoudNotFindValidSolution()
        {
            // arrange
            Card[] cardList =
            {
                new Card(5, "A"),

                new Card(10, "B"),
                new Card(1, "C"),

                new Card(10, "D"),
                new Card(7, "E"),
                new Card(8, "F"),

                new Card(9, "G"),
                new Card(10, "H"),
                new Card(10, "I"),
                new Card(10, "L"),

                new Card(1, "M"),
                new Card(2, "N"),
                new Card(3, "O"),
            };

            CustomDeck customDeck = new(cardList);
            Board board = new(4, customDeck);
            Solver solver = new Solver(board, 4, cardList);

            // act
            bool solvable = solver.Solve(out List<int> winnerPath, out TimeSpan timeTaken);

            // assert
            solvable.Should().Be(false);
        }
    }
}
