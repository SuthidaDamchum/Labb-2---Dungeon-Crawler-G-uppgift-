using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Labb2___Objektorienterad_programmering__G_uppgift_.Modeller;
namespace Labb2___Objektorienterad_programming__G_uppgift_
{
    class LevelData
    {
        private List<LevelElement> elements = new List<LevelElement>();

        public List<LevelElement> Elements
        {
            get

            {
                return elements;
            }

        }
        public Point playerStart;

        public void Load(string filename)
        {
            elements.Clear();

            int y = 0;
            foreach (string line in File.ReadAllLines(filename))
            {
                int x = 0;
                foreach (char c in line)
                {
                    if (c == '#') elements.Add(new Wall(x, y));
                    else if (c == 'r') elements.Add(new Rat(x, y));
                    else if (c == 's') elements.Add(new Snake(x, y));
                    else if (c == '@') playerStart = new Point(x, y);
                    x++;
                }

                y++;
            }
        }
    }
}
