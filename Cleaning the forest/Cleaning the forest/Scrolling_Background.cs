using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cleaning_the_forest
{
    class Scrolling_Background
    {
        public Texture2D Tex_Background;
        public Rectangle Rec_Background;


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Tex_Background, Rec_Background, Color.White);
        }
    }

    class MainScrolling : Scrolling_Background
    {
        public MainScrolling(Texture2D newTex_Background, Rectangle newRec_Background)
        {
            Tex_Background = newTex_Background;
            Rec_Background = newRec_Background;
        }

        public void UpdateRight_Scrolling_Background()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D)) Rec_Background.X -= 5;
        }

        public void UpdateLeft_Scrolling_Background()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A)) Rec_Background.X += 5;
        }
    }
}
