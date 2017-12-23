using System;
using System.Collections.Generic;
using System.Linq;

namespace Sellers
{
    public class Simulation
    {
        private bool[,] Board;
        private long TotalAmount;
        private long Width;
        private long Height;
        private List<SalesPerson> Sellers;
        private Random Rnd;

        public Simulation(long width, long height)
        {
            Board = new bool[width, height];
            Width = width;
            Height = height;
            TotalAmount = width * height;
            Sellers = new List<SalesPerson>();
            Sellers.Add(new SalesPerson(0, 0));
            Board[0, 0] = false;
            Rnd = new Random();
        }

        public (long X, long Y) NewPosition(long x, long y)
        {

            (long, long) position = (x, y);
            do
            {
                var t = Rnd.Next(0, 4);
                switch (t)
                {
                    case 0:
                        position = (x + 1, y);
                        break;
                    case 1:
                        position = (x, y + 1);
                        break;
                    case 2:
                        position = (x - 1, y);
                        break;
                    case 3:
                        position = (x, y - 1);
                        break;
                }
            } while (position.Item1 < 0 || position.Item2 < 0 || position.Item1 >= Width || position.Item2 >= Height);
            return position;
        }

        public void RunSimulation()
        {
            long nrSellers = 1;
            long time = 0;
            while (nrSellers < TotalAmount)
            {
                long currentSellers = Sellers.Where(x => x != null).Count();
                for (int i = 0; i < currentSellers; i++)
                {
                    var seller = Sellers[i];
                    if (seller != null)
                    {
                        var newPost = NewPosition(seller.X, seller.Y);
                        seller.X = newPost.X;
                        seller.Y = newPost.Y;

                        if (!Board[newPost.X, newPost.Y])
                        {
                            Sellers.Add(new SalesPerson(newPost.X, newPost.Y));
                            Board[newPost.X, newPost.Y] = true;
                            nrSellers++;
                        }
                    }
                }
                time = time + 1;
            }
            Console.WriteLine(time);
            Console.ReadLine();
        }

    }
}
