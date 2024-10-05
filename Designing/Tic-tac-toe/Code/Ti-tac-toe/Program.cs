using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Ti_tac_toe.Models;

namespace Ti_tac_toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game newGame = new Game(3);
            List<Player> newPlayers = new List<Player>()
            {
                new Player(Signs.Cross, "Rajeev Gandhi", newGame.board),
                new Player(Signs.Circle, "Sanjai Gandhi", newGame.board)
            };
            newGame.RegisterPlayers(newPlayers);

            newGame.StartGame();
        }
    }
}
