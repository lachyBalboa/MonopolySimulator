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
        Dice GameDice1 = new Dice();
        Dice GameDice2 = new Dice();
        CommunityChestDeck CommunityChestDeck = new CommunityChestDeck();
        ChanceDeck ChanceDeck = new ChanceDeck();
        Player PlayerToMove;
        Space[] Spaces = new Space[40]; // Spaces will not change
        public bool GameIsOn = true;
        const Byte JailIndex = 10;
        bool DoublesRolled;
        bool DoublesRolledThreeTimes;
        public GameController(LinkedList<Player> players)
        {
            Players = players;
        }
        public void InitialRoll()
        {   
            foreach(Player p in Players)
            {
                p.SpacesToMove = GameDice1.Roll();
                Console.Write(p);
                Console.Write("'s initial roll is: ");
                Console.WriteLine(GameDice1.CurrentValue);
            }

            // Sort players list based on who rolled a greater amount
            IOrderedEnumerable<Player> tempPlayers = Players.OrderByDescending(p => p.SpacesToMove);
            Players = new LinkedList<Player>(tempPlayers);
            Console.Write(Players.First.Value.PlayerName);
            Console.WriteLine(" gets to move first.");

        }

        public void RollBothDice()
        {
            Byte roll1 = GameDice1.Roll();
            Byte roll2 = GameDice2.Roll();
            Console.Write("Rolled ");
            Console.Write(roll1);
            Console.Write(" and ");
            Console.Write(roll2);
            PlayerToMove.SpacesToMove += (Byte)(roll1 + roll2);
            if (roll1 == roll2)
            {
                DoublesRolled = true;

            }
        }

        public void PlayTurn()
        {
            PlayerToMove = Players.First.Value;
            Console.Write(PlayerToMove.PlayerName);
            Console.WriteLine(" is rolling ...");

            RollBothDice();

            Console.WriteLine("Moving " + PlayerToMove.SpacesToMove + " spaces. \n");
            PlayerToMove.Move(); // Increase players index
            while (PlayerToMove.SpacesToMove > 0 || DoublesRolled == true)
            {
                if (DoublesRolledThreeTimes)
                {
                    PlayerToMove.MoveIndex(JailIndex); // Go to jail if doubles rolled three times. End turn.
                    break;
                }
                //Board.AddPlayerToSpace(PlayerToMove); // Add player to list of players on that space
                PlayerToMove.CurrentSpace = GetSpaceForPlayer(PlayerToMove);

                Console.Write(PlayerToMove.PlayerName);
                Console.Write(" landed on: ");
                Console.WriteLine(PlayerToMove.CurrentSpace.ToString());

                CheckPosition(); // Check to space to see what is there
                Console.WriteLine("Moving " + PlayerToMove.SpacesToMove + " spaces.");
                PlayerToMove.Move(); // Increase players index
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
            {
                spacesToMove = 0;
                PlayerToMove.PayMoney(currentSpace.RentPrice);
            }
            // Implement propery strategy? CheckIfBuy();
            else if (currentSpace.SpaceType.Equals("Tax"))
                spacesToMove = 0;

            spaceDetails = currentSpace.ToString();
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
            Console.Write("Ending turn for");
            Console.WriteLine(PlayerToMove);
            Console.WriteLine("Summary: ");
            Console.WriteLine(Players.First.Value.GetSummary());
            Players.RemoveFirst();
            Players.AddAfter(Players.Last, PlayerToMove);        

        }
    }
}
