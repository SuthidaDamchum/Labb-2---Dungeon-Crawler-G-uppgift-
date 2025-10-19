using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2___Objektorienterad_programmering__G_uppgift_;

namespace Labb2___Objektorienterad_programmering__G_uppgift_.Modeller;
class Rat : Enemy
{

    private static Random random = new Random();
    public Rat(int x, int y) : base(x, y)

    {
        Name = "The rat";
        HP = 10;
        AttackDice = new Dice(1, 6, 3); //1d6+3=> kasta 1 en täning ,med en 6 sidig träning resulat + 3 points
        DefenceDice = new Dice(1, 6, 1); // 
        Symbol = 'r';
        Color = ConsoleColor.DarkMagenta;

    }

    public override void Update(List<LevelElement> elements, Player player)
    {
        int dx = 0;
        int dy = 0;

        dx = random.Next(-1, 2); // max exclusive
        dy = random.Next(-1, 2);

        int newX = X + dx;  // NewX = nu position + ny position från slummäsig 
        int newY = Y + dy;

        foreach (var e in elements)
        {
            if (e.X == newX && e.Y == newY && (e is Wall || e is Enemy))
                return; //gör inget
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