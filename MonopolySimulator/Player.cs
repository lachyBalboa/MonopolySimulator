using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolySimulator
{
    class Player
    {
        public String PlayerName { get; set; }
        public Byte SpacesToMove { get; set; }
        public Byte CurrentIndex { get; set; }
        public int TotalFunds { get; set; }
        public Space CurrentSpace { get; set; }
        const int StartingFunds = 1500;
        public Player(String name)
        {
            PlayerName = name;
            TotalFunds = StartingFunds;
        }

        public void Move()
        {
            // How to handle modular value? Only 40 spaces then back to 1
            CurrentIndex += SpacesToMove;
        }

        public void Move(Byte SpacesToMove)
        {
            CurrentIndex += SpacesToMove;
        }

        public void MoveIndex(Byte index)
        {
            CurrentIndex = index;
        }

        public String GetSummary()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.PlayerName);
            builder.Append(" is on ");
            builder.Append(this.CurrentSpace.Name);
            builder.Append(" at index ");
            builder.Append(this.CurrentIndex);
            builder.Append("\n");
            builder.Append("Current Money: ");
            builder.Append(this.TotalFunds);
            builder.Append("\n");
            return builder.ToString();
        }

        public void PayMoney(int amountToPay)
        {
            this.TotalFunds = this.TotalFunds - amountToPay;
        }

        public override string ToString()
        {
            return this.PlayerName;
        }
    }
}
