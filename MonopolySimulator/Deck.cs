using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolySimulator
{
    class Deck
    {
        public LinkedList<Card> CardDeck = new LinkedList<Card>();
        public Deck() { }
        public Deck(LinkedList<Card> cards)
        {
            CardDeck = cards;
        }

        public void SwapCards()
        {
            LinkedListNode<Card> topCard = CardDeck.First;
            LinkedListNode<Card> lastCard = CardDeck.Last;

            // Place the top card on the bottom of the deck.
            CardDeck.RemoveFirst();
            CardDeck.AddAfter(lastCard, topCard.Value);

        }

        public Card DrawCard()
        {
            LinkedListNode<Card> drawnCardNode = CardDeck.First;
            Card drawnCard = CardDeck.First.Value;
            return drawnCard;
        }
    }
}
