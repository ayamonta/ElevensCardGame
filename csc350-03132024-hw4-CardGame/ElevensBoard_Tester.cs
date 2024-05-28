using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class ElevensBoard_Tester
    {
        static void Main(string[] args)
        {
            int wins = 0;
            int loss = 0;
            string continueInput;

            do
            {
                // set up Elevens board
                ElevensBoard board = new ElevensBoard();

                // shuffles at new game
                //board.NewGame_DistributeCards();

                //  test order of cards printed
                //Deck deck = new Deck();
                //deck.Print();


                while (board.NextPlayPossible())
                {
                    // display current board
                    Console.WriteLine("Current board: ");

                    for (int i = 0; i < board.BoardSize; i++)
                    {
                        if (board.cardsOnBoard[i] != null)
                        {
                            Console.WriteLine($"{i}: {board.cardsOnBoard[i].toString()}");
                        }
                        else
                        {
                            Console.WriteLine($"{i}: [Empty]");
                        }
                    }

                    // let the player choose cards to play
                    Console.WriteLine($"Select cards to play (i.e. 0 1 2): ");
                    string input = Console.ReadLine();
                    List<int> selectedCards = new List<int>();

                    foreach (string idx in input.Split(' '))
                    {
                        if (board.cardsOnBoard[int.Parse(idx)] != null)
                        {
                            selectedCards.Add(int.Parse(idx));
                        }
                    }

                    // if play is legal, remove/nullify selected cards on Board
                    // and deal new cards from deck
                    if (board.IsLegal(selectedCards))
                    {
                        Console.WriteLine("Valid move");

                        foreach (int idx in selectedCards)
                        {
                            board.cardsOnBoard[idx] = null;
                        }

                        board.DealCards();
                    }
                    else
                    {
                        Console.WriteLine($"Invalid move, try again");
                    }
                }


                // if deck is empty, game won
                // if deck has cards after no legal moves, game lost
                if (board.BoardIsEmpty())
                {
                    Console.WriteLine($"--Deck is empty. You win--");
                    ++wins;
                }
                else
                {
                    Console.WriteLine($"--No more legal plays. Game Over--");
                    ++loss;
                }

                Console.WriteLine($"Won {wins} out of {wins + loss} games");
                Console.WriteLine($"Press q to exit, press c to restart game");
                continueInput = Console.ReadLine();

            } while (continueInput != "q" && continueInput == "c");
        }
    }
}
