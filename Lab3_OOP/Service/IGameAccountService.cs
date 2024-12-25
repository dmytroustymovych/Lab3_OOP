using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OOP.Service
{
    public interface IGameAccountService
    {
        void DisplayGameAccountStats(string userName);
        void UpdateGameAccountName(string oldUserName, string newUserName);
        void CreateGameAccount(string userName, string accountType);
        void DeleteGameAccount(string userName);
        void GetAllGameAccounts();

    }
}
