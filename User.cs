using System;
using System.Collections.Generic;

namespace tusur_informatika_kursovaya
{
    class User
    {
        private bool isBot;
        private List<String> hasWords = new List<String>();
        private bool lose;
        private Words words;
        private int gameType;
        private int score = 0;
        

        public User()
        {

        }
        public void AddPoint()
        {
            score++;
        }
        public int GetScore()
        {
            return score;
        }
        public List<String> GetLibrary()
        {
            return words.GetAllWords();
        }
        public String[] GetWordsList()
        {
            String[] wordsArray = new String[hasWords.Count-1];
            for(int i = 0; i < hasWords.Count-1; i++)
            {
                wordsArray[i] = hasWords[i];
            }
            return wordsArray;
        }
        public int GetCount()
        {
            return hasWords.Count;
        }
        public void GiveUp()
        {
            lose = true;
        }
        public bool IsLoser()
        {
            return lose;
        }
        public void SetGameType(int _gameType)
        {
            gameType = _gameType;
            CreateWords();
            
        }
        public void AddWord(String _word)
        {
            hasWords.Add(_word);
        }
        public void ReserData()
        {
            hasWords.Clear();
            lose = false;
        }
        private void CreateWords()
        {
            if (gameType == 1)
            {
                words = new Cities();
            }
            else if (gameType == 2)
            {
                words = new Animals();
            }
            else if (gameType == 3)
            {
                words = new Names();
            }
        }

        public bool IsRealWord(string _word)
        {
            string firstUpper = _word;
            for (int i = 0; i < _word.Length; i++)
            {
                if (i == 0)
                {
                    firstUpper = firstUpper.ToCharArray()[0].ToString().ToUpper();
                }
                else
                {
                    firstUpper += _word.ToCharArray()[i].ToString();
                }
            }
            

            return words.Exists(firstUpper);
        }
    }
}
