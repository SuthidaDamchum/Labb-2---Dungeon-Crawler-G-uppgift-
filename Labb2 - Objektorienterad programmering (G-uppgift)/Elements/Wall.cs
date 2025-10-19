namespace Labb2___Objektorienterad_programmering__G_uppgift_.Modeller
{
    class Wall : LevelElement
    {
        public Wall(int x, int y) : base(x, y)
        {
            Symbol = '#';
            Color = ConsoleColor.White;
        }
    }
}
