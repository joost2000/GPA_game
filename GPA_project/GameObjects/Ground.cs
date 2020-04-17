using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GPA_project
{
    class Ground : SpriteGameObject
    {
        public Ground(Vector2 startPosition) : base("Cloud_18")
        {
            origin = Center;
            position = startPosition;
            scale = 2f;
        }

        public void MoveGround()
        {
            position.X -= 10;
        }

        public void ResetCloud()
        {
            if (position.X <= -100)
            {
                position.X = GameEnvironment.Screen.X + 600;
            }
        }
    }
}
