using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolySimulator
{
    class CommunityChestCard : Card
    {
        public CommunityChestCard(String name, int moveToIndex) : base(name, moveToIndex)
        {
            Name = name;
            MoveToIndex = moveToIndex;
        }
    }
}
