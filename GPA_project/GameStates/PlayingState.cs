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
        Platform platform2;
        Player player;

        bool addNewclouds;

        public PlayingState()
        {
            this.Add(new SpriteGameObject("sky_background"));

            container = new GameObjectList();
            this.Add(container);

            platform1 = new Platform(new Vector2(50, 640));
            this.container.Add(platform1);

            player = new Player();
            this.Add(player);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            platform1.moveObject = true;
            player.onGround = false;
            /*
            player.onGround = false;
            foreach (SpriteGameObject item in platform.Children.ToList())
            {
                if(item.CollidesWith(player)){
                    player.onGround = true;
                }
                if (item.Position.X < 0 - item.Sprite.Width)
                {
                    platform.Remove(item);
                    
                }
                Console.WriteLine(platform.Children.Count());
            }*/

            /*if (platform.Children.Count != 10)
            {
                platform.createNewY = true;
                platform.AddClouds();
            }*/
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
                Console.WriteLine(container.Children.Count);
                if (container.Children.Count == 0)
                {
                    platform1 = new Platform(new Vector2(1100,GameEnvironment.Random.Next(400,600)));
                    container.Children.Add(platform1);
                }
            }
        }
    }
}
