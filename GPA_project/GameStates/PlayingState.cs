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
        GameObjectList clouds;
        Player player;

        public PlayingState()
        {
            background = new Background();
            this.Add(background);

            clouds = new GameObjectList();
            this.Add(clouds);

            for (int i = 0; i < GameEnvironment.Random.Next(8,12); i++)
            {
                this.clouds.Add(new Ground(new Vector2(100 + i * 80, GameEnvironment.Screen.Y - 100)));
            }
            player = new Player();
            this.Add(player);
            player.LoadAnimation("runAnim", "RunningAnim", true);
            player.PlayAnimation("RunningAnim");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (Ground cloud in clouds.Children)
            {
                cloud.MoveGround();
                cloud.ResetCloud();
            }
        }
    }
}
