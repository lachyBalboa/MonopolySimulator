using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolySimulator
{
    class ChanceCard : Card
    {
        public ChanceCard(String name, Byte moveCount) : base(name, moveCount)
        {
            Name = name;
            MoveCount = moveCount;
        }

    }

     
}
