using System;
using System.Collections.Generic;

namespace tusur_informatika_kursovaya
{
    class Game
    {
        private Users users = new Users();
        private int gameType;
        private List<String> allWords = new List<String>();
        private int currentPlayer;

        public Game()
        {
            SetCurrentPlayer(1);
        }
        public int GetCount(int _Id)
        {
            return users.GetCount(_Id);
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
                switchUser();
            }
            return true;
            
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
        public String[] GetWords(int _Id)
        {
            return users.GetWords(_Id);
        }
        public int GetTotalSum()
        {
            return users.GetTotalSum();
        }

        public bool IsRealWord(string _word)
        {
            return users.IsRealWord(_word, currentPlayer);
        }

        public void SetGameType(int _newGameType)
        {
            users.SetGameType(_newGameType);
        }

        public bool ViaRules(string _word)
        {
            if (allWords.Count == 0)
            {
                return true;
            }
            if (allWords[allWords.Count-1][allWords[allWords.Count - 1].Length-1] == _word[0])
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
        private bool WordExists(String _word)
        {
            if (allWords.IndexOf(_word) == -1)
            {
                return false;
            }
            else return true;
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

    }
}
