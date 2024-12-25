using Lab3_OOP.Entities;
using Lab3_OOP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OOP.Service
{
    public class GameAccountService : IGameAccountService
    {
        private readonly IGameAccountRepository _gameAccountRepository;

        public GameAccountService(IGameAccountRepository gameAccountRepository)
        {
            _gameAccountRepository = gameAccountRepository;
        }

        public void DisplayGameAccountStats(string userName)
        {
            var player = _gameAccountRepository.GetGameAccountByName(userName);
            if (player != null) player.GetStats();
            else Console.WriteLine($"Player {userName} not found.");
        }

        public void UpdateGameAccountName(string oldUserName, string newUserName)
        {
            _gameAccountRepository.UpdateGameAccountName(oldUserName, newUserName);
        }

        public void CreateGameAccount(string userName, string accountType)
        {

            _gameAccountRepository.AddGameAccount(userName, accountType);
        }

        public void DeleteGameAccount(string userName)
        {
            _gameAccountRepository.DeleteGameAccount(userName);
        }

        public void GetAllGameAccounts()
        {

            foreach (var gameAccount in _gameAccountRepository.GetAllGameAccounts())
            {
                Console.WriteLine(gameAccount.UserName);
            }
        }

    }
}
