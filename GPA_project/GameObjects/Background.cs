using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA_project
{
    class Background : SpriteGameObject
    {
        public Background() : base ("background", 10)
        {
            scale = 1.5f;
        }
    }
}
