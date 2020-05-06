using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA_project
{
    public class CloudTemplate : SpriteGameObject
    {
        //Load in cloud sprite to prevent duplicate code
        public CloudTemplate(Vector2 startPosition) : base("Cloud")
        {
            position = startPosition;
            scale = 1.5f;
        }
    }
}
