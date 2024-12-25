using Lab3_OOP.DB_context;
using Lab3_OOP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OOP.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly DbContext _context;
        private static int gameId;

        public GameRepository(DbContext context)
        {
            _context = context;
        }

        public (Game, Game) CreateGame(string gameType, GameAccount player1, GameAccount player2, bool isWin)
        {
            return gameType switch
            {
                "Standard" => (
                    new StandardGame(player2.UserName, player1.UserName, ++gameId, isWin),
                    new StandardGame(player1.UserName, player2.UserName, gameId, !isWin)
                ),
                "Training" => (
                    new TrainingGame(player2.UserName, player1.UserName, ++gameId, isWin),
                    new TrainingGame(player1.UserName, player2.UserName, gameId, !isWin)
                ),
                _ => throw new ArgumentException("Invalid game type")
            };
        }

        public void AddGame(Game game)
        {
            _context.Games.Add(game);
        }

        public List<Game> GetAllGames()
        {
            return _context.Games;
        }


        public void DeleteGame(int gameId)
        {
            var gameToRemove = _context.Games.FirstOrDefault(game => game.GameId == gameId);
            if (gameToRemove != null)
            {
                _context.Games.Remove(gameToRemove);
            }

        }
    }
}
