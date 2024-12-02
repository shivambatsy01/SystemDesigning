using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    
    public class Jump //both snake and ladder : end>start : ladder, end<start : snake
    {
        public int start;
        public int end;
        int jumpSize;

        public Jump(int s, int e)
        {
            start = s;
            end = e;
            jumpSize = end-start;
        }

        public int getJumpSize
        {
            get => jumpSize;
        }
    }
    public class Cell
    {
        public Jump Jump;
    }
    public class Player
    {
        string name;
        int position;
        Game game;
        public Player(string n, int p, Game game)
        {
            this.name = n;
            this.position = p;
            this.game = game;
        }

        public void MakeMove()
        {
            int add = game.dice.GenerateNumber();
            position += add;
            if (position<game.board.GetBoardSize &&  game.board.Cells[position] != null)
            {
                position += game.board.Cells[position].Jump.getJumpSize;
            }
        }

        public bool isWinner()
        {
            return position > game.board.GetBoardSize;
        }
    }

    public class Dice
    {
        int numberOfDice;
        int numberOfFaces;
        Random randomGenerator;
        public Dice(int numberOfDice, int numberOfFaces)
        {
            this.numberOfDice = numberOfDice;
            this.numberOfFaces = numberOfFaces;
            randomGenerator = new Random();
        }

        public int GenerateNumber()
        {
            int total = 0;

            for(int i=0; i<numberOfDice; i++)
            {
                total += 1 + randomGenerator.Next() % numberOfFaces;
            }
            return total;
        }

    }

    public class Board
    {
        int n;
        public Cell[] Cells ;
        public Board(int cellCount, List<Jump> jumps)
        {
            this.n = cellCount;
            Cells = new Cell[cellCount];

            foreach(Jump jump in jumps)
            {
                Cells[jump.start].Jump = jump;
            }
        }

        public int GetBoardSize
        {
            get => n;
        }

    }


    public class Game
    {
        Queue<Player> playerQueue;
        Queue<Player> winnerList;//winners queue: first if first position winner
        public Board board;
        public Dice dice;
        public Game(int boardSize, List<Jump> jumps, int diceFaces, int diceCount, List<Player> players)
        {
            board = new Board(boardSize, jumps);
            dice = new Dice(diceCount, diceFaces);
            playerQueue = new Queue<Player>();
            foreach(Player player in players)
            {
                playerQueue.Enqueue(player);
            }
        }

        public void StartGame()
        {
            while(playerQueue.Count > 1)
            {
                Player player = playerQueue.Dequeue();
                player.MakeMove();
                if(!player.isWinner())
                {
                    playerQueue.Enqueue(player);
                }
                else
                {
                    winnerList.Enqueue(player);
                }
            }
        }
    }
}
