using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PyramidLibrary.Models;

namespace PyramidLibrary.Services
{
    public static class BoardPreparation
    {
        public static List<List<IPosition>> PopulateBoard(List<Card> deck)
        {
            // selezionare carte nella board

            List<List<Card>> cardSections = PickCardsForBoard(deck, 5);

            // disporre carte nella board

            List<List<IPosition>> listOfListPositions = PopulateAllRows(cardSections);

            return listOfListPositions;
        }

        public static List<List<Card>> PickCardsForBoard(List<Card> deck, int numberOfRows)
        {
            List<List<Card>> listOfCardSections = new List<List<Card>>();
            int numberOfCards = 1;
            for (int i = 0; i < numberOfRows; i++)
            {
                List<Card> cardSection = deck.GetRange(0, numberOfCards);
                deck.RemoveRange(0, numberOfCards);
                listOfCardSections.Add(cardSection);
                numberOfCards++;
            }
            return listOfCardSections;
        }

        public static List<List<IPosition>> PopulateAllRows(List<List<Card>> cardSections)
        {
            List < List < IPosition >> listOfListPosition = new List<List <IPosition>>();
            int rowIndex = 1;
            foreach (List<Card> cardSection in cardSections)
            {
                List<IPosition> positions = PopulateRow(cardSection, rowIndex);
                listOfListPosition.Add(positions);
            }
            return listOfListPosition;
        }


        public static List<IPosition> PopulateRow(List<Card> cardSection, int rowIndex)
        {
            List<IPosition> boardPositions = new List<IPosition>();

            List<int> shifts = new List<int>();


            int lastShift = cardSection.Count - 1;
            shifts.Add(lastShift);
            int next = lastShift - 2;
            while (cardSection.Count > shifts.Count)
            {
                shifts.Add(next);
                next = next - 2;
            }

            foreach (int shift in shifts)
            {
                boardPositions.Add(new BoardPosition(shift, rowIndex, cardSection[0]));
                cardSection.RemoveAt(0);
            }
            return boardPositions;
        }
    }
}
