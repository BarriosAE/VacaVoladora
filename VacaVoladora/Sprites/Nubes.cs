using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace VacaVoladora.Sprites
{
    public class Nubes : Sprite
    {
        public Texture2D Image2 { get; protected set; }
        public int time;
        public Nubes()
        {
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/NubeA");
            Image2 = Game1.TheGame.Content.Load<Texture2D>("Images/NubeB");
            Rectangle = new Rectangle(
                Game1.TheGame.GraphicsDevice.Viewport.Width,
                random.Next(Game1.TheGame.GraphicsDevice.Viewport.Height - 80),
                80, 80);
            Color = Color.White;
            time = random.Next(1, 2);
        }
        public override void Draw(GameTime gameTime)
        {
            if (time == 1)
            {
                Game1.TheGame.spriteBatch.Draw(Image, Rectangle, Color);
                time = random.Next(1, 2);
            }
            else
            {
                Game1.TheGame.spriteBatch.Draw(Image2, Rectangle, Color);
                time = random.Next(1, 3);
            }
        }

        public override void Update(GameTime gameTime)
        {
            int x = Rectangle.X;
            x -= 2;

            Rectangle = new Rectangle(x, Rectangle.Y, Rectangle.Width, Rectangle.Height);

            if (Rectangle.X < -100)
                Game1.TheGame.Actualizaciones.Add(this);
        }
    }
}
