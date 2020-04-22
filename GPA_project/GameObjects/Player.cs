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
        bool hasJumped;

        public Player() : base("filler_player")
        {
            origin = Center;
            scale = 0.05f;
            position = new Vector2(100, 570);
            hasJumped = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Console.WriteLine(velocity.Y);

            if (hasJumped)
            {
                velocity.Y = -800;
            }

            if (position.Y < 500)
            {
                hasJumped = false;
                velocity.Y += 80;
            }

            if (position.Y > 570)
            {
                velocity.Y = 0;
            }
        }


        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space) && !hasJumped)
            {
                hasJumped = true;
            }
        }
    }
}