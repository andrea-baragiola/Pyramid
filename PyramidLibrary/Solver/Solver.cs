using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PyramidLibrary.Models;

namespace PyramidLibrary.Solver
{
    public class Solver
    {
        public Tree Tree { get; set; }
        public Solver(Board rootBoard)
        {
            Tree = new(rootBoard);
        }

        public void Solve()
        {
            //Tree.Ad
        }
    }
}
