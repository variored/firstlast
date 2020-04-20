using System;
using System.Windows.Forms;

namespace tusur_informatika_kursovaya
{
    public partial class Form1 : Form
    {
        private Game game = new Game();
        private int gameType = 1;
        private string lastWord = "";

        public Form1()
        {
            InitializeComponent();
            StartNewGame();
            UpdateWindowInfo();
            buttonHelp_Click(buttonHelp, EventArgs.Empty);
        }
        private void buttonGiveUp1_Click(object sender, EventArgs e)
        {
            game.SetGiveUp(1);
            UpdateWindowInfo();
            StartNewGame();
            
        }
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
        private void buttonAboutMe_Click(object sender, EventArgs e)
        {
            Form3 form3_AboutMe = new Form3();
            form3_AboutMe.Show();
        }
        private void buttonEnterNewWord_Click(object sender, EventArgs e)
        {
            


            if (!game.IsRealWord(textBoxNewWord.Text.ToString().ToLower()))
            {
                MessageBox.Show("Вы ввели не существующее слово: " + textBoxNewWord.Text.ToString().ToLower(), "СЛОВО НЕ СУЩЕСТВУЕТ");
            }
            else
            {
                if (!game.ViaRules(textBoxNewWord.Text.ToString().ToLower()))
                {
                    ShowIncorrectLetter();
                }
                else
                {
                    if (!game.AddWord(textBoxNewWord.Text.ToString().ToLower()))
                    {
                        ShowWordExists(textBoxNewWord.Text.ToString().ToLower());
                    }
                }
            }
            
            UpdateWindowInfo();
            
            //if the next player is computer
            if (game.GetCurrentPlayer() == 2)
            {
                lastWord = game.GetNewWordWithLetter(textBoxNewWord.Text[0]);
                
                if (lastWord == "lose")
                {
                    ComputerGiveUp();
                }
                else
                {
                    textBoxNewWord.Text = lastWord;
                    buttonEnterNewWord_Click(buttonEnterNewWord, EventArgs.Empty);
                }
                
            }
        }
        private void ComputerGiveUp()
        {
            game.SetGiveUp(2);
            UpdateWindowInfo();
            StartNewGame();
        }
        private void ShowIncorrectLetter()
        {
            MessageBox.Show("Слово должно начинаться на букву: " + game.GetLastLetter().ToString().ToUpper(), "ОШИБКА");
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
            
            textBoxNewWord.Text = "";

            if (game.CheckLoser() == 0)
            {
                UpdateCounters();
                UpdateIWalkLabel();
                SetAllWordsOnScreen();
                AddFirsLetterOfNextWord();
            }
            else
            {
                ShowWhoLoser();
            }
        }
        private void AddFirsLetterOfNextWord()
        {
            if (game.GetLastLetter() != '-')
            {
                textBoxNewWord.Text = game.GetLastLetter().ToString().ToUpper();
            }
        }
        private void ShowWhoLoser()
        {
            if (game.CheckLoser() == 1)
            {
                ShowWinner(1);
            }
            else if (game.CheckLoser() == 2)
            {
                ShowWinner(2);
            }
        }
        private void UpdateCounters()
        {
            labelUser1Counter.Text = game.GetScore(1).ToString();
            labelUser2Counter.Text = game.GetScore(2).ToString();

        }
        private void UpdateIWalkLabel()
        {

            if (game.GetCurrentPlayer() == 1)
            {
                labelIWalk1.Text = "ваше слово..";
            }
            else
            {
                labelIWalk1.Text = "";
            }
        }
        private void ShowWinner(int _Id)
        {
            Form5 formWinner = new Form5();
            formWinner.SetLoser(_Id);
            formWinner.Show();
            game.AddPoint(_Id);
        }
        private void ShowWordExists(String _word)
        {
            MessageBox.Show("Слово уже названо: " + _word, "ОШИБКА");
        }
        private void StartNewGame()
        {
            game.StartNewGame();
            game.SetGameType(gameType);
            game.FillReminingWords();

            SetNewColorButtonGameType();
            textBoxNewWord.Text = "";
            UpdateWindowInfo();

        }
        private void SetNewGameType(int _newGameType)
        {
            gameType = _newGameType;
        }
        private void SetNewColorButtonGameType()
        {
            panelBottomColorGameTypeCities.BackColor = System.Drawing.Color.Transparent;
            panelBottomColorGameTypeAnimals.BackColor = System.Drawing.Color.Transparent;
            panelBottomColorGameTypeNames.BackColor = System.Drawing.Color.Transparent;
            buttonGameTypeCities.BackColor = System.Drawing.Color.Transparent;
            buttonGameTypeAnimals.BackColor = System.Drawing.Color.Transparent;
            buttonGameTypeNames.BackColor = System.Drawing.Color.Transparent;

            if (gameType == 1)
            {
                panelBottomColorGameTypeCities.BackColor = System.Drawing.Color.DodgerBlue;
                buttonGameTypeCities.BackColor = System.Drawing.Color.WhiteSmoke;
            }
            if (gameType == 2)
            {
                panelBottomColorGameTypeAnimals.BackColor = System.Drawing.Color.DodgerBlue;
                buttonGameTypeAnimals.BackColor = System.Drawing.Color.WhiteSmoke;
            }
            if (gameType == 3)
            {
                panelBottomColorGameTypeNames.BackColor = System.Drawing.Color.DodgerBlue;
                buttonGameTypeNames.BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }
        private void buttonGameTypeNames_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("начать новую игру \"Имена\"?", "начать новую игру", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SetNewGameType(3);
                StartNewGame();
            }
        }
        private void buttonGameTypeAnimals_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("начать новую игру \"Животные\"?", "начать новую игру", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SetNewGameType(2);
                StartNewGame();
            }
        }
        private void buttonGameTypeCities_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("начать новую игру \"Города\"?", "начать новую игру", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SetNewGameType(1);
                StartNewGame();
            }
        }
        private void buttonLibrary_Click(object sender, EventArgs e)
        {
            Form4 form4_Help = new Form4(gameType);
            form4_Help.Show();
        }

    }
}
