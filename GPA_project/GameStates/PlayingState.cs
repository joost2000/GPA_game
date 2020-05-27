using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GPA_project
{
    class PlayingState : GameObjectList
    {
        GameObjectList container;
        Platform platform;
        Player player;

        int cloudTimer;
        float timerTarget, currentTime;
        public static float secondsWhenEntered;
        bool getTime = false;
        public static bool onFallingPlatform;

        public PlayingState()
        {
            Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //start the cloud timer
            cloudTimer++;

            //player is always off the ground unless there is collision
            player.onGround = false;
            onFallingPlatform = false;

            //set the secondswhenenetered to the current gametime so that we can access this in the gameover gamestate
            if (!getTime)
            {
                secondsWhenEntered = (float)gameTime.TotalGameTime.TotalSeconds;
                getTime = true;
            }

            //check for collision between the player and the platform
            //if the platform has a paltformtype higher than 10 let the platform drop and set the player's y position equal to it to prevent buggy jumping
            foreach (Platform item in container.Children.ToList())
            {
                foreach (SpriteGameObject sprite in item.Children.ToList())
                {
                    if (player.CollidesWith(sprite))
                    {
                        if (item.platformType > 10)
                        {
                            item.Velocity = new Vector2(item.Velocity.X,150);
                            player.Velocity = new Vector2(0, 150);
                        }
                        player.onGround = true;
                    }

                    //remove clouds sprites from platform when they exit the screen
                    if (sprite.GlobalPosition.X < -50 - sprite.Width)
                    {
                        item.Children.Remove(sprite);
                    }

                    //remove the platform when it has no cloud sprites left
                    if (item.Children.Count == 0)
                    {
                        container.Children.Remove(item);
                    }
                }
            }

            //set the current gametime to 0;
            currentTime = (float)gameTime.TotalGameTime.TotalSeconds - GetTime();

            //dont allow the timertarget to go below 80
            //gradually lower the timertarget based on the amount of seconds played
            if (timerTarget >= 80f)
            {
                timerTarget = 150f - (1.4f * currentTime);
            }

            //check if the cloud timer is greater or equal to the timertarget
            //if this is true, add a new platform to the gameobject list and reset the cloudtimer
            if (cloudTimer >= timerTarget)
            {
                platform = new Platform(new Vector2(GameEnvironment.Screen.X, GameEnvironment.Random.Next(300, 600)), GameEnvironment.Random.Next(8, 12), GameEnvironment.Random.Next(14));
                container.Children.Add(platform);
                cloudTimer = 0;
            }

            //if the player goes below the screen reset the playing state and put the player in the gameover state
            if (player.GlobalPosition.Y > GameEnvironment.Screen.Y)
            {
                container.Children.Clear();
                Reset();
                player.Reset();
                platform.Reset();
                GameEnvironment.GameStateManager.SwitchTo("GameOverState");
            }
        }

        //reset method for the playingstate
        public override void Reset()
        {
            base.Reset();
            this.Add(new SpriteGameObject("Background"));

            container = new GameObjectList();
            this.Add(container);

            platform = new Platform(new Vector2(-100, 350), 20, 0);
            this.container.Add(platform);

            player = new Player();
            this.Add(player);

            cloudTimer = 0;
            timerTarget = 150;

            getTime = false;

            platform.Velocity = new Vector2(-500f, 0);
        }

        //static method to allow other classes to get the amount of time that was spent before getting into the playingstate
        public static float GetTime()
        {
            return secondsWhenEntered;
        }
    }
}
