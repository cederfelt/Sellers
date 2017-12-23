using System;
using System.Collections.Generic;
using System.Text;

namespace Sellers
{
    public class Simulation
    {
        private bool[,] Board;
        private long TotalAmount;
        private SalesPerson[] Sellers;

        public Simulation(long width, long height)
        {
            Board = new bool[width, height];
            TotalAmount = width * height;
            Sellers = new SalesPerson[TotalAmount];
        }

        public void RunSimulation()
        {
            long nrSellers = 0;
            while(nrSellers < TotalAmount)
            {

            }
        }

    }
}
