using Lab3_OOP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OOP.Repository
{
    public interface IGameRepository
    {
        void AddGame(Game game);

        public (Game, Game) CreateGame(string gameType, GameAccount player1, GameAccount player2, bool isWin);
        List<Game> GetAllGames();

        void DeleteGame(int gameId);

    }
}
