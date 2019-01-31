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
        public bool HasRolledDoubles { get; set; }
        public Byte TimesDoublesRolled { get; set; }
        public bool IsInJail { get; set; }
        public Byte TurnsInJail { get; set; }
        public bool HasRolledDoublesThreeTimes { get; set; }
        public bool TurnHasEnded { get; set; }
        public Byte InitialRollValue { get; set; }
        public int TurnsPlayed { get; set; }
        public List<Byte> RollsHistory = new List<byte>();
        
        public Player(String name)
        {
            PlayerName = name;
            TotalFunds = StartingFunds;
        }

        public void StartTurn()
        {
            this.TurnHasEnded = false;
            this.TurnsPlayed++;
            Console.Write("Starting Index: ");
            Console.WriteLine(this.CurrentIndex);
        }

        public void Move()
        {
            CurrentIndex += SpacesToMove;
        }

        public void Move(Byte spacesToMove, ref MonopolyBoard board)
        {
            this.CurrentIndex += spacesToMove;
            if (this.CurrentIndex >= board.Length)
            {
                this.CurrentIndex = GetPlayerIndexAtStartOfBoard(board);
            }

            this.CurrentSpace = board.Spaces[CurrentIndex];
            Console.WriteLine("Current index:");
            Console.WriteLine(this.CurrentIndex);
        }

        public Byte GetPlayerIndexAtStartOfBoard(MonopolyBoard board)
        {
            Byte result = (Byte)(this.CurrentIndex
                    - board.Length
                    + this.SpacesToMove);

            return result;
        }



        public void MoveIndex(Byte index)
        {
            CurrentIndex = index;
        }

        public Byte RollDice()
        {
            Dice GameDice1 = new Dice();
            Dice GameDice2 = new Dice();
            Byte roll1 = GameDice1.Roll();
            Byte roll2 = GameDice2.Roll();

            //RollsHistory.Add(roll1);
            //RollsHistory.Add(roll2);
            
            Console.Write("Rolled ");
            Console.Write(roll1);
            Console.Write(" and ");
            Console.Write(roll2);
            Console.Write(" Result: ");
            Console.WriteLine((Byte)(roll1 + roll2));
            if (roll1 == roll2)
            {
                Console.WriteLine("DOUBLES!");
                this.HasRolledDoubles = true;
            }

            return (Byte)(roll1 + roll2);
        }

        public void CheckPosition(MonopolyBoard board)
        {
            Space currentSpace = board.Spaces[this.CurrentIndex];
//            board.AddPlayerToSpace(this);
            //if (currentSpace.SpaceType.Equals("Chance"))
            //    this.Move(4, board); // Draw card
            //else if (currentSpace.SpaceType.Equals("CommunityChest"))
            //    this.Move(2, board);
            //else if (currentSpace.SpaceType.Equals("Property"))
            //{
            //    this.Move(0, board);
            //    this.PayMoney(currentSpace.RentPrice);
            //}
            //// Implement propery strategy? CheckIfBuy();
            //else if (currentSpace.SpaceType.Equals("Tax"))
            //    this.Move(0, board);
            if (currentSpace.SpaceType.Equals("Go To Jail"))
            {
                this.MoveIndex(10);
                this.IsInJail = true;
            }

            board.AddPlayerToSpace(this);
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

        public bool AllowPlayerToMoveFromJail()
        {
            bool result;
            if (this.IsInJail
                    && this.TurnsInJail < 3
                    && !this.HasRolledDoubles)
                result = false;
            else
                result = true;
            return result;

        }

        public void EndTurn()
        {
            Console.WriteLine(this.GetSummary());
            this.HasRolledDoubles = false;
            this.SpacesToMove = 0;
            this.TurnHasEnded = true;
        }

        public override string ToString()
        {
            return this.PlayerName;
        }
    }
}
