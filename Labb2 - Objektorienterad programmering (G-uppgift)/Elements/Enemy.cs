using System;

namespace Labb2___Objektorienterad_programmering__G_uppgift_.Modeller
{
    abstract class Enemy : LevelElement
    {

        public Enemy(int x, int y) : base(x, y) { }
        public string Name { get; set; }
        public int HP { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }
        public bool Alive { get; set; } = true;

        public abstract void Update(List<LevelElement> elements, Player player);


        public void Attack(Player player)
        {
            if (!Alive) return;

            int attackFromEnemy = this.AttackDice.Throw();
            int defenseFromPlayer = player.DefenceDice.Throw();
            int damage = Math.Max(0, attackFromEnemy - defenseFromPlayer);

            player.HP = player.HP - damage;

            if (player.HP <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Name} (ATA: {this.AttackDice} => {attackFromEnemy}) attacked you (DEF: {player.DefenceDice} => {defenseFromPlayer}) and dealt damage, killing you!");

            }
            else if (0 == damage)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Name} (ATT: {this.AttackDice} => {attackFromEnemy}) attacked you (DEF: {player.DefenceDice} => {defenseFromPlayer}) but dealt no damage!");
                
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Name} (ATT: {this.AttackDice} => {attackFromEnemy}) attacked you (DEF: {player.DefenceDice} => {defenseFromPlayer}) and dealt damage!");
            }

            Console.ResetColor();
        }
    }
}







