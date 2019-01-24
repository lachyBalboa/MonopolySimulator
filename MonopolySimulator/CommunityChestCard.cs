using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolySimulator
{
    class CommunityChestCard : Card
    {
        public CommunityChestCard(String name, Byte moveCount) : base(name, moveCount)
        {
            Name = name;
            MoveCount = moveCount;
        }
    }
}
