using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Labb2___Objektorienterad_programmering__G_uppgift_;

namespace Labb2___Objektorienterad_programmering__G_uppgift_.Modeller
{
    class Snake : Enemy
    {
     
        public Snake(int x, int y) : base(x, y)
        {
            HP = 25;
            AttackDice = new Dice(3, 4, 2); //3d4+2=>kasta 3 gg,med 4 sidig-träning resulat visa + 2 points
            DefenceDice = new Dice(1, 8, 5); //1 tärning, 8 sidor, result +5
            Color = ConsoleColor.Red;
            Name = "The snake";
            Symbol = 's';
        }

        public override void Update(List<LevelElement> elements, Player player)
        {
            int dx = 0;
            int dy = 0;

            if (player.DistanceTo(this) > 2) return;

            if (player.X > X) dx = -1;
            else if (player.X < X) dx = 1;
            if (player.Y > Y) dy = -1;
            else if (player.Y < Y) dy = 1;


            int newX = X + dx;
            int newY = Y + dy;

            foreach (var e in elements)
            {
                if (e.X == newX && e.Y == newY && (e is Wall || e is Enemy))
                    return; // stoppad
            }

            if (player.X == newX && player.Y == newY)
            {
                Console.SetCursorPosition(0, 1);
                Attack(player);
                Console.SetCursorPosition(0, 2);
                player.Attack(this);

                if (HP <= 0)
                    Alive = false;
                return;
            }

            X = newX;
            Y = newY;


        }
    }
}

