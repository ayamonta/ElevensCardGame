using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Resources;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using CardGame;
using ElevensBoardGUI.Properties;
//using CardGame.Properties;

namespace ElevensBoardGUI
{
    public partial class ElevensForm : Form
    {
        List<bool> pbClicked = new List<bool>();

        ElevensBoard board;
        int wins = 0;
        int losses = 0;

        public ElevensForm()
        {
            InitializeComponent();

            bool pb1Clicked = false;
            bool pb2Clicked = false;
            bool pb3Clicked = false;
            bool pb4Clicked = false;
            bool pb5Clicked = false;
            bool pb6Clicked = false;
            bool pb7Clicked = false;
            bool pb8Clicked = false;
            bool pb9Clicked = false;

            pbClicked.Add(pb1Clicked);
            pbClicked.Add(pb2Clicked);
            pbClicked.Add(pb3Clicked);  
            pbClicked.Add(pb4Clicked);
            pbClicked.Add(pb5Clicked);
            pbClicked.Add(pb6Clicked);
            pbClicked.Add(pb7Clicked);
            pbClicked.Add(pb8Clicked);
            pbClicked.Add(pb9Clicked);


            SetUpNewGame();


        }
        

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            SetUpNewGame();
        }

        private void SetUpNewGame()
        {
            board = new ElevensBoard();
            // card slots on the board -> to list
            List<PictureBox> pictureBoxes = new List<PictureBox>();
            pictureBoxes = PicBoxToList();
            //List<PictureBox> pictureBoxes = PicBoxToList();

            FillPictureBoxes_AtStart();
            label1.Text = ($"{board.deck.listOfCards.Count} undealt cards remain");
            label2.Text = ($"You've won {wins} out of {wins + losses} games");
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {

            // let players choose cards to play
            List<int> selectedCards = new List<int>();
            List<PictureBox> pictureBoxes = PicBoxToList();

            for (int i = 0; i < pbClicked.Count; i++)
            {
                if (pbClicked[i] && pictureBoxes[i].Image != null)
                {
                    selectedCards.Add(i);
                    pbClicked[i] = false;
                    updatePictureBox(i);

                }
            }

            // if play is legal, remove/nullify cards on board
            // and deal new cards from deck
            if (board.IsLegal(selectedCards))
            {
                foreach (int index in selectedCards)
                {
                    board.cardsOnBoard[index] = null;
                    pictureBoxes[index].Image = null;
                }



                if (board.BoardIsEmpty())
                {
                    ++wins;
                    label2.Text = ($"You've won {wins} out of {wins + losses} games");
                    SetUpNewGame();
                }
                else if (!board.BoardIsEmpty() && !board.NextPlayPossible())
                {
                    ++losses;
                    label2.Text = ($"You've won {wins} out of {wins + losses} games");
                    SetUpNewGame();
                }
                else
                {
                    board.DealCards();
                    RefillPictureBoxes();
                    label1.Text = ($"{board.deck.listOfCards.Count} undealt cards remain");
                }
            }

        }


        private void FillPictureBoxes_AtStart()
        {
            ClearPictureBoxes();

            List<PictureBox> pictureBoxes = PicBoxToList();

            // puts cards in pictureBoxes
            for (int i = 0; i < pictureBoxes.Count && i < board.deck.NumCards; i++)
            {
                pictureBoxes[i].Image = board.cardsOnBoard[i].img;
            }
        }

        // a reflection of board.cardsOnBoard[] onto picture boxes
        private void RefillPictureBoxes()
        {
            List<PictureBox> pictureBoxes = PicBoxToList();

            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                if (pictureBoxes[i].Image == null && board.cardsOnBoard[i] != null)
                {
                    pictureBoxes[i].Image = board.cardsOnBoard[i].img;
                }
            }
        }

        private void ClearPictureBoxes()
        {
            List<PictureBox> pictureBoxes = PicBoxToList();

            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                pictureBoxes[i].Image = null;
            }
        }


        private void updatePictureBox(int index)
        {

            List<PictureBox> pictureBoxes = PicBoxToList();

            if (pbClicked[index])
            {
                pictureBoxes[index].Padding = new Padding(5);
            }
            else
            {
                pictureBoxes[index].Padding = new Padding(0);
            }

            this.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pbClicked[0] = !pbClicked[0];
            
            updatePictureBox(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pbClicked[1] = !pbClicked[1];

            updatePictureBox(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pbClicked[2] = !pbClicked[2];

            updatePictureBox(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pbClicked[3] = !pbClicked[3];

            updatePictureBox(3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pbClicked[4] = !pbClicked[4];

            updatePictureBox(4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pbClicked[5] = !pbClicked[5];

            updatePictureBox(5);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pbClicked[6] = !pbClicked[6];

            updatePictureBox(6);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pbClicked[7] = !pbClicked[7];

            updatePictureBox(7);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pbClicked[8] = !pbClicked[8];

            updatePictureBox(8);
        }

        public List<PictureBox> PicBoxToList()
        {
            List<PictureBox> pictureBoxes = new List<PictureBox>()
            {
                pictureBox1,
                pictureBox2, 
                pictureBox3, 
                pictureBox4, 
                pictureBox5, 
                pictureBox6, 
                pictureBox7,
                pictureBox8,
                pictureBox9
            };

            return pictureBoxes;
        }


    }
}
