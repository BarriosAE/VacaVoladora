﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacaVoladora.Sprites
{
    public class Bombas:RectanguloAnimacion
    {

        public Bombas()
        {
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/bomba");
            Rectangle = new Rectangle(Game1.TheGame.GraphicsDevice.Viewport.Width,
    random.Next(Game1.TheGame.GraphicsDevice.Viewport.Height - 80),
    50, 50);
            Health = 100;
            var w = Image.Width / 2;
            for (int i = 0; i < 2; i++)
            {
                rectangulos.Add(new Rectangle(w * i, 0, w, Image.Height));
            }

        }

        TimeSpan lasttime, frametime;
        public override void Update(GameTime gameTime)
        {
              if (gameTime.TotalGameTime.Subtract(frametime).Milliseconds > 200)
            {
                frametime = gameTime.TotalGameTime;
                selectedRectangle++;
                if (selectedRectangle > 1)
                    selectedRectangle = 0;
            }
            #region coordenadas

            int x = Rectangle.X;
            x -= 2;

            Rectangle = new Rectangle(x, Rectangle.Y,
                Rectangle.Width, Rectangle.Height);

            if (Rectangle.X < -100)
            {
                Game1.TheGame.Actualizaciones.Add(this);
            }

            #endregion

            #region Choque

            if (gameTime.TotalGameTime.Subtract(lasttime).Milliseconds > 500)
            {
                lasttime = gameTime.TotalGameTime;
                Vaca LaVaca = null;
                foreach (var item in Game1.TheGame.sprites)
                {
                    if (item is Vaca)
                    {
                        LaVaca = item as Vaca;
                        break;
                    }
                }
                if (LaVaca == null)
                {
                    throw new NullReferenceException("No esta la vaca???");
                }
                if (Rectangle.Intersects(LaVaca.Rectangle))
                {
                    LaVaca.Health -= 10;
                }
            }
            #endregion

            if (Health <= 0)
            {
                Game1.TheGame.Actualizaciones.Add(this);
            }


        }
    }
}