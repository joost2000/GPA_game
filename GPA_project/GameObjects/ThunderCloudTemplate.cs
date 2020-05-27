using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA_project
{
    class ThunderCloudTemplate : SpriteGameObject
    {
        public ThunderCloudTemplate(Vector2 startPosition) : base("thundercloud")
        {
            position = startPosition;
            scale = 1.5f;
        }
    }
}
