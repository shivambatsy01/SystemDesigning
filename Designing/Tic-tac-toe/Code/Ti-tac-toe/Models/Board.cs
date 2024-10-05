using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ti_tac_toe.Models
{
    internal class Board
    {
        int n;
        private Cell[,] Cells;
        public List<Cell> UnmarkedCells;

        public Board(int n)
        {
            this.n = n;
            Cells = new Cell[n, n];
            UnmarkedCells = new List<Cell>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var cell = new Cell()
                    {
                        i = i,
                        j = j,
                        IsMarked = false,
                        id = i * n + j,
                        Mark = Signs.None,
                    };

                    Cells[i, j] = cell;
                    UnmarkedCells.Add(cell); //Only reference (Association)
                }
                    
            }
        }
        List<Cell> GetUnMarkedCells()
        {
            return UnmarkedCells;
        }

        public bool CheckPattern(Cell cell)
        {
            Signs mark = cell.Mark;
            int i=cell.i, j=cell.j;

            if (i>=0 && i<n && j-1>=0 && j+1<n && Cells[i,j-1].Mark==mark && Cells[i,j+1].Mark==mark) return true;
            //more combinations


            return false;
        }
    }
}
