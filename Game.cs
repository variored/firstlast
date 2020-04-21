using System;
using System.Collections.Generic;
namespace tusur_informatika_kursovaya
{
    class Game
    {
        private Users users = new Users();
        private List<String> allWords = new List<String>();
        private List<String> remainingWords = new List<String>();
        private int currentPlayer;

        public Game()
        {
            SetCurrentPlayer(1);
        }
        public bool AddWord(String _word)
        {
            
            if (WordExists(_word))
            {
                return false;
            }
            else
            {
                users.AddWord(_word, currentPlayer);
                allWords.Add(_word);
                String newWord = FirstUpper(_word);
                remainingWords.Remove(newWord);
                switchUser();
            }
            return true;
        }
        public void AddPoint(int _Id)
        {
            users.AddPoint(_Id);
        }
        public int GetScore(int _Id)
        {
            return users.GetScore(_Id);
        }
        public void FillReminingWords()
        {

            remainingWords = users.GetLibrary();
        }
        public bool IsRealWord(string _word)
        {
            return users.IsRealWord(_word, currentPlayer);
        }
        public void SetGameType(int _newGameType)
        {
            users.SetGameType(_newGameType);
        }
        public String GetLastWord()
        {
            if (allWords.Count == 0)
            {
                return "";
            }
            else
            {
                return allWords[allWords.Count - 1];
            }
        }
        public string GetNewWordWithLetter(char _firstLetter)
        {
            foreach(String word in remainingWords)
            {
                if (word[0] == _firstLetter)
                {
                    return word;
                }
            }
            return "lose";
        }
        public char GetLastLetter()
        {
            int indexOfLast = 1;

            if (allWords.Count == 0)
            {
                return '-';
            }
            
            return allWords[allWords.Count - 1][allWords[allWords.Count - 1].Length - GetCorrentIndexOfLastLetter()];
            
        }
        public bool ViaRules(string _word)
        {
            

            if (allWords.Count == 0)
            {
                return true;
            }
            
            if (allWords[allWords.Count-1][allWords[allWords.Count - 1].Length - GetCorrentIndexOfLastLetter()] == _word[0])
            {
                return true;
            }
            return false;
        }
        public void SetGiveUp(int _Id)
        {
            users.SetGiveUp(_Id);

        }
        public int CheckLoser()
        {
            return users.CheckLoser();
        }
        public void SetCurrentPlayer(int _Id)
        {
            currentPlayer = _Id;
        }
        public int GetCurrentPlayer()
        {
            return currentPlayer;
        }
        public void StartNewGame()
        {
            users.ResetUsersData();
            currentPlayer = 1;
            allWords.Clear();
        }
        public String[] GetAllWords()
        {
            String[] buffAllWords = new String[allWords.Count];

            for (int i = 0; i <= allWords.Count - 1; i++)
            {
                buffAllWords[i] = allWords[i];
            }

            return buffAllWords;
        }
        private bool WordExists(String _word)
        {
            if (allWords.IndexOf(_word) == -1)
            {
                return false;
            }
            else return true;
        }
        private int GetCorrentIndexOfLastLetter()
        {
            int indexOfLast = 1;
            while (allWords[allWords.Count - 1][allWords[allWords.Count - 1].Length - indexOfLast] == 'ь'
                || allWords[allWords.Count - 1][allWords[allWords.Count - 1].Length - indexOfLast] == 'ъ'
                || allWords[allWords.Count - 1][allWords[allWords.Count - 1].Length - indexOfLast] == 'й'
                || allWords[allWords.Count - 1][allWords[allWords.Count - 1].Length - indexOfLast] == 'ы')
            {
                indexOfLast++;
            }
            return indexOfLast;
        }
        private String FirstUpper(String _word)
        {
            string firstUp = _word;
            for (int i = 0; i < _word.Length; i++)
            {
                if (i == 0)
                {
                    firstUp = firstUp.ToCharArray()[0].ToString().ToUpper();
                }
                else
                {
                    firstUp += _word.ToCharArray()[i].ToString();
                }
            }
            return firstUp;

        }
        private void switchUser()
        {
            if (currentPlayer == 1)
            {
                SetCurrentPlayer(2);
            }
            else
            {
                SetCurrentPlayer(1);
            }
        }
    }
}
