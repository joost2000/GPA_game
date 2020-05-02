using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GPA_project
{
    class PlayingState : GameObjectList
    {
        GameObjectList container;
        Platform platform1;
        Player player;

        int cloudTimer = 0;

        public PlayingState()
        {
            this.Add(new SpriteGameObject("sky_background"));

            container = new GameObjectList();
            this.Add(container);

            platform1 = new Platform(new Vector2(50, 640), 20);
            this.container.Add(platform1);

            player = new Player();
            this.Add(player);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            player.onGround = false;
            cloudTimer++;

            foreach (Platform item in container.Children.ToList())
            {
                foreach (CloudTemplate sprite in item.Children.ToList())
                {
                    if (sprite.GlobalPosition.X < 0 - sprite.Width)
                    {
                        item.Children.Remove(sprite);
                    }
                    if (item.Children.Count == 0)
                    {
                        container.Children.Remove(item);
                    }
                    if (sprite.CollidesWith(player))
                    {
                        player.onGround = true;
                    }
                }
            }

            if (cloudTimer >= 175 - (0.5f * (float)gameTime.TotalGameTime.TotalSeconds))
            {
                platform1 = new Platform(new Vector2(GameEnvironment.Screen.X, GameEnvironment.Random.Next(400, 600)), GameEnvironment.Random.Next(8, 12));
                container.Children.Add(platform1);
                cloudTimer = 0;
            }
            Console.WriteLine(-500f - (1f * (float)gameTime.TotalGameTime.TotalSeconds));
        }
    }
}
