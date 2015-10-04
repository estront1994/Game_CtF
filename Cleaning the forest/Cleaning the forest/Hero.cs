using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cleaning_the_forest
{
    class Hero
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
        public float interval = 100;

        public Hero(Texture2D newTex_BlackDragon, Vector2 newPosition, int newframeHeight, int newframeWidth)
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


            if ((!(Keyboard.GetState().IsKeyDown(Keys.W)))&&(!(Keyboard.GetState().IsKeyDown(Keys.A)))&&
                (!(Keyboard.GetState().IsKeyDown(Keys.S)))&&(!(Keyboard.GetState().IsKeyDown(Keys.D))) && (!(Keyboard.GetState().IsKeyDown(Keys.E))))
            {
                frameCurrent = 0;
                velosity = Vector2.Zero;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W)){
                Top(gametime);
                velosity.Y = -3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A)){
                Left(gametime);
                velosity.X = -3;
            }  
            if (Keyboard.GetState().IsKeyDown(Keys.S)){
                Bot(gametime);
                velosity.Y = 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D)){
                Right(gametime);
                velosity.X = 3;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                Battle(gametime);
            }
        }


        public void Top(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                frameCurrent++;
                timer = 0;
                if (frameCurrent < 7 || frameCurrent > 12) frameCurrent = 7;
            }
        }
        public void Right(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                frameCurrent++;
                timer = 0;
                if (frameCurrent < 19 || frameCurrent > 24) frameCurrent = 19;
            }
        }
        public void Left(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                frameCurrent++;
                timer = 0;
                if (frameCurrent < 13 || frameCurrent > 18) frameCurrent = 13;
            }
        }
        public void Bot(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval)
            {
                frameCurrent++;
                timer = 0;
                if (frameCurrent > 6) frameCurrent = 1;
            }
        }

        public void Battle(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > 150)
            {
                frameCurrent++;
                timer = 0;
                if (frameCurrent < 25 || frameCurrent > 27) frameCurrent = 25;
            }
        }

        public void setinterval(float newintervaln)
        {
            interval = newintervaln;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Tex_BlackDragon, Position, Rec_BlackDragon, Color.White, 0f, originalPosition, 1.0f, SpriteEffects.None, 0);
        }

    }
}
