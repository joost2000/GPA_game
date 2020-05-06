using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GPA_project
{
    class GameOverState : GameObjectList
    {
        bool buttonSwitch = false;

        TextGameObject gameOver;
        TextGameObject restart;
        TextGameObject mainMenu;

        public GameOverState()
        {
            //load sprites and text objects
            this.Add(new SpriteGameObject("Background"));

            gameOver = new TextGameObject("Text");
            restart = new TextGameObject("Button");
            mainMenu = new TextGameObject("Button");

            gameOver.Text = "Game Over";
            gameOver.Position = new Vector2(GameEnvironment.Screen.X / 2 - gameOver.Size.X / 2 - 10, 100);

            restart.Text = "Restart";
            restart.Position = new Vector2(GameEnvironment.Screen.X / 4 - restart.Size.X / 2, 400);

            mainMenu.Text = "Main Menu";
            mainMenu.Position = new Vector2(GameEnvironment.Screen.X / 1.4f - mainMenu.Size.X / 2, 400);

            this.Add(gameOver);
            this.Add(restart);
            this.Add(mainMenu);
            Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //visual feedback so the player knows which button hes pressing
            if (buttonSwitch)
            {
                mainMenu.Color = Color.Green;
                restart.Color = Color.White;
            }
            else
            {
                restart.Color = Color.Green;
                mainMenu.Color = Color.White;
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            //switch between the restart and main menu buttons
            //restart and main menu lead to their designated gamestates when enter is pressed
            if (inputHelper.KeyPressed(Keys.Right))
            {
                buttonSwitch = true;
            }

            if (inputHelper.KeyPressed(Keys.Left))
            {
                buttonSwitch = false;
            }

            if (inputHelper.KeyPressed(Keys.Enter) && buttonSwitch)
            {
                GameEnvironment.GameStateManager.SwitchTo("StartUpState");
            }
            
            if (inputHelper.KeyPressed(Keys.Enter) && !buttonSwitch)
            {
                GameEnvironment.GameStateManager.SwitchTo("PlayingState");
            }
        }
    }
}
