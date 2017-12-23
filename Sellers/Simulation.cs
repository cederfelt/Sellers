using System;
using System.Collections.Generic;
using System.Text;

namespace Sellers
{
    public class Simulation
    {
        private bool[,] Board;

        public Simulation(long width, long height)
        {
            Board = new bool[width, height];
        }

    }
}
