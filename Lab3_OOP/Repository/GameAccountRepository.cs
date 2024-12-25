using Lab3_OOP.DB_context;
using Lab3_OOP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OOP.Repository
{
    public class GameAccountRepository : IGameAccountRepository
    {
        private readonly DbContext _context;

        public GameAccountRepository(DbContext context)
        {
            _context = context;
        }

        public void AddGameAccount(string userName, string accountType)
        {

            GameAccount newGameAccount;

            switch (accountType)
            {
                case "standard":
                    newGameAccount = new StandardAccount(userName);
                    break;
                case "doubleRating":
                    newGameAccount = new DoubleRating(userName);
                    break;
                default:
                    Console.WriteLine("Invalid account type.");
                    return;
            }
            _context.GameAccounts.Add(newGameAccount);

        }

        public GameAccount GetGameAccountByName(string userName)
        {
            return _context.GameAccounts.FirstOrDefault(p => p.UserName == userName);
        }



        public void UpdateGameAccountName(string oldUserName, string newUserName)
        {
            var player = _context.GameAccounts.FirstOrDefault(p => p.UserName == oldUserName);
            if (player != null)
            {
                player.UserName = newUserName;
            }
        }

        public void DeleteGameAccount(string userName)
        {


            foreach (var game in _context.GameAccounts)
            {
                if (game.UserName == userName)
                {
                    _context.GameAccounts.Remove(game);
                    break;
                }
            }

        }


        public List<GameAccount> GetAllGameAccounts()
        {
            return _context.GameAccounts;
        }
    }
}
