using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSlider
{
    class Finder
    {
        public void FindEmptyElement(string[,] gameGrid, int[] emptyPos)
        {
            for (int i = 0; i <= 2; i++)
                for (int n = 0; n <= 2; n++)
                {
                    if (gameGrid[i, n].Equals(""))
                    {
                        emptyPos[0] = i;
                        emptyPos[1] = n;
                        return;
                    }
                }
        }
    }
}
