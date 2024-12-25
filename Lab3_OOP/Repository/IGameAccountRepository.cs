using Lab3_OOP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OOP.Repository
{
    public interface IGameAccountRepository
    {
        public void AddGameAccount(string userName, string accountType);
        GameAccount GetGameAccountByName(string userName);
        List<GameAccount> GetAllGameAccounts();

        void UpdateGameAccountName(string oldUserName, string newUserName);

        void DeleteGameAccount(string userName);


    }
}
