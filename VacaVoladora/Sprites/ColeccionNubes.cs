using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace VacaVoladora.Sprites
{
    public class ColeccionNubes : Actualizable
    {
        protected static Random random;
        protected int time;
        TimeSpan nubetime;
        public ColeccionNubes()
        {
            if (random == null)
                random = new Random();
            time = random.Next(300, 700);
        }

        public void Update(GameTime gameTime)
        {
            //if (Game1.TheGame.sprites.Count < 7)
            if (gameTime.TotalGameTime.Subtract(nubetime).Milliseconds >=time)
            {
                nubetime = gameTime.TotalGameTime;
                Game1.TheGame.Actualizaciones.Add(new Nubes());
                time = random.Next(400, 800);
            }
        }
    }
}
