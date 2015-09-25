using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cleaning_the_forest
{
    class AnimationBlackDragon
    {
        public Texture2D Tex_BlackDragon;
        public Rectangle Rec_BlackDragon;

        public Vector2 originalPosition;
        public Vector2 Position;
        public Vector2 velosity;

        public int frameHeight;
        public int frameWidth;
        public int frameCurrent;

        public float timer;
        public float interval = 150;


        public AnimationBlackDragon(Texture2D newTex_BlackDragon, Vector2 newPosition, int newframeHeight, int newframeWidth)
        {

            Tex_BlackDragon = newTex_BlackDragon;
            Position = newPosition;
            frameHeight = newframeHeight;
            frameWidth = newframeWidth;
        }

        public void Update_AnimationBlackDragon(GameTime gametime)
        {
            Rec_BlackDragon = new Rectangle(frameCurrent * frameWidth, 0, frameWidth, frameHeight);
            originalPosition = new Vector2(Rec_BlackDragon.Width / 2, Rec_BlackDragon.Height / 2);
            Position = Position + velosity;


            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Right(gametime);
                velosity.X = 5;

            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left) & (Position.X > 100))
                {
                    Left(gametime);
                    velosity.X = -5;
                }
                else
                {

                    velosity = Vector2.Zero;
                }
            }
        }

        public void Update_AnimationBlackDragon_Stop(GameTime gametime)
        {
            Rec_BlackDragon = new Rectangle(frameCurrent * frameWidth, 0, frameWidth, frameHeight);
            originalPosition = new Vector2(Rec_BlackDragon.Width / 2, Rec_BlackDragon.Height / 2);
            Position = Position + velosity;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Right(gametime);
                velosity.X = 0;

            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    Left(gametime);
                    velosity.X = 0;
                }
                else
                {

                    velosity = Vector2.Zero;
                }
            }
        }


        public void Right(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                frameCurrent++;
                timer = 0;
                if (frameCurrent > 5) frameCurrent = 3;
            }
        }

        public void Left(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                frameCurrent++;
                timer = 0;
                if (frameCurrent > 18 || frameCurrent < 16) frameCurrent = 16;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Tex_BlackDragon, Position, Rec_BlackDragon, Color.White, 0f, originalPosition, 1.0f, SpriteEffects.None, 0);
        }

    }
}
