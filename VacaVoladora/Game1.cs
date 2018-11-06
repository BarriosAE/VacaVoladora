using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using VacaVoladora.Sprites;

namespace VacaVoladora
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public enum Fuentes
        {
            Estadisticas, BigFont
        }
        public Dictionary<Fuentes, SpriteFont> Fonts { get; private set; }
        internal GraphicsDeviceManager graphics { get; private set; }
        internal SpriteBatch spriteBatch { get; private set; }
        internal static Game1 TheGame { get; private set; }
        internal List<Actualizable> sprites { get; private set; }
        internal List<Sprite> Actualizaciones { get; private set; }



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            TheGame = this;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Fonts = new Dictionary<Fuentes, SpriteFont>();
            Actualizaciones = new List<Sprite>();
            sprites = new List<Actualizable>();
            Fonts.Add(Fuentes.BigFont,
            Content.Load<SpriteFont>("Fonts/BigFont"));
            Fonts.Add(Fuentes.Estadisticas,
                        Content.Load<SpriteFont>("Fonts/Stats"));

            sprites.Add(new Fondo());
            sprites.Add(new ColeccionNubes());
            sprites.Add(new ColecccionBombas());
            sprites.Add(new Vaca());
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (var item in sprites)
            {
                item.Update(gameTime);
            }
            foreach (var item in Actualizaciones)
            {
                if (sprites.Contains(item))
                    sprites.Remove(item);
                else
                    sprites.Add(item);
            }
            Actualizaciones.Clear();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SkyBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach (var item in sprites)
            {
                if (item is Sprite)
                    ((Sprite)item).Draw(gameTime);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
