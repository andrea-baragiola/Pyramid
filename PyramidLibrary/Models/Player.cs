using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PyramidLibrary.Services;

namespace PyramidLibrary.Models;

public class Player
{
    public Board Board { get; set; }
    public bool isWinner { get; set; } = false;
    public bool isLooser { get; set; } = false;

    public Player()
    {
        Board = new(6);
    }

    public void ExecuteMove(int moveIndex)
    {
        Move move = Board.AvailableMoves[moveIndex];
        if (move.Cohordinates.Item1.Id.Item1 == 999)
        {
            ExecuteDeckMove(move);
        }
        else
        {
            ExecuteBoardMove(move);
        }
        

    }

    public void CheckWinLoss()
    {
        if (Board.AvailableMoves.Count == 0)
        {
            if (Board.AvailableBoardPositions.Count == 0)
            {
                isWinner = true;
            }
            else
            {
                isLooser = true;
            }
        }
    }

    private void ExecuteBoardMove(Move move)
    {
        List<IPosition> potitionsToClear = new() { move.Cohordinates.Item1, move.Cohordinates.Item2 };
        foreach (IPosition positionToMove in potitionsToClear)
        {
            if (positionToMove == null)
            {
                continue;
            }

            AddCardToDescardDeck(positionToMove.Card);

            int row = positionToMove.Id.Item1;
            foreach (IPosition boardposition in Board.PyramidOfCards[row])
            {
                if (boardposition == positionToMove)
                {
                    boardposition.Card = null; break;
                }
            }

            
        }
    }

    private void ExecuteDeckMove(Move move)
    {
        IPosition deckPosition = move.Cohordinates.Item1;
        IPosition boardPositionToRemove = move.Cohordinates.Item2;

        AddCardToDescardDeck(deckPosition.Card);

        for (int i = 0; i < Board.InHandDeck.Positions.Count; i++)
        {
            if (Board.InHandDeck.Positions[i] == deckPosition)
            {
                Board.InHandDeck.Positions.RemoveAt(i); break;
            }
        }

        foreach (IPosition deckInHandposition in Board.InHandDeck.Positions)
        {
            if (deckInHandposition == deckPosition)
            {
                deckInHandposition.Card = null; break;
            }
        }

        AddCardToDescardDeck(boardPositionToRemove.Card);

        int row = boardPositionToRemove.Id.Item1;
        foreach (IPosition boardposition in Board.PyramidOfCards[row])
        {
            if (boardposition == boardPositionToRemove)
            {
                boardposition.Card = null; break;
            }
        }
    }

    private void AddCardToDescardDeck(Card card)
    {
        int currentNumberOfCards = Board.DiscardedCardsDeck.Positions.Count;
        Board.DiscardedCardsDeck.Positions.Add(new DeckPosition(currentNumberOfCards, card));
    }
}
