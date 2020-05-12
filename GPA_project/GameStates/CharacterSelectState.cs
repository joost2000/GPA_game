using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GPA_project
{
    class CharacterSelectState : GameObjectList
    {
        SpriteGameObject background;

        TextGameObject Text;

        GameObjectList characterSprites;

        AnimatedGameObject RobotAnim;
        AnimatedGameObject ZombieAnim;
        AnimatedGameObject MaleAdvAnim;
        AnimatedGameObject FemaleAdvAnim;

        int Selector;

        public CharacterSelectState()
        {
            RobotAnim = new AnimatedGameObject();
            ZombieAnim = new AnimatedGameObject();
            MaleAdvAnim = new AnimatedGameObject();
            FemaleAdvAnim = new AnimatedGameObject();

            characterSprites = new GameObjectList();
            background = new SpriteGameObject("Background");
            this.Add(background);

            Text = new TextGameObject("Button");
            Text.Text = "Select a character";
            Text.Position = new Vector2(GameEnvironment.Screen.X / 2 - Text.Size.X / 2, 100);
            this.Add(Text);

            characterSprites.Add(RobotAnim);
            characterSprites.Add(ZombieAnim);
            characterSprites.Add(MaleAdvAnim);
            characterSprites.Add(FemaleAdvAnim);

            RobotAnim.LoadAnimation("RobotIdle", "idleAnim", true, 0.15f);
            ZombieAnim.LoadAnimation("ZombieIdle", "idleAnim", true, 0.15f);
            MaleAdvAnim.LoadAnimation("Male_adv_idle", "idleAnim", true, 0.15f);
            FemaleAdvAnim.LoadAnimation("Female_adv_idle", "idleAnim", true, 0.15f);

        }
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
            for (int i = 0; i < characterSprites.Children.Count; i++)
            {
                characterSprites.Children[i].Position = new Vector2(175 + 225 * i, 400);
                this.Add(characterSprites.Children[i]);
            }

            foreach (AnimatedGameObject item in characterSprites.Children)
            {
                item.PlayAnimation("idleAnim");
                if (Selector == 0)
                {
                    characterSprites.Children.IndexOf(item);
                }
            }
            Console.WriteLine(Selector);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Right))
            {
                Selector += 1;
            }
            else
            {
                if (inputHelper.KeyPressed(Keys.Left))
                {
                    Selector -= 1;
                }
            }
        }
    }
}
