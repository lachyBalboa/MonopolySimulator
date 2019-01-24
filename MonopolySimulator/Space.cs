using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolySimulator
{
    class Space
    {
        public String Name { get; set; }
        //public Byte BoardIndex { get; set; }
        public int TimesLanded = 0;
        public String SpaceType;
        public List<Player> PlayersOnSpace = new List<Player>();
        public short RentPrice { get; set; }
        public Space (string name)
        {
            Name = name;
            //BoardIndex = boardIndex;
        }

        public void AddPlayerToSpace(Player player)
        {
            PlayersOnSpace.Add(player);
            TimesLanded++;

        }

        public void RemovePlayerFromSpace(Player player)
        {
            PlayersOnSpace.Remove(player);
        }

        public override string ToString()
        {
            // expand ToString to include detailed space info.
            return this.Name;
        }


    }

    class Property : Space
    {
        String Color { get; set; } // define or use prebuilt color type?
        short PurchasePrice { get; set; }
        //public short RentPrice { get; set; }
        
        public Property (String name, String color, short purchasePrice, short rentPrice)
            : base(name)
        {
            base.Name = name;
            Color = color;
            PurchasePrice = purchasePrice;
            RentPrice = rentPrice;
            SpaceType = "Property";
        }
    }

    class Chance : Space
    {
        public Chance(String name = "Chance") : base (name)
        {
            base.Name = name;
            SpaceType = "Chance";
        }
    }

    class CommunityChest : Space
    {
        public CommunityChest(String name = "Community Chest") : base (name)
        {
            base.Name = name;
            SpaceType = "CommunityChest";
        }
    }
    class Tax : Space
    {
        public int Price { get; set; }
        public Tax(String name, int price) : base(name)
        {
            base.Name = name;
            Price = price;
            SpaceType = "Tax";
        }
    }

    class SpecialSpace : Space
    {
        public SpecialSpace (String name) : base(name)
        {
            base.Name = name;
            SpaceType = "SpecialSpace";
        }
    }

    public enum SpecialSpaces
    {
        Go,
        Jail,
        FreeParking,
        GoToJail


    }

}
