using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolySimulator
{
    class GameController
    {
        LinkedList<Player> Players;
        MonopolyBoard Board;
        Dice GameDice;
        CommunityChestDeck CChestDeck;
        ChanceDeck CDeck;
        Player PlayerToMove;
        Space[] Spaces = new Space[40]; // Spaces will not change

        public void InitialRoll()
        {
            foreach(Player p in Players)
            {
                p.SpacesToMove = GameDice.Roll();
            }

            // Sort players list based on who rolled a greater amount
            Players = (LinkedList<Player>)Players.OrderByDescending(p => p.SpacesToMove);

        }

        public void PlayTurn()
        {
            PlayerToMove = Players.First.Value;
            PlayerToMove.SpacesToMove = GameDice.Roll();
            while (PlayerToMove.SpacesToMove > 0)
            {
                PlayerToMove.Move(); // Increase players index
                Board.AddPlayerToSpace(PlayerToMove); // Add player to list of players on that space
                CheckPosition(); // Check to space to see what is there
                // If side effect of space e.g. chance card - causes player to move again, 
                // loop. Else EndTurn();
            }

            EndTurn();
        }

        public void MoveCurrentPlayer(Byte spacesToMove)
        {
            PlayerToMove = Players.First.Value;
            PlayerToMove.Move(spacesToMove);
        }

        public void CheckPosition()
        {
            PlayerToMove = Players.First.Value;
            Space currentSpace = Spaces[PlayerToMove.CurrentIndex];
            if (currentSpace.SpaceType.Equals("Chance"))
                PlayerToMove.SpacesToMove = 4; // Draw card
            else if (currentSpace.SpaceType.Equals("CommunityChest"))
                PlayerToMove.SpacesToMove = 2;
            else if (currentSpace.SpaceType.Equals("Property"))
                PlayerToMove.SpacesToMove = 0; // Implement propery strategy? CheckIfBuy();
            

        }

        public void EndTurn()
        {
            // Move current player to the bottom of the players list
            Players.AddAfter(Players.Last, Players.First);
            Players.RemoveFirst();
        }
    }
}
