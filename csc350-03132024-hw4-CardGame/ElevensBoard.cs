using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class ElevensBoard : Board
    {

        public override int BoardSize { get{ return 9; } set { } }

        public ElevensBoard() : base()
        {
        }

        public override bool IsLegal(List<int> selectedCards)
        {
            if (selectedCards.Count == 3)
            {
                return HasJQK(selectedCards);
            }
            if (selectedCards.Count == 2)
            {
                return HasPairSum11(selectedCards);
            }

            return false;
        }

        public override bool NextPlayPossible()
        {
            //// Debug log: shows num of times Play is not possible
            //var nonnullIndices = Nonnull_CardIndices();
            //bool hasJQK = HasJQK(nonnullIndices);
            //bool hasPairSum11 = HasPairSum11(nonnullIndices);

            //Console.WriteLine($"NextPlayPossible: hasJQK={hasJQK}, hasPairSum11={hasPairSum11}");

            return ( HasJQK(Nonnull_CardIndices()) || 
                     HasPairSum11(Nonnull_CardIndices()) );
        }

        public bool HasPairSum11(List<int> selectedCards)
        {
            // loops through all selectedCards to check for pair sum of 11
            for (int j = 0; j < selectedCards.Count; j++)
            { 
                for (int i = 1; i < selectedCards.Count; i++)
                {
                    if (cardsOnBoard[selectedCards[j]].PointValue + 
                        cardsOnBoard[selectedCards[i]].PointValue == 11)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool HasJQK(List<int> selectedCards)
        {
            bool foundJack = false;
            bool foundQueen = false;
            bool foundKing = false;

            // loop through all selectedCards to check for JQK
            foreach (int cards in selectedCards)
            {
                if (cardsOnBoard[cards].Rank == Rank.Jack)
                {
                    foundJack = true;
                }
                else if (cardsOnBoard[cards].Rank == Rank.Queen)
                {
                    foundQueen = true;
                }
                else if (cardsOnBoard[cards].Rank == Rank.King)
                {
                    foundKing = true;
                }
            }

            return foundJack && foundQueen && foundKing;
        }

        //static void Main(string[] args)
        //{



        //}
    }
}
