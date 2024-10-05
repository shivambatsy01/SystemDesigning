using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ti_tac_toe.Models
{
    internal class Game
    {
        private Queue<Player> TurnQueue;
        public Board board;
        private bool GameOver = false, winnerDeclared = false;

        public Game(int boardSize)
        {
            TurnQueue = new Queue<Player>();
            board = new Board(boardSize);

        }


        public void RegisterPlayers(List<Player> players)
        {
            foreach (Player p in players)
            {
                TurnQueue.Enqueue(p);
            }
        }

        private void DeclareWinner(Player player)
        {
            Console.WriteLine("Winner is : " + player.Name);
            winnerDeclared = true;
            Console.ReadLine();
        }

        

        public void StartGame()
        {
            while (board.UnmarkedCells.Count > 0 && !winnerDeclared)
            {
                Player currPlayer = TurnQueue.Dequeue();
                Console.WriteLine("\nAvailable cells : ");
                foreach (Cell c in board.UnmarkedCells)
                {
                    Console.Write(c.id.ToString() + ", ");
                }
                Console.WriteLine();



                while (true)
                {
                    Console.WriteLine($"Hello {currPlayer.Name}! Enter Id of cells to mark......");
                    string input = Console.ReadLine(); //work as holding a thread
                    int id = int.Parse(input);
                    Cell cell = board.UnmarkedCells.FirstOrDefault(x => x.id == id);
                    if (cell != null)
                    {
                        currPlayer.MarkCell(cell);
                        if (board.CheckPattern(cell))
                        {
                            DeclareWinner(currPlayer);
                            return;
                        }
                        TurnQueue.Enqueue(currPlayer);
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Select a valid cell");
                    }
                }
            }
            Console.WriteLine("Game Over, No more cells available");
        }
    }
}
