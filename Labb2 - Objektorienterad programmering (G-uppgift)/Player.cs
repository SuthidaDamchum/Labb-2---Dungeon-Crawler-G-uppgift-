using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Dynamic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Labb2___Objektorienterad_programmering__G_uppgift_;
using Labb2___Objektorienterad_programmering__G_uppgift_.Modeller;

namespace Labb2___Objektorienterad_programmering__G_uppgift_
{

    class Player : LevelElement
    {
        private Player player;
        public int PlayerStartX { get; private set; }
        public int PlayerStartY { get; private set; }
        public string Name { get; set; }
        public int HP { get; set; }

        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }

        public Player(int x, int y) : base(x, y)
        {
            PlayerStartX = x;
            PlayerStartY = y;
            Name = "Suthida";
            AttackDice = new Dice(2, 6, 2);
            DefenceDice = new Dice(2, 6, 0); // 2 tärningar , sidor, bonus
            HP = 100;
        }
        public override void Draw()
        {
            if (!Alive) return;
            int offsetX = 0;
            int offsetY = 4;
            Console.SetCursorPosition(X + offsetX, Y + offsetY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('@');
        }

        public List<(int x, int y)> discoveredWalls = new List<(int x, int y)>();

        public double DistanceTo(LevelElement obj)
        {
            return Math.Sqrt(Math.Pow(obj.X - this.X, 2) + Math.Pow(obj.Y - this.Y, 2));
        }

        public void Discover(LevelElement obj)
        {
            if (obj is Wall wall)
            {
                var position = (wall.X, wall.Y);
                if (!discoveredWalls.Contains(position))
                    discoveredWalls.Add(position);
            }
        }
        public bool HasSeen(LevelElement obj)
        {
            if (obj is Wall wall)
                return discoveredWalls.Contains((wall.X, wall.Y));
            return false;
        }

        public void Attack(Enemy enemy)
        {
            if (!Alive) return;
            int attackFromPlayer = this.AttackDice.Throw();
            int defenseFromEnemy = enemy.DefenceDice.Throw();
            int damage = Math.Max(0, attackFromPlayer - defenseFromEnemy);

            enemy.HP = enemy.HP - damage;

            if (enemy.HP <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green; ;
                Console.WriteLine($"You attacked (ATT: {this.AttackDice} => {attackFromPlayer}) {enemy.Name} (DEF: {enemy.DefenceDice} => {defenseFromEnemy}) and dealt damage, killing it!");
            }
            else if (damage == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You attacked (ATT: {this.AttackDice} => {attackFromPlayer}) {enemy.Name} (DEF: {enemy.DefenceDice} => {defenseFromEnemy}) and dealt no damage!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You attacked (ATT: {this.AttackDice} => {attackFromPlayer}) {enemy.Name} (DEF: {enemy.DefenceDice} => {defenseFromEnemy}) and dealt damage!");
            }

            Console.ResetColor();
        }
    }

}




