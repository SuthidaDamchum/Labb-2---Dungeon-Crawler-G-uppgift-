using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Labb2___Objektorienterad_programmering__G_uppgift_.Modeller;
using Labb2___Objektorienterad_programming__G_uppgift_;
namespace Labb2___Objektorienterad_programmering__G_uppgift_;

class GameLoop
{
    public GameLoop() { }

    private Random random = new Random();
    public void Run(LevelData levelData)
    {
        int count = 0;
        Console.Clear();
        var player = new Player(levelData.playerStart.X, levelData.playerStart.Y);

        while (true)
        {
            if (player.HP <= 0)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("YOU ARE SO DEAD > Game over!!");
                return;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Player : {player.Name} | Health: {player.HP} | Turn: {count}");
            count++;

            player.Draw();

            List<LevelElement> toBeRemoved = new List<LevelElement>();
            foreach (var obj in levelData.Elements)
            {
                if (player.DistanceTo(obj) <= 5)
                {

                    obj.Draw();          // synlig just nu
                    player.Discover(obj); // spara väggar


                }
                else if (obj is Wall && player.HasSeen(obj))
                {
                    obj.Draw();          // redan upptäckt vägg
                }
                if (obj is Enemy)
                {
                    var enemy = ((Enemy)obj);
                    enemy.Update(levelData.Elements, player);
                    if (!enemy.Alive)
                    {
                        toBeRemoved.Add(enemy);
                    }
                }
            }

            foreach (LevelElement levelElement in toBeRemoved)
            {
                levelData.Elements.Remove(levelElement);
            }
            ConsoleKey key = Console.ReadKey(true).Key;
            Console.Clear();

            int newX = player.X;
            int newY = player.Y;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    newY--;
                    break;
                case ConsoleKey.DownArrow:
                    newY++;
                    break;
                case ConsoleKey.LeftArrow:
                    newX--;
                    break;
                case ConsoleKey.RightArrow:
                    newX++;
                    break;
                case ConsoleKey.Escape:
                    return;
            }

            //Check if is other element on position
            LevelElement? foundElement = levelData.Elements.FirstOrDefault(e => e.X == newX && e.Y == newY);
            //Player not move
            if (foundElement != null) //Exist
            {
                if (foundElement is Enemy)
                {
                    Enemy enemy = (Enemy)foundElement; //Convert to known type
                    Console.SetCursorPosition(0, 1);
                    player.Attack(enemy);

                    Console.SetCursorPosition(0, 2);
                    enemy.Attack(player);

                    if (enemy.HP <= 0)
                        foundElement.Alive = false;
                }
            }
            else
            {
                //player move
                player.X = newX;
                player.Y = newY;
            }
        }
    }
}



