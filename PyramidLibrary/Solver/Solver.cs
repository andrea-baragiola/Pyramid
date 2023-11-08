using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PyramidLibrary.Models;

namespace PyramidLibrary.Solver
{
    public class Solver : Player
    {
        public Tree Tree { get; set; }
        public Solver(Board board) : base(board)
        {

        }

        public void Solve()
        {
            //Tree.Ad
        }
    }
}
