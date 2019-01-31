using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolySimulator
{
    class ChanceCard : Card
    {
        public ChanceCard(String name, int moveToIndex) : base(name, moveToIndex)
        {
            Name = name;
            MoveToIndex = moveToIndex;
        }

    }

     
}
