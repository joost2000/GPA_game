using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA_project
{
    class testEnvironment : GameObjectList
    {
        AnimatedGameObject anims;
        public testEnvironment()
        {
            anims = new AnimatedGameObject();

            anims.LoadAnimation("RunAnimFemale@3", "runAnim", true, 0.15f);

            anims.Position = new Vector2(400,400);

            this.Add(anims);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            anims.PlayAnimation("runAnim");
        }
    }
}
