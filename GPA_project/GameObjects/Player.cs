using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GPA_project
{
    class Player : AnimatedGameObject
    {
        public bool onGround, keyPressed;
        int jumpTimer = 0;

        private string selectedCharacter;
        private bool notLoaded = true;

        public Player()
        {
            Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            selectedCharacter = CharacterSelectState.getSelectedCharacter();

            if (notLoaded)
            {
                LoadAnimation(selectedCharacter + "Run@3", "runningAnim", true, 0.15f);
                LoadAnimation(selectedCharacter + "Jump", "jumpAnim", false, 0.15f);
                LoadAnimation(selectedCharacter + "Land", "landAnim", false, 0.15f);
                notLoaded = false;
            }

            //play the loaded animations when player is on a platform
            //if player is not on a platform display the jumping/landing animation
            if (onGround)
            {
                PlayAnimation("runningAnim");
                velocity.Y = 0;
                jumpTimer = 0;
                keyPressed = false;
            }
            else
            {
                if (velocity.Y < 0)
                {
                    PlayAnimation("jumpAnim");
                }
                else
                {
                    PlayAnimation("landAnim");
                }
                //pull the player down
                velocity.Y += 20;
            }

            //move the player into the screen in the playing intro
            if (position.X < 100)
            {
                position.X += 2;
            }

        }

        public override void Reset()
        {
            base.Reset();
            PerPixelCollisionDetection = false;
            position = new Vector2(-100, 300);
            velocity = Vector2.Zero;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            //if the player presses enter, jump
            //if the player has jumped before, dont allow another jump before the timer runs out
            if (inputHelper.KeyPressed(Keys.Space))
            {
                keyPressed = true;
            }

            if (inputHelper.IsKeyDown(Keys.Space) && !keyPressed)
            {
                onGround = false;
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