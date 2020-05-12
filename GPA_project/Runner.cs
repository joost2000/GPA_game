using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

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
        
        //load the Song library
        Song bgMusic;

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen = new Point(1080, 720);
            ApplyResolutionSettings();

            // TODO: use this.Content to load your game content here

            //load the song
            this.bgMusic = Content.Load<Song>("bgMusic");

            //set the song volume, play it and loop it
            MediaPlayer.Volume = 0.1f;
            MediaPlayer.Play(bgMusic);
            MediaPlayer.IsRepeating = true;

            //Load GameStates
            gameStateManager.AddGameState("StartUpState", new StartUpState());
            gameStateManager.AddGameState("CharacterSelectState", new CharacterSelectState());
            gameStateManager.AddGameState("PlayingState", new PlayingState());
            gameStateManager.AddGameState("GameOverState", new GameOverState());

            gameStateManager.SwitchTo("CharacterSelectState");
        }
    }
}
