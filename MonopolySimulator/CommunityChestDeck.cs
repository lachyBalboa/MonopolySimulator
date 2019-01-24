using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolySimulator
{
    class CommunityChestDeck : Deck
    {
        public CommunityChestDeck() { }
        public CommunityChestDeck(LinkedList<Card> cards)
        {
            CardDeck = cards;
        }
    }
}
