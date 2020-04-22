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
        Background background;
        GameObjectList platforms;
        Player player;

        public PlayingState()
        {
            background = new Background();
            this.Add(background);

            platforms = new GameObjectList();
            this.Add(platforms);

            for (int i = 0; i < GameEnvironment.Random.Next(8,12); i++)
            {
                this.platforms.Add(new Ground(new Vector2(100 + i * 80, GameEnvironment.Screen.Y - 100)));
            }
            player = new Player();
            this.Add(player);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (Ground cloud in this.platforms.Children)
            {
                //cloud.MoveGround();
                cloud.ResetCloud();
            }
        }
    }
}
