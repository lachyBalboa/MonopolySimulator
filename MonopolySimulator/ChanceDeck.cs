using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolySimulator
{
    class ChanceDeck : Deck
    {
        //Deck<ChanceCard> CardDeck = new Deck<ChanceCard>();
        public Player PlayerWhoSelectedCard;
        public ChanceDeck(LinkedList<Card> cards)
        {
            CardDeck = cards;
        }

        public ChanceDeck() 
        {
            CardDeck.AddFirst(new ChanceCard("Go Back 3 Spaces", 3));
            CardDeck.AddFirst(new ChanceCard("Advance to Go", 0));
            CardDeck.AddFirst(new ChanceCard("Go To Jail", 10));
        }
    }
}
