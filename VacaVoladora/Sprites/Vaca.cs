using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacaVoladora.Sprites
{
    public class Vaca : RectanguloAnimacion
    {
        public Vaca()
        {
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/Vacas");
            Rectangle = new Rectangle(50, 50, 80, 80);
            Health = 100;
            var w = Image.Width / 5;
            for (int i = 0; i < 5; i++)
            {
                rectangulos.Add(new Rectangle(w * i,
                    0,
                    w,
                    Image.Height));
            }
            selectedRectangle = 3;
        }

        TimeSpan lasttime, powertime, frametime;
        bool power;
        int danio;
        Rectangle rectBack;

        public int Score { get; internal set; }

        public override void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Subtract(frametime).Milliseconds > 200)
            {
                frametime = gameTime.TotalGameTime;
                selectedRectangle++;
                if (selectedRectangle > 4)
                    selectedRectangle = 3;
            }


            #region Coordenadas
            int x, y;
            x = Rectangle.X;
            y = Rectangle.Y;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                x -= 5;    
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                x += 5;    
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                y -= 5;    
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                y += 5;

            if (x > Game1.TheGame.GraphicsDevice.Viewport.Width - Rectangle.Width)
                x = Game1.TheGame.GraphicsDevice.Viewport.Width - Rectangle.Width;
            else if (x < 0)
                x = 0;

            if (y > Game1.TheGame.GraphicsDevice.Viewport.Height - Rectangle.Height)
                y = Game1.TheGame.GraphicsDevice.Viewport.Height - Rectangle.Height;
            else if (y < 0)
                y = 0;


            Rectangle = new Rectangle(x, y,
                                        Rectangle.Width,
                                        Rectangle.Height);
            #endregion

            if (power)
            {
                danio = gameTime.TotalGameTime.Subtract(powertime).Seconds;
                Rectangle = new Rectangle(Rectangle.X,
                                        Rectangle.Y,
                                        (int)(rectBack.Width * (1.0f + (float)danio / 4)),
                                        (int)(rectBack.Height * (1.0f + (float)danio / 4))
                                            );
            }

            if (Keyboard.GetState().IsKeyUp(Keys.C) && power)
            {
                power = false;
                Rectangle = rectBack;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.C) && !power)
            {
                power = true;
                powertime = gameTime.TotalGameTime;
                rectBack = Rectangle;
            }

            if (
                Keyboard.GetState().IsKeyDown(Keys.Space) &&
                gameTime.TotalGameTime.Subtract(lasttime).Milliseconds > 300
                )
            {
                lasttime = gameTime.TotalGameTime;

            }
        }
    }

}

