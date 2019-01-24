using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolySimulator
{
    class Player
    {
        public String PlayerName { get; set; }
        public Byte SpacesToMove { get; set; }
        public Byte CurrentIndex { get; set; }
        public int TotalFunds { get; set; }
        const int StartingFunds = 1500;
        public Player(String name)
        {
            PlayerName = name;
            TotalFunds = StartingFunds;
        }

        public void Move()
        {
            // How to handle modular value? Only 40 spaces then back to 1
            CurrentIndex += SpacesToMove;
        }

        public void Move(Byte SpacesToMove)
        {
            CurrentIndex += SpacesToMove;
        }
    }
}
