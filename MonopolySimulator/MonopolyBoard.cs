using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolySimulator
{
    class MonopolyBoard
    {
        public Space[] Spaces = new Space[40];
        public Byte Length { get; set; }
        public MonopolyBoard (Space[] spaces)
        {
            Spaces = spaces;
            Length = (Byte)Spaces.Length;
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
            Spaces[21] = new Property("Kentucky Avenue", "Red", 220, 30);
            Spaces[22] = new Chance();
            Spaces[23] = new Property("Indiana Avenue", "Red", 220, 30);
            Spaces[24] = new Property("Illinois Avenue", "Red", 240, 32);
            Spaces[25] = new Property("B&O Railroad", "Black", 200, 25);
            Spaces[26] = new Property("Atlantic Avenue", "Yellow", 260, 26);
            Spaces[27] = new Property("Ventor Avenue", "Yellow", 260, 26);
            Spaces[28] = new Property("Water Works", "White", 150, 15);
            Spaces[29] = new Property("Marvin Gardens", "Yellow", 280, 28);
            Spaces[30] = new SpecialSpace("Go To Jail");
            Spaces[31] = new Property("Pacific Avenue", "Green", 300, 30);
            Spaces[32] = new Property("North Carolina Avenue", "Green", 300, 30);
            Spaces[33] = new CommunityChest();
            Spaces[34] = new Property("Pennsylvania Avenue", "Green", 320, 32);
            Spaces[35] = new Property("Short Line", "Black", 200, 25);
            Spaces[36] = new Chance();
            Spaces[37] = new Property("Park Place", "Dark Blue", 350, 35);
            Spaces[38] = new Tax("Special Tax", 100);
            Spaces[39] = new Property("Boardwalk", "Dark Blue", 400, 50);

            Length = (Byte)Spaces.Length;
        }
        

        public void AddPlayerToSpace(Player player)
        {
            // Add player to space
            Spaces[player.CurrentIndex].AddPlayerToSpace(player);
        }

        public void ReportPlayerPositions()
        {
            foreach (Space s in Spaces)
            {
                //if (s.PlayersOnSpace.Length > 0)
                //{
                //    Console.Write(s.Name);
                //    Console.Write(" : ");
                //    Console.WriteLine(s.ToString());
                //}
            }
        }

        public void RemovePlayerFromSpace(Player player)
        {
            
        }
    }
}
