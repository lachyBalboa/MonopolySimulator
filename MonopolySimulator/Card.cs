using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolySimulator
{
    public class Card
    {
        public String Name { get; set; }
        public Byte MoveCount { get; set; }
        public Card(String name, Byte moveCount)
        {
            Name = name;
            MoveCount = moveCount;
        }
    }
}
