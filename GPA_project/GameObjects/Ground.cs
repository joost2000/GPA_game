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
        public Ground(Vector2 startPosition) : base("Cloud_18", 1)
        {
            origin = Center;
            position = startPosition;
            scale = 2f;
        }
    }
}
