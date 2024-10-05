using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ti_tac_toe.Models
{
    internal class Player
    {
        Board board;
        Signs PlayerSign;
        public string Name { get; set; }

        public Player()
        {
                
        }
        public Player(Signs playerSign, string name, Board board)
        {
            PlayerSign = playerSign;
            Name = name;
            this.board = board;
        }


        public bool MarkCell(Cell cell)
        {
            if (cell.IsMarked)
            {
                return false;
            }

            cell.IsMarked = true;
            cell.Mark = PlayerSign;
            board.UnmarkedCells.Remove(cell);
            return true;
        }
    }
}
