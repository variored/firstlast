using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace tusur_informatika_kursovaya
{
    public partial class Form1 : Form
    {

        private Game game = new Game();
        private List<String> allWords = new List<String>();
        private int gameType = 1; 

        public Form1()
        {
            InitializeComponent();
            StartNewGame();
            UpdateWindowInfo();
        }

        private void buttonGiveUp1_Click(object sender, EventArgs e)
        {
            game.SetGiveUp(1);
            UpdateWindowInfo();
            StartNewGame();
            
        }

        private void buttonGiveUp2_Click(object sender, EventArgs e)
        {
            game.SetGiveUp(2);
            UpdateWindowInfo();
            StartNewGame();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            /*Help();*/
        }

        private void buttonAboutMe_Click(object sender, EventArgs e)
        {
            /*form2.Show();*/
        }
        private void buttonEnterNewWord_Click(object sender, EventArgs e)
        {
            
            if (!game.IsRealWord(textBoxNewWord.Text.ToString().ToLower()))
            {
                MessageBox.Show("unreal word: " + textBoxNewWord.Text.ToString().ToLower(), "unreal word: " + textBoxNewWord.Text.ToString().ToLower());
            }
            else
            {
                if (!game.AddWord(textBoxNewWord.Text.ToString().ToLower()))
                {
                    ShowWordExists(textBoxNewWord.Text.ToString().ToLower());
                }
            }
            
            UpdateWindowInfo();
        }

        private void buttonStartNewGame_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }
        private void SetAllWordsOnScreen()
        {
            textBoxAllWords.Text = "";
            
            String[] allWords = game.GetAllWords();

            for (int i = 0; i <= allWords.Length-1; i++)
            {
                if (i < allWords.Length - 1)
                {
                    textBoxAllWords.Text += allWords[i] + ", ";
                }
                else if (i == allWords.Length - 1)
                {
                    textBoxAllWords.Text += allWords[i];
                }
            }
        }
        private void UpdateWindowInfo()
        {
            //move textbox

            textBoxNewWord.Text = "";

            if (game.CheckLoser() == 0)
            {
                UpdateCounters();
                UpdateIWalkLabel();
                SetAllWordsOnScreen();
            }
            else
            {
                ShowWhoLoser();
            }
        }
        private void ShowWhoLoser()
        {
            if (game.CheckLoser() == 1)
            {
                ShowLoser(1);
            }
            else if (game.CheckLoser() == 2)
            {
                ShowLoser(2);
            }
        }
        private void UpdateCounters()
        {
            labelUser1Counter.Text = game.GetCount(1).ToString();
            labelUser2Counter.Text = game.GetCount(2).ToString();

        }
        private void UpdateIWalkLabel()
        {

            if (game.GetCurrentPlayer() == 1)
            {
                labelIWalk1.Text = "ваше слово..";
                labelIWalk2.Text = "";
            }
            if (game.GetCurrentPlayer() == 2)
            {
                labelIWalk1.Text = "";
                labelIWalk2.Text = "ваше слово..";
            }
        }
        private void ShowLoser(int _Id)
        {
            MessageBox.Show("loser: " + _Id, "loser: " + _Id);
        }
        private void ShowWordExists(String _word)
        {
            MessageBox.Show("wordExists: " + _word, "word exists: " + _word);
        }
        private void StartNewGame()
        {
            game.StartNewGame();
            game.SetGameType(gameType);
            SetWindowTitle();
            UpdateWindowInfo();

        }
        private void SetWindowTitle()
        {
            if (gameType == 1)
            {
                this.Text = "FirstLast: Города";
            }
            if (gameType == 2)
            {
                this.Text = "FirstLast: Имена";
            }
            if (gameType  == 3)
            {
                this.Text = "FirstLast: Животные";
            }
        }
        public void SetNewGameType(int _newGameType)
        {
            gameType = _newGameType;
        }
    }
}
