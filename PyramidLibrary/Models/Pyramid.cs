using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PyramidLibrary.CustomExceptions;

namespace PyramidLibrary.Models
{
    public class Pyramid
    {
        public List<List<Card?>> CardRows { get; private set; }

        public Pyramid(int numberOfRows)
        {
            CardRows = new();
            CreateCardRows(numberOfRows);
        }

        private void CreateCardRows(int numberOfRows)
        {
            int rowIndex = 0;
            for (int i = 0; i < numberOfRows + 1; i++)
            {
                List<Card> cards = new();
                for (int j = 0; j < rowIndex + 1; j++)
                {
                    cards.Add(null);
                }
                CardRows.Add(cards);
                rowIndex++;
            }
        }

        public Card GiveCard(int rowIndex, int cardIndex)
        {
            Card outputCard = CardRows[rowIndex][cardIndex];
            CardRows[rowIndex][cardIndex] = null;
            return outputCard;
        }

        public void ReceiveCard(Card card, int rowIndex, int cardIndex)
        {
            if (CardRows[rowIndex][cardIndex] != null)
            {
                throw new SpotNotNullException("Error: A not null card is already in this spot");
            }
            else
            {
                CardRows[rowIndex][cardIndex] = card;
            }
        }
    }
}
