using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolySimulator
{
    class MonopolyBoard
    {
        public Space[] Spaces = new Space[40];
        public MonopolyBoard (Space[] spaces)
        {
            
            Spaces = spaces;
        }
        public MonopolyBoard()
        {
            // Rent prices need adjustment
            Spaces[0] = new SpecialSpace("Go");
            Spaces[1] = new Property("Old Kent Road", "Brown", 60, 2);
            Spaces[2] = new CommunityChest();
            Spaces[3] = new Property("Whitechapel Road", "Brown",60, 4);
            Spaces[4] = new Tax("Income Tax", 200);
            Spaces[5] = new Property("Redding Railroad", "Black", 200, 25);
            Spaces[6] = new Property("Oriental Avenue", "Light Blue", 160, 10);
            Spaces[7] = new Chance();
            Spaces[8] = new Property("Vermont Avenue", "Light Blue", 160, 10);
            Spaces[9] = new Property("Conneticut Avenue", "Light Blue", 180, 12);
            Spaces[10] = new SpecialSpace("Jail");
            Spaces[11] = new Property("St. Charles Place", "Purple", 140, 15);
            Spaces[12] = new Property("Electric Company", "White", 140, 10); // Add class for utilities
            Spaces[13] = new Property("States Avenue", "Purple", 150, 10);
            Spaces[14] = new Property("Virginia Avenue", "Purple", 160, 20);
            Spaces[15] = new Property("Pennsylvania Railroad", "Black", 200, 25); // Add class for railways
            Spaces[16] = new Property("St. James Place", "Orange", 180, 20);
            Spaces[17] = new CommunityChest();
            Spaces[18] = new Property("Tennessee Avenue", "Orange", 180, 20);
            Spaces[19] = new Property("New York Avenue", "Orange", 200, 22);
            Spaces[20] = new SpecialSpace("Free Parking");
         }

        public void AddPlayerToSpace(Player player)
        {
            // Add player to space
            Spaces[player.CurrentIndex].AddPlayerToSpace(player);
            Console.Write("Players on space: ");
            Console.WriteLine(Spaces[player.CurrentIndex].Name);
            foreach(Player p in Spaces[player.CurrentIndex].PlayersOnSpace)
            {
                Console.WriteLine("\t - " + p);
            }
        }

        public void RemovePlayerFromSpace(Player player)
        {
            
        }
    }
}
