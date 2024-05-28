using CardGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Player
    {
        public List<Card> cards = new List<Card>();

        // Fields
        int numCards;
        public bool IsEmpty(Card card) { return cards.Count == 0; }


        // Properties
        public int NumCards() { return numCards; }


        // Methods
        public void receiveCard(Card newCard)
        {
            cards.Add(newCard);
            ++numCards;
        }

        public void removeCard(Card newCard)
        {
            cards.Remove(newCard);
            --numCards;
        }
 
        public void printCards()
        {
            foreach (Card card in cards)
            {
                Console.WriteLine($"  {(int)card.Rank+1} {card.Rank} of {card.Suit}");
            }
        }

        public void insertCard(Rank RANK, Suit SUIT)
        {
            cards.Add(new Card(RANK, SUIT));
            sortCards();
        }

        public void sortCards()
        {
            List<Card> sortedCards = cards.OrderBy(a => a.Rank)
                                            .ThenBy(b => b.Suit)
                                            .ToList();
            cards.Clear();
            cards.InsertRange(0,sortedCards);
        }

        // Insert listOfCards by suit and rank UNDONE
        // Sort listOfCards by suit and rank UNDONE
    }
}
