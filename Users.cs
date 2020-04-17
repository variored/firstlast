﻿using System;
using System.Collections.Generic;

namespace tusur_informatika_kursovaya
{
    class Users
    {
        private List<User> users = new List<User>();
        private int wordsCount;

        public Users()
        {


            for (int i = 0; i <= 2-1; i++)
            {
                users.Add(AddUser());
            }
        }


        public int GetCount(int _Id)
        {
            return users[_Id - 1].GetCount();
        }
        public void AddWord(String _word, int _Id)
        {
            users[_Id - 1].AddWord(_word);
        }
        public String[] GetWords(int _Id)
        {
            return users[_Id - 1].GetWordsList();
        }
        public void SetGiveUp(int _Id)
        {
            users[_Id - 1].GiveUp();
        }
        public int CheckLoser()
        {
            if (users[0].IsLoser())
            {
                return 1;
            }
            if (users[1].IsLoser())
            {
                return 2;
            }
            return 0;
        }
        public int GetTotalSum()
        {
            return users[0].GetCount() + users[1].GetCount();
        }
        public void SetGameType(int _gameType)
        {
            users[0].SetGameType(_gameType);
            users[1].SetGameType(_gameType);
        }
        public void ResetUsersData()
        {
            users[0].ReserData();
            users[1].ReserData();
        }

        internal bool IsRealWord(string _word, int _Id)
        {
            return users[_Id - 1].IsRealWord(_word);
        }

        private User AddUser()
        {
            return new User();
        }
    }
}