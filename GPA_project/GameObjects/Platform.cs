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
        public bool createNewY = false, moveObject = false;
        float currentTime;
        public int platformType;

        public Platform(Vector2 _pos, float platformSize, int _platformType)
        {
            //platform type defines if the platform is going to fall down or not
            platformType = _platformType;

            //add clouds to this list
            for (int i = 0; i < platformSize; i++)
            {
                Add(new CloudTemplate(new Vector2(_pos.X + i * 80, _pos.Y)));
            }
        }

        public override void Update(GameTime gameTime)
        {
            //set the current time to 0 by getting the amount of time spent from the playing state
            currentTime = (float)gameTime.TotalGameTime.TotalSeconds - PlayingState.GetTime();
            base.Update(gameTime);

            //gradually let the X velocity increase by multiplying it with the amount of time currently played
            if (velocity.X > -1000f)
            {
                velocity.X = -500f - (10f * currentTime);
            }
            else
            {
                velocity.X = -1000f;
            }
        }

        public override void Reset()
        {
            base.Reset();
            velocity.X = -500f;
        }

        //method for lowering down the cloud
        public void DropCloud()
        {
            velocity.Y = 10;
        }
    }
}
