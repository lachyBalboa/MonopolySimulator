using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolySimulator
{
    class GameController
    {
        LinkedList<Player> Players = new LinkedList<Player>();
        MonopolyBoard Board = new MonopolyBoard();
        Dice GameDice = new Dice();
        CommunityChestDeck CommunityChestDeck = new CommunityChestDeck();
        ChanceDeck ChanceDeck = new ChanceDeck();
        Player PlayerToMove;
        Space[] Spaces = new Space[40]; // Spaces will not change

        public GameController(LinkedList<Player> players)
        {
            Players = players;
        }
        public void InitialRoll()
        {   
            foreach(Player p in Players)
            {
                p.SpacesToMove = GameDice.Roll();
                Console.Write(p);
                Console.Write("'s initial roll is: ");
                Console.WriteLine(GameDice.CurrentValue);
            }

            // Sort players list based on who rolled a greater amount
            IOrderedEnumerable<Player> tempPlayers = Players.OrderByDescending(p => p.SpacesToMove);
            Players = new LinkedList<Player>(tempPlayers);
            Console.Write(Players.First.Value.PlayerName);
            Console.WriteLine(" gets to move first.");

        }

        public void PlayTurn()
        {
            PlayerToMove = Players.First.Value;
            Console.Write(PlayerToMove.PlayerName);
            Console.WriteLine(" is rolling ...");

            PlayerToMove.SpacesToMove = GameDice.Roll();
            Console.Write("Rolled ");
            Console.WriteLine(GameDice.CurrentValue);
            Console.WriteLine("Moving " + PlayerToMove.SpacesToMove + " spaces.");
            PlayerToMove.Move(); // Increase players index
            while (PlayerToMove.SpacesToMove > 0)
            {

                Board.AddPlayerToSpace(PlayerToMove); // Add player to list of players on that space
                PlayerToMove.CurrentSpace = GetSpaceForPlayer(PlayerToMove);

                Console.Write(PlayerToMove.PlayerName);
                Console.Write(" landed on: ");
                Console.WriteLine(PlayerToMove.CurrentSpace.ToString());

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
            Space currentSpace = Board.Spaces[PlayerToMove.CurrentIndex];
            Byte spacesToMove = 0;
            String spaceDetails;

            if (currentSpace.SpaceType.Equals("Chance"))
                spacesToMove = 4; // Draw card
            else if (currentSpace.SpaceType.Equals("CommunityChest"))
                spacesToMove = 2;
            else if (currentSpace.SpaceType.Equals("Property"))
                spacesToMove = 0; // Implement propery strategy? CheckIfBuy();
            else if (currentSpace.SpaceType.Equals("Tax"))
                spacesToMove = 0;

            spaceDetails = currentSpace.ToString();
            Console.Write(PlayerToMove.PlayerName);
            Console.Write(" landed on: ");
            Console.Write(currentSpace.SpaceType);
            Console.Write(" and will move ");
            Console.Write(spacesToMove);
            Console.WriteLine(" spaces.");
            PlayerToMove.SpacesToMove = spacesToMove;
        }

        public Space GetSpaceForPlayer(Player player)
        {
            Space currentSpace = Board.Spaces[player.CurrentIndex];
            return currentSpace;
        }

        public void EndTurn()
        {
            // Move current player to the bottom of the players list
            Console.WriteLine("Ending turn for Kate");
            Console.WriteLine("Summary: ");
            Console.WriteLine(Players.First.Value.GetSummary());
            Players.RemoveFirst();
            Players.AddAfter(Players.Last, PlayerToMove);        
            Console.WriteLine(Players.First.Value.PlayerName);

        }
    }
}
