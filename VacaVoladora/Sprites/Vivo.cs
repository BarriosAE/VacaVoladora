using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace VacaVoladora.Sprites
{
    public abstract class Vivo : Sprite
    {
        public virtual int Health { get; set; }
        protected Texture2D vida;

        public override void Draw(GameTime gameTime)
        {
            DrawHealth(gameTime);

            base.Draw(gameTime);
        }

        protected void DrawHealth(GameTime gameTime)
        {
            if (Health > 0)
            {
                vida = new Texture2D(Game1.TheGame.GraphicsDevice, Health, 20);
                Color[] data = new Color[Health * 20];
                for (int i = 0; i < data.Length; i++)
                    data[i] = Color.LightGreen;

                vida.SetData(data);
                Game1.TheGame.spriteBatch.Draw(vida, new Vector2(Rectangle.X, Rectangle.Y), Color.White);
            }
        }
    }
}
