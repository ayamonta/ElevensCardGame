using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CardGame
{
    public class Card
    {
        // Fields
        Rank rank;
        Suit suit;
        int pointValue;
        public Bitmap img;
        bool faceUp;        // bool is false on default


        // Properties
        public Rank Rank { get { return rank; } }
        public Suit Suit { get { return suit; } }

        public int PointValue 
        { 
            get { return pointValue; } 
            set { pointValue = value; }
        }

        public Bitmap Img
        { 
            get { return img; } 
            set { img = value; }
        }

        public bool FaceUp { get { return faceUp; } }


        // Constructor
        public Card(Rank rank, Suit suit, int pointVal, Bitmap img)
        {
            this.rank = rank;
            this.suit = suit;
            this.pointValue = pointVal;
            this.img = img;
            this.faceUp = false;
        }

        public Card(Rank rank, Suit suit, int pointVal)
        {
            this.rank = rank;
            this.suit = suit;
            this.pointValue = pointVal;
            this.faceUp = false;
        }

        public Card(Rank rank, Suit suit)
        {
            this.rank = rank;
            this.suit = suit;
            this.faceUp = false;
        }


        // Methods
        public void FlipOver()
        {
            faceUp = !faceUp;
        }

        public bool IsEqual(Card rhsCard)
        {
            if (this.rank == rhsCard.rank && 
                this.suit == rhsCard.suit && 
                this.pointValue == rhsCard.pointValue)
            {
                return true;
            }

            return false;
        }

        public String toString()
        {
            //return ($"{this.rank} of {this.suit} (point value = {pointValue}");
            return ($"{this.rank} of {this.suit}");
        }

        public void ElevensPointValue()
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                if (rank != Rank.Jack && 
                    rank != Rank.Queen && 
                    rank != Rank.King)
                {
                    pointValue = (int)rank + 1;
                }
                else if (rank == Rank.Jack || 
                        rank == Rank.Queen || 
                        rank == Rank.King)
                {
                    pointValue = 0;
                }
            }
        }
    }
}
