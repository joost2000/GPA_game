using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GPA_project
{
    class Background : SpriteGameObject
    {
        public Background() : base ("sky1")
        {
            this.position = new Vector2(GameEnvironment.Screen.X/2, GameEnvironment.Screen.Y/2);
            origin = Center;
            scale = 0.6f;
        }
    }
}
