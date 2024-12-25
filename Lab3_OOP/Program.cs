using Lab3_OOP.DB_context;
using Lab3_OOP.Repository;
using Lab3_OOP.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OOP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dbContext = new DbContext();
            var playerRepo = new GameAccountRepository(dbContext);
            var gameRepo = new GameRepository(dbContext);


            var playerService = new GameAccountService(playerRepo);
            var gameService = new GameService(gameRepo, playerRepo);

            playerService.CreateGameAccount("Player1", "standard");
            playerService.CreateGameAccount("Player2", "doubleRating");
            playerService.CreateGameAccount("Player3", "standard");




            gameService.PlayGame("Player1", "Player2", true, "Standard");
            gameService.PlayGame("Player3", "Player2", false, "Training");


            playerService.DisplayGameAccountStats("Player1");
            playerService.DisplayGameAccountStats("Player2");
            playerService.DisplayGameAccountStats("Player3");

            playerService.DeleteGameAccount("Player1");

            gameService.GetAllGames();

            gameService.DeleteGame(2);

            gameService.GetAllGames();



            Console.WriteLine("All Players:");
            playerService.GetAllGameAccounts();

            playerService.UpdateGameAccountName("Player2", "Player4");

            Console.WriteLine("All Players:");
            playerService.GetAllGameAccounts();



        }
    }
}
