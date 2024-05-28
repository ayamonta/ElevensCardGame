using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CardGame
{
    public class Deck
    {
        int numCards;
        public List<Card> listOfCards = new List<Card>();   

        public int NumCards { get { return numCards; } }

        public List<Card> ListOfCards
        {
            get => listOfCards;
            set => listOfCards = value;
        }

        //public Deck(int norm)
        //{
        //    foreach (Rank rank in Enum.GetValues(typeof(Rank)))
        //    {
        //        int pointValue = (int)rank + 1;

        //        if (rank == Rank.Jack ||
        //            rank == Rank.Queen ||
        //            rank == Rank.King)
        //        {
        //            pointValue = 0;
        //        }

        //        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        //        {
        //            listOfCards.Add(new Card(rank, suit, pointValue));
        //            ++numCards;
        //        }

        //    }
        //}

        public Deck()
        {
            int i = 0;
            List<Bitmap> cardImages = ImagesToList();

            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {

                int pointValue = (int)rank + 1;

                if (rank == Rank.Jack ||
                    rank == Rank.Queen ||
                    rank == Rank.King)
                {
                    pointValue = 0;
                }

                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    listOfCards.Add( new Card(rank, suit, pointValue, cardImages[i]) );
                    ++numCards;
                    ++i;
                }

            }

            //// Unit Test 1: tests game win, tests selecting null slots on board, tests game lose
            //listOfCards.Add(new Card(Rank.Ace, Suit.Clubs, 1));
            //listOfCards.Add(new Card(Rank.Ten, Suit.Diamonds, 10));
            //listOfCards.Add(new Card(Rank.Eight, Suit.Hearts, 8));
            //listOfCards.Add(new Card(Rank.Three, Suit.Spades, 3));
            //listOfCards.Add(new Card(Rank.Nine, Suit.Clubs, 9));
            //listOfCards.Add(new Card(Rank.Two, Suit.Diamonds, 2));
            //listOfCards.Add(new Card(Rank.Jack, Suit.Clubs, 0));
            //listOfCards.Add(new Card(Rank.Queen, Suit.Diamonds, 0));
            ////listOfCards.Add(new Card(Rank.King, Suit.Hearts, 0));
            //listOfCards.Add(new Card(Rank.Ace, Suit.Hearts, 0));
            ////listOfCards.Add(new Card());


            //// Unit Test 2: tests 3 cards for Bitmap image mapping
            //listOfCards.Add(new Card(Rank.Ace, Suit.Clubs, 1));
            //listOfCards.Add(new Card(Rank.Ace, Suit.Diamonds, 1));
            //listOfCards.Add(new Card(Rank.Ace, Suit.Hearts, 1));


            //// Unit Test 3: for testing usage of dictionary for <Card, BitMap>
            ////  when removing cards from board and adding new card
            //listOfCards.Add(new Card(Rank.Ace, Suit.Clubs, 1));
            //listOfCards.Add(new Card(Rank.Ten, Suit.Diamonds, 10));
            //listOfCards.Add(new Card(Rank.Eight, Suit.Hearts, 8));
            //listOfCards.Add(new Card(Rank.Three, Suit.Spades, 3));
            //listOfCards.Add(new Card(Rank.Nine, Suit.Clubs, 9));
            //listOfCards.Add(new Card(Rank.Two, Suit.Diamonds, 2));
            //listOfCards.Add(new Card(Rank.Jack, Suit.Clubs, 0));
            //listOfCards.Add(new Card(Rank.Queen, Suit.Diamonds, 0));
            ////listOfCards.Add(new Card(Rank.King, Suit.Hearts, 0));
            //listOfCards.Add(new Card(Rank.Ace, Suit.Hearts, 0));

            //listOfCards.Add(new Card(Rank.Six, Suit.Clubs, 6));
            //listOfCards.Add(new Card(Rank.Five, Suit.Diamonds, 5));
            //listOfCards.Add(new Card(Rank.Seven, Suit.Hearts,7));
            //listOfCards.Add(new Card(Rank.Four, Suit.Spades, 4));
            //listOfCards.Add(new Card(Rank.Ace, Suit.Spades, 1));
            //listOfCards.Add(new Card(Rank.Ten, Suit.Diamonds, 10));

            //listOfCards.Add(new Card(Rank.Jack, Suit.Clubs, 0));
            //listOfCards.Add(new Card(Rank.Queen, Suit.Diamonds, 0));
            //listOfCards.Add(new Card(Rank.King, Suit.Hearts, 0));


            //// Unit Test 4: tests game win out of loss counter, and 
            ////  num of cards left in deck
            //listOfCards.Add(new Card(Rank.Ace, Suit.Clubs, 1));
            //listOfCards.Add(new Card(Rank.Ten, Suit.Diamonds, 10));
            //listOfCards.Add(new Card(Rank.Eight, Suit.Hearts, 8));
            //listOfCards.Add(new Card(Rank.Three, Suit.Spades, 3));
            //listOfCards.Add(new Card(Rank.Nine, Suit.Clubs, 9));
            //listOfCards.Add(new Card(Rank.Two, Suit.Diamonds, 2));
            //listOfCards.Add(new Card(Rank.Jack, Suit.Clubs, 0));
            //listOfCards.Add(new Card(Rank.Queen, Suit.Diamonds, 0));
            //listOfCards.Add(new Card(Rank.King, Suit.Hearts, 0));
            //listOfCards.Add(new Card(Rank.Ace, Suit.Hearts, 1));
            //listOfCards.Add(new Card(Rank.Ten, Suit.Hearts, 10));
            //listOfCards.Add(new Card());
        }

        public bool Empty { get { return listOfCards.Count == 0; } } 

        public void Cut(int location)
        {
            if (location == 0)
            {
                Console.WriteLine("--Cannot cut deck at first card--");
            }
            else if(location == listOfCards.Count - 1)
            {
                Console.WriteLine("--Cannot cut deck at last card--");
            }
            else
            {
                int leftover = listOfCards.Count - location;                  
                Card[] cardsTemp = new Card[listOfCards.Count];               
                listOfCards.CopyTo(location, cardsTemp, 0, leftover);         
                listOfCards.CopyTo(0, cardsTemp, leftover, location);   
                listOfCards.Clear();                                          
                listOfCards.InsertRange(0, cardsTemp);                        
            }
        }

        public void Print()
        {
            foreach(Card CARDS in listOfCards)
            {
                Console.WriteLine($"{(int)CARDS.Rank+1} {CARDS.Rank} {CARDS.Suit}\t\t(point value = {CARDS.PointValue})");
            }
        }

        public void Shuffle()       
        {
            Random rand = new Random();
            int randNum;
            Card tempLast;

            if (listOfCards.Count > 1)
            {
                for (int i = 0; i < listOfCards.Count-1; ++i)
                {
                    if (listOfCards.Count-i-1 == 1 || listOfCards.Count == 2)   
                    {
                        tempLast = listOfCards[listOfCards.Count-i-1];
                        listOfCards[listOfCards.Count-i-1] = listOfCards[0];
                        listOfCards[0] = tempLast;
                    }
                    else
                    {
                        randNum = rand.Next(0, listOfCards.Count-i-2);    
                        tempLast = listOfCards[listOfCards.Count-i-1];
                        listOfCards[listOfCards.Count-i-1] = listOfCards[randNum];
                        listOfCards[randNum] = tempLast;
                    }
                }
            }
            else
            {
                Console.WriteLine("--Cannot shuffle less than 2 cards--");
            }
        }

        public Card TakeTopCard()
        {
            if (!Empty)
            {
                Card cardDealt = listOfCards[listOfCards.Count - 1];                                          
                listOfCards.RemoveAt(listOfCards.Count - 1);
                --numCards;
                return cardDealt;        
            }

            return null;
        }

        public Card RetrieveValue(int searchIndex)
        {
            return listOfCards[searchIndex];
        }

        public void RemoveCard(int remIndex)
        {
            listOfCards.RemoveAt(remIndex);
            --numCards;
        }

        public void AddCard(Card card)
        {
            listOfCards.Add(card);
            ++numCards;
        }


        public List<Bitmap> ImagesToList()
        {
            List<Bitmap> cardImages = new List<Bitmap>()
            {
                new Bitmap(CardGame.Properties.Resources._1C),
                new Bitmap(CardGame.Properties.Resources._1D),
                new Bitmap(CardGame.Properties.Resources._1H),
                new Bitmap(CardGame.Properties.Resources._1S),
                new Bitmap(CardGame.Properties.Resources._2C),
                new Bitmap(CardGame.Properties.Resources._2D),
                new Bitmap(CardGame.Properties.Resources._2H),
                new Bitmap(CardGame.Properties.Resources._2S),
                new Bitmap(CardGame.Properties.Resources._3C),
                new Bitmap(CardGame.Properties.Resources._3D),
                new Bitmap(CardGame.Properties.Resources._3H),
                new Bitmap(CardGame.Properties.Resources._3S),
                new Bitmap(CardGame.Properties.Resources._4C),
                new Bitmap(CardGame.Properties.Resources._4D),
                new Bitmap(CardGame.Properties.Resources._4H),
                new Bitmap(CardGame.Properties.Resources._4S),
                new Bitmap(CardGame.Properties.Resources._5C),
                new Bitmap(CardGame.Properties.Resources._5D),
                new Bitmap(CardGame.Properties.Resources._5H),
                new Bitmap(CardGame.Properties.Resources._5S),
                new Bitmap(CardGame.Properties.Resources._6C),
                new Bitmap(CardGame.Properties.Resources._6D),
                new Bitmap(CardGame.Properties.Resources._6H),
                new Bitmap(CardGame.Properties.Resources._6S),
                new Bitmap(CardGame.Properties.Resources._7C),
                new Bitmap(CardGame.Properties.Resources._7D),
                new Bitmap(CardGame.Properties.Resources._7H),
                new Bitmap(CardGame.Properties.Resources._7S),
                new Bitmap(CardGame.Properties.Resources._8C),
                new Bitmap(CardGame.Properties.Resources._8D),
                new Bitmap(CardGame.Properties.Resources._8H),
                new Bitmap(CardGame.Properties.Resources._8S),
                new Bitmap(CardGame.Properties.Resources._90C),
                new Bitmap(CardGame.Properties.Resources._90D),
                new Bitmap(CardGame.Properties.Resources._90H),
                new Bitmap(CardGame.Properties.Resources._90S),
                new Bitmap(CardGame.Properties.Resources._91C),
                new Bitmap(CardGame.Properties.Resources._91D),
                new Bitmap(CardGame.Properties.Resources._91H),
                new Bitmap(CardGame.Properties.Resources._91S),
                new Bitmap(CardGame.Properties.Resources.AC),
                new Bitmap(CardGame.Properties.Resources.AD),
                new Bitmap(CardGame.Properties.Resources.AH),
                new Bitmap(CardGame.Properties.Resources.AS),
                new Bitmap(CardGame.Properties.Resources.BC),
                new Bitmap(CardGame.Properties.Resources.BD),
                new Bitmap(CardGame.Properties.Resources.BH),
                new Bitmap(CardGame.Properties.Resources.BS),
                new Bitmap(CardGame.Properties.Resources.CC),
                new Bitmap(CardGame.Properties.Resources.CD),
                new Bitmap(CardGame.Properties.Resources.CH),
                new Bitmap(CardGame.Properties.Resources.CS)
            };

            return cardImages;
        }
    }
}
