using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    public abstract class Board
    {
        public Deck deck;
        public Card[] cardsOnBoard;

        abstract public int BoardSize
        {
            get;
            set;
        }

        public Board()
        {
            // instantiate a deck of cards
            deck = new Deck();
            // make room on the board for [boardSize] cards
            cardsOnBoard = new Card[BoardSize];

            NewGame_DistributeCards();

        }



        public abstract bool IsLegal(List<int> selectedCards);
        public abstract bool NextPlayPossible();

        // prevent newGame from starting on a loss
        public void NewGame_DistributeCards()
        {
            NewGameDummy_DistributeCards();
            
            while (!NextPlayPossible())
            {
                PutCardsBack();
                NewGameDummy_DistributeCards();
            }
        }

        // newGame w/o preventing start on loss
        public void NewGameDummy_DistributeCards()
        {
            deck.Shuffle();

            // place cards on the board for beginning of game
            for (int i = 0; i < BoardSize; i++)
            {
                cardsOnBoard[i] = deck.TakeTopCard();
            }  
        }

        public void PutCardsBack()
        {
            foreach (Card card in cardsOnBoard)
            {
                deck.AddCard(card);
            }
        }

        // deal cards every time a play is made and cards are removed from board
        public void DealCards()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                if (cardsOnBoard[i] == null)
                {
                    cardsOnBoard[i] = deck.TakeTopCard();
                }
            }   
        }

        // retrieve all non-null card indices on board
        // (purpose: for isLegal() to check if there are any more
        //  possible legal moves)
        public List<int> Nonnull_CardIndices()
        {
            List<int> selected = new List<int>();

            for (int i = 0; i < cardsOnBoard.Length; i++)
            {
                if (cardsOnBoard[i] != null)
                {
                    selected.Add(i);
                }
            }

            return selected;
        }

        public bool BoardIsEmpty()
        {
            foreach (Card cards in cardsOnBoard)
            {
                if (cards != null)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
