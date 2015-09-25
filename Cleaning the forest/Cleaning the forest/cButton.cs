using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Cleaning_the_forest
{
    class cButton
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;

        Color colour = new Color(255, 255, 255, 255);
        public Vector2 size;
        public cButton(Texture2D newTexture, GraphicsDevice graphics)
        {
            texture = newTexture;
            size = new Vector2(208, 79);
        }
        bool down;
        public bool isClicked;
        public void Update(MouseState mouse)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRectangle.Intersects(rectangle))
            {
                if (colour.A == 255) down = false;
                if (colour.A == 0) down = true;
                if (down)
                {
                    colour.R += 15;
                    colour.G += 15;
                    colour.B += 15;
                    colour.A += 15;
                } 
                else
                {
                    colour.R -= 15;
                    colour.G -= 15;
                    colour.B -= 15;
                    colour.A -= 15;
                }
                if (mouse.LeftButton == ButtonState.Pressed) isClicked = true;
            }
            else if (colour.A < 255)
            {
                colour = new Color(255, 255, 255, 255);
                isClicked = false;
            }
        }
        public void setPosition(Vector2 newPosition){
            position = newPosition;
        }
        public void sizeButton(Vector2 sizeButton){
            size = sizeButton;
        }
        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture, rectangle, colour);
        }
    }
}
