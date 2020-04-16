using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GPA_project
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Runner : GameEnvironment
    {
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen = new Point(1080, 720);
            ApplyResolutionSettings();

            // TODO: use this.Content to load your game content here


            //Load GameStates
            gameStateManager.AddGameState("PlayingState", new PlayingState());
            gameStateManager.SwitchTo("PlayingState");
        }
    }
}
