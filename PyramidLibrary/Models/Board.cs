﻿namespace PyramidLibrary.Models;

public class Board
{
    public IDeck InHandDeck { get; set; }
    public IDeck DiscardedCardsDeck { get; set; }
    public List<List<IPosition>> PyramidOfCards { get; set; }
    public List<IPosition> AvailableBoardPositions { get; set; }
    public List<Move> AvailableMoves { get; set; }

    public Board(int numberOfRows)
    {
        InHandDeck = new FullDeck();
        DiscardedCardsDeck = new EmptyDeck();
        List<List<Card>> cardGroups = PickCardsForBoard(numberOfRows);
        PopulateAllRows(cardGroups);
        GetAvailableBoardPositions();
        GetAvailableMoves();

        //AvailableMoves = 
    }

    public void GetAvailableBoardPositions()
    {
        List<IPosition> availableBoardPositions = new List<IPosition>();

        for (int i = 0; i < PyramidOfCards.Count - 1; i++)
        {
            List<IPosition> currentRowPositions = PyramidOfCards[i];
            List<IPosition> nextRowPositions = PyramidOfCards[i + 1];

            for (int k = 0; k < currentRowPositions.Count; k++)
            {
                if (nextRowPositions[k].Card == null && nextRowPositions[k + 1].Card == null)
                {
                    availableBoardPositions.Add(currentRowPositions[k]);
                }
            }
        }
        AvailableBoardPositions = availableBoardPositions;
    }

    public void GetAvailableMoves()
    {
        List<Move> boardMoves = GetAvailableBoardMoves();
        List<Move> deckMoves = GetAvailableDeckMoves();
        AvailableMoves = boardMoves.Union(deckMoves).ToList();
    }

    private List<Move> GetAvailableBoardMoves()
    {
        List<Move> availableMoves = new();

        for (int i = 0; i < AvailableBoardPositions.Count; i++)
        {
            if (AvailableBoardPositions[i].Card.Number == 10)
            {
                availableMoves.Add(new Move(AvailableBoardPositions[i], null));
                continue;
            }
            for (int k = i + 1; k < AvailableBoardPositions.Count; k++)
            {

                if (AvailableBoardPositions[i].Card.Number == 10 - AvailableBoardPositions[k].Card.Number)
                {
                    availableMoves.Add(new Move(AvailableBoardPositions[i], AvailableBoardPositions[k]));
                }
            }
        }
        return availableMoves;
    }

    private List<Move> GetAvailableDeckMoves()
    {
        List<Move> availableMoves = new ();

        for (int i = 0; i < AvailableBoardPositions.Count; i++)
        {
            for (int k = 0; k < InHandDeck.Positions.Count; k++)
            {
                if (AvailableBoardPositions[i].Card.Number == 10 - InHandDeck.Positions[k].Card.Number)
                {
                    availableMoves.Add(new Move(AvailableBoardPositions[i], InHandDeck.Positions[k]));
                }
            }
        }
        return availableMoves;
    }


    private void PopulateAllRows(List<List<Card>> cardGroups)
    {
        List<List<IPosition>> pyramidOfCards = new List<List<IPosition>>();

        int rowIndex = 1;
        foreach (List<Card> cardGroup in cardGroups)
        {
            List<IPosition> row = PopulateRow(cardGroup, rowIndex);
            pyramidOfCards.Add(row);
            rowIndex++;
        }

        List<int> emptyShifts = CalculateShifts(rowIndex);
        List<Card> emptyCardSection = new List<Card>();

        for (int i = 0; i < rowIndex; i++)
        {
            emptyCardSection.Add(null);
        }

        List<IPosition> emptyRow = new();
        foreach (int emptyShift in emptyShifts)
        {
            emptyRow.Add(new BoardPosition(emptyShift, rowIndex, null));
        }

        pyramidOfCards.Add(emptyRow);

        PyramidOfCards = pyramidOfCards;
    }


    private List<IPosition> PopulateRow(List<Card> cardGroup, int rowIndex)
    {
        List<IPosition> row = new List<IPosition>();
        List<int> shifts = CalculateShifts(cardGroup.Count);

        foreach (int shift in shifts)
        {
            row.Add(new BoardPosition(shift, rowIndex, cardGroup[0]));
            cardGroup.RemoveAt(0);
        }
        return row;
    }

    private List<int> CalculateShifts(int count)
    {
        List<int> shifts = new List<int>();


        int lastShift = count - 1;
        shifts.Add(lastShift);
        int next = lastShift - 2;
        while (count > shifts.Count)
        {
            shifts.Add(next);
            next = next - 2;
        }

        return shifts;
    }






    private List<List<Card>> PickCardsForBoard(int numberOfRows)
    {
        List<List<Card>> listOfCardSections = new();
        int numberOfCards = 1;
        for (int i = 0; i < numberOfRows; i++)
        {
            List<Card> cards = new();
            List<IPosition> positions = InHandDeck.Positions.GetRange(0, numberOfCards);
            InHandDeck.Positions.RemoveRange(0, numberOfCards);
            foreach (IPosition position in positions)
            {
                cards.Add(position.Card);
            }

            listOfCardSections.Add(cards);
            numberOfCards++;
        }
        return listOfCardSections;
    }
}
