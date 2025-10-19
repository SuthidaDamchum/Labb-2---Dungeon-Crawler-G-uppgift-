using Labb2___Objektorienterad_programmering__G_uppgift_.Modeller;
using Labb2___Objektorienterad_programming__G_uppgift_;

namespace Labb2___Objektorienterad_programmering__G_uppgift_
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.CursorVisible = false;
            var levelData = new LevelData();
            levelData.Load(@"Levels\Level1.txt");

            var gameLoop = new GameLoop();
            gameLoop.Run(levelData);

        }
    }

}