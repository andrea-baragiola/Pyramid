namespace PyramidLibrary.Models;

public class Board
{
    public IDeck InHandDeck { get; set; }
    public IDeck DiscardedCardsDeck { get; set; }

    public List<List<IPosition>> PyramidOfCards { get; set; }

    public Board(int numberOfRows)
    {
        InHandDeck = new FullDeck();
        DiscardedCardsDeck = new EmptyDeck();
        List<List<Card>> cardGroups = PickCardsForBoard(numberOfRows);
        PyramidOfCards = PopulateAllRows(cardGroups);
    }


    private List<List<IPosition>> PopulateAllRows(List<List<Card>> cardGroups)
    {
        List<List<IPosition>> PyramidOfCards = new List<List<IPosition>>();

        int rowIndex = 1;
        foreach (List<Card> cardGroup in cardGroups)
        {
            List<IPosition> row = PopulateRow(cardGroup, rowIndex);
            PyramidOfCards.Add(row);
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

        PyramidOfCards.Add(emptyRow);

        return PyramidOfCards;
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
            List<Card> cardSection = InHandDeck.Cards.GetRange(0, numberOfCards);
            InHandDeck.Cards.RemoveRange(0, numberOfCards);
            listOfCardSections.Add(cardSection);
            numberOfCards++;
        }
        return listOfCardSections;
    }
}
