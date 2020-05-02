using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GPA_project
{ 
    class Platform : GameObjectList
    {
        int newY;
        public bool createNewY = false, moveObject = false;

        public Platform(Vector2 _pos, float platformSize)
        {
            for (int i = 0; i < platformSize; i++)
            {
                Add(new CloudTemplate(new Vector2(_pos.X + i * 80, _pos.Y)));
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (CloudTemplate item in this.children)
            {
                velocity.X = -500f - (1f * (float)gameTime.TotalGameTime.TotalSeconds);
            }

        }

        public void AddClouds()
        {
        }
    }
}
