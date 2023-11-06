using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidLibrary.Models
{
    public class Solver : Player
    {
        public Solver(Board board) : base(board)
        {

        }

        public List<List<Board>> Tree { get; set; }

        public void CheckIfSolvable()
        {
            // aggiungere clonare initial board e metterla nel tree[0][0]

            // entrare in while loop (o for loop, da decidere ancora)

            // salvare a parte la prima mossa disponibile nel tree[0][0] e cancellarla tra quelle disponibili
            // clonare board in tree[0][0] e metterla in tree[1][0]
            // fare la mossa messa da parte, modificando la board in tree[1][0]
            // controllare se vinto/perso
            // se perso
                // 
            // se vinto
                // ok
            // else
                // 
            // salvare a parte la prima mossa disponibile nel tree[1][0] e cancellarla tra quelle disponibili
            // clonare board in tree[1][0] e metterla in tree[2][0]
            // fare la mossa messa da parte, modificando la board in tree[2][0]
            // ecc...
            // 


            // se vinto return true / se perso return false
            // se nessuno deidu
        }
    }
}
