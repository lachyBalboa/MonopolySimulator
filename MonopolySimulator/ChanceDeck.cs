using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolySimulator
{
    class ChanceDeck : Deck
    {
        //Deck<ChanceCard> CardDeck = new Deck<ChanceCard>();
        public ChanceDeck() { }
        public ChanceDeck(LinkedList<Card> cards)
        {
            CardDeck = cards;
        }
    }
}
