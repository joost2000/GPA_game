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

        public static List<string> names = new List<string>();

        AnimatedGameObject RobotAnim;
        AnimatedGameObject ZombieAnim;
        AnimatedGameObject MaleAdvAnim;
        AnimatedGameObject FemaleAdvAnim;

        public static int Selector;

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
            RobotAnim.LoadAnimation("RobotRun@3", "runAnim", true, 0.15f);
            ZombieAnim.LoadAnimation("ZombieIdle", "idleAnim", true, 0.15f);
            ZombieAnim.LoadAnimation("ZombieRun@3", "runAnim", true, 0.15f);
            MaleAdvAnim.LoadAnimation("Male_adv_idle", "idleAnim", true, 0.15f);
            MaleAdvAnim.LoadAnimation("RunAnimMale@3", "runAnim", true, 0.15f);
            FemaleAdvAnim.LoadAnimation("Female_adv_idle", "idleAnim", true, 0.15f);
            FemaleAdvAnim.LoadAnimation("RunAnimFemale@3", "runAnim", true, 0.15f);
            
            for (int i = 0; i < characterSprites.Children.Count; i++)
            {
                characterSprites.Children[i].Position = new Vector2(175 + 225 * i, 400);
                this.Add(characterSprites.Children[i]);
            }

            names.Add("Robot");
            names.Add("Zombie");
            names.Add("Male");
            names.Add("Female");
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            switch (Selector)
            {
                case 0:
                    RobotAnim.PlayAnimation("runAnim");

                    ZombieAnim.PlayAnimation("idleAnim");
                    MaleAdvAnim.PlayAnimation("idleAnim");
                    FemaleAdvAnim.PlayAnimation("idleAnim");
                    break;
                case 1:
                    ZombieAnim.PlayAnimation("runAnim");

                    MaleAdvAnim.PlayAnimation("idleAnim");
                    RobotAnim.PlayAnimation("idleAnim");
                    FemaleAdvAnim.PlayAnimation("idleAnim");
                    break;
                case 2:
                    MaleAdvAnim.PlayAnimation("runAnim");

                    RobotAnim.PlayAnimation("idleAnim");
                    FemaleAdvAnim.PlayAnimation("idleAnim");
                    ZombieAnim.PlayAnimation("idleAnim");
                    break;
                case 3:
                    FemaleAdvAnim.PlayAnimation("runAnim");

                    RobotAnim.PlayAnimation("idleAnim");
                    MaleAdvAnim.PlayAnimation("idleAnim");
                    ZombieAnim.PlayAnimation("idleAnim");
                    break;
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (Selector < 3)
            {
                if (inputHelper.KeyPressed(Keys.Right))
                {
                    Selector += 1;
                }
            }
            if (Selector > 0)
            {
                if (inputHelper.KeyPressed(Keys.Left))
                {
                    Selector -= 1;
                }
            }

            if (inputHelper.KeyPressed(Keys.Enter))
            {
                GameEnvironment.GameStateManager.SwitchTo("PlayingState");
            }
        }

        public static String getSelectedCharacter()
        {
            return names[Selector];
        }
    }
}
