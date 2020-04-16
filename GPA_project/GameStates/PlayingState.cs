using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GPA_project
{
    class PlayingState : GameObjectList
    {
        Background background;
        GameObjectList clouds;

        public PlayingState()
        {
            background = new Background();
            this.Add(background);

            clouds = new GameObjectList();
            this.Add(clouds);

            for (int i = 0; i < 12; i++)
            {
                this.clouds.Add(new Ground(new Vector2(100 + i * 80, GameEnvironment.Screen.Y - 100)));
            }
            Console.WriteLine(clouds.Children.Count);
        }
    }
}
