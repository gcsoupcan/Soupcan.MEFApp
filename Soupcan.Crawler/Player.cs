using System;
using System.Collections.Generic;
using System.Text;

namespace Soupcan.Crawler
{
    public class Player
    {
        public int Location { get; set; }

        public Player()
        {
        }

        public Player(int startingLocation)
        {
            Location = startingLocation;
        }

        public void Move()
        {
            Location++;
        }

        public void MoveBack()
        {
            Location = Math.Max(0, Location -1);
        }
    }
}
