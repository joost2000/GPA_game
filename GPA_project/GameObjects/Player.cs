using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GPA_project
{
    class Player : SpriteGameObject
    {
        public bool onGround, keyPressed;
        int jumpTimer = 0;

        public Player() : base("filler_player")
        {
            origin = Center;
            position = new Vector2(100, 470);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (onGround)
            {
                velocity.Y = 0;
                jumpTimer = 0;
                keyPressed = false;
            }
            else
            {
                velocity.Y += 18;
            }

        }


        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space))
            {
                keyPressed = true;
            }

            if (inputHelper.IsKeyDown(Keys.Space) && !keyPressed)
            {
                if (!(jumpTimer > 25))
                {
                    jumpTimer++;
                    velocity.Y = -200;
                    velocity.Y += -400f;
                }
            }
        }
    }
}