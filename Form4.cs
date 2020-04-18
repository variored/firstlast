using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tusur_informatika_kursovaya
{
    

    public partial class Form4 : Form
    {
        Words words;
        int gameType = 0;
        List<String> allWords = new List<String>();

        public Form4(int _gameType)
        {
            InitializeComponent();

            gameType = _gameType;
            CreateWords();
            UpdateWindow();

        }
        private void CreateWords()
        {
            if (gameType == 1)
            {
                words = new Cities();
            }
            if (gameType == 2)
            {
                words = new Animals();
            }
            if (gameType == 3)
            {
                words = new Names();
            }
            allWords = words.GetAllWords();
        }
        private void UpdateWindow()
        {
            SetTitle();
            SetLibrary();
        }
        private void SetTitle()
        {
            if (gameType == 1)
            {
                pictureBoxWordsLogo.Image = Resource.help_city;
                labelTitle.Text = "Города";
            }
            if (gameType == 2)
            {
                pictureBoxWordsLogo.Image = Resource.help_animal;
                labelTitle.Text = "Животные";
            }
            if (gameType == 3)
            {
                pictureBoxWordsLogo.Image = Resource.help_name;
                labelTitle.Text = "Имена";
            }
        }
        private void SetLibrary()
        {
            labelWords.Text = "";
            int counter = 1;
            char lastLetter = '-';
            
            foreach(String word in allWords)
            {
                
                if (word[0] != lastLetter)
                {
                    labelWords.Text += "\n" + word[0].ToString().ToUpper() + "\n";
                }
            

                labelWords.Text += counter++.ToString() + ":\t" + word + "\n";
                lastLetter = word[0];
            }
            }
        }
}
