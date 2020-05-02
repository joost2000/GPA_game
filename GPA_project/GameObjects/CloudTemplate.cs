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
        public CloudTemplate(Vector2 startPosition) : base("cloud_18")
        {
            position = startPosition;
            scale = 1.5f;
        }

        public void ChangeCloudY()
        {
            position.Y = GameEnvironment.Random.Next(300,600);
        }
        public void ResetPosX()
        {
            position.X = 500;
        }
    }
}
