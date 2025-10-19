using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2___Objektorienterad_programmering__G_uppgift_;

namespace Labb2___Objektorienterad_programmering__G_uppgift_
{
    class  Dice
    {
        private int numberOfDice;
        private int sidesPerDice;
        private int modifier;
        private static Random kasta = new Random();

        public Dice(int numberOfDice,int sidesPerDice, int modifier)
        {
            this.numberOfDice = numberOfDice;
            this.sidesPerDice = sidesPerDice;
            this.modifier = modifier;
        }

        public override string ToString()
        { 
             
            if (modifier != 0)
                return $"{numberOfDice}d{sidesPerDice}+{modifier}";
            else
                return $"{numberOfDice}d{sidesPerDice}";
        
        }
        public int Throw()
        {
            int total = 0;

            for (int i = 0; i < numberOfDice; i++)
            {
                total = total + kasta.Next(1, +sidesPerDice +1 );
            }
            return total + modifier;
        }

    }


}


