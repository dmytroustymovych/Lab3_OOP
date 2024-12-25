using Lab3_OOP.Factory;
using Lab3_OOP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OOP.Service
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGameAccountRepository _gameAccountRepository;

        public GameService(IGameRepository gameRepository, IGameAccountRepository gameAccountRepository)
        {
            _gameRepository = gameRepository;
            _gameAccountRepository = gameAccountRepository;
        }

        public void PlayGame(string player1Name, string player2Name, bool isWin, string gameType)
        {
            var player1 = _gameAccountRepository.GetGameAccountByName(player1Name);
            var player2 = _gameAccountRepository.GetGameAccountByName(player2Name);

            var (winnerGame, loserGame) = _gameRepository.CreateGame(gameType, player1, player2, isWin);
            player1.WinGame(winnerGame);
            player2.LoseGame(loserGame);

            _gameRepository.AddGame(winnerGame);
            _gameRepository.AddGame(loserGame);
        }


        public void GetAllGames()
        {
            var uniqueGames = _gameRepository.GetAllGames()
                .GroupBy(game => game.GameId)
                .Select(group => group.First());
            Console.WriteLine("All Games:");

            foreach (var game in uniqueGames)
            {

                Console.WriteLine($"Game ID: {game.GameId},  {game.WinnerName} vs {game.OpponentName}");


            }

        }

        public void DeleteGame(int gameId)
        {
            _gameRepository.DeleteGame(gameId);
        }

    }
}
