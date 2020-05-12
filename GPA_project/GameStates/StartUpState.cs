using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using System.Dynamic;

namespace GPA_project
{
    class StartUpState : GameObjectList
    {
        TextGameObject Title = new TextGameObject("Text");
        TextGameObject Button = new TextGameObject("Button");

        public static float mainMenuExitTime;
        bool showButton, saveTime;
        public StartUpState()
        {
            //load sprites and text
            this.Add(new SpriteGameObject("Background"));

            Title.Text = "Cloud Jumper";
            Title.Position = new Vector2(GameEnvironment.Screen.X, 100);
            this.Add(Title);

            Button.Text = "Press enter to play";
            Button.Position = new Vector2(GameEnvironment.Screen.X / 2 - Button.Size.X / 2, GameEnvironment.Screen.Y/2);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            //if you press enter save the amount of time spent in the start up screen
            if (showButton)
            {
                if (inputHelper.KeyPressed(Keys.Enter))
                {
                    saveTime = true;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            showButton = true;

            //slide title into screen
            if (Title.Position.X > GameEnvironment.Screen.X/2 - Title.Size.X/2)
            {
                showButton = false;
                Title.Position -= new Vector2(8, 0);
            }

            //show button when title has fully appeared
            if (showButton)
            {
                this.Add(Button);
            }

            //if statement for saving time
            if (saveTime)
            {
                mainMenuExitTime = (float)gameTime.TotalGameTime.TotalSeconds;
                GameEnvironment.GameStateManager.SwitchTo("CharacterSelectState");
                Reset();
            }
        }

        public override void Reset()
        {
            base.Reset();
            saveTime = false;
        }
    }
}
