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

        

        public User()
        {

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
            if (gameType == 0)
            {
                words = new Cities();
            }
            else if (gameType == 1)
            {
                words = new Animals();
            }
            else if (gameType == 2)
            {
                words = new Names();
            }
        }

        internal bool IsRealWord(string _word)
        {
            return words.Exists(_word);
        }
    }
}
