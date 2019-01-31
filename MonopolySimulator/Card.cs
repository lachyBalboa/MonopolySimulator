using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolySimulator
{
    public class Card
    {
        public String Name { get; set; }
        public int MoveToIndex { get; set; }
        public Card(String name, int moveToIndex)
        {
            Name = name;
            MoveToIndex = moveToIndex;
        }
    }
}
