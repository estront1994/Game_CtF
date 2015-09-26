using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Cleaning_the_forest
{
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        // Компонент
        spriteComp gameObject;
        Texture2D texture;

        enum GameState
        {
            MainMenu,
            Options,
            Playing,
        }
        GameState CurrentGameState = GameState.MainMenu;

        private Texture2D GameNameText;
        private Vector2 positionGameNameText = new Vector2(330, 65);
        //Объявление кнопок
        cButton Button_Start, Button_Rating, Button_Exit;
        // Параметры экраны игры
        int screenWidth = 1280, screenHeight = 720;

        private MainScrolling Scrolling_Background_1;
        private MainScrolling Scrolling_Background_2;
        private Hero sprite;
        private int ScreenWidth;
        private int ScreenHeight;


        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            sprite = new Hero(Content.Load<Texture2D>("Spraite_HeroDruid.png"), new Vector2(100, 600), 145, 185);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Разрешение экрана
            graphics.PreferredBackBufferWidth = screenWidth;    
            graphics.PreferredBackBufferHeight = screenHeight;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            IsMouseVisible = true;
            // Загрузка название игры на экран методм load и компонентом
            //GameNameText = Content.Load<Texture2D>("GameNameText.png");
            Services.AddService(typeof(SpriteBatch), spriteBatch);
            texture = Content.Load<Texture2D>("GameNameText.png");
            // Загрузка кнопок на экран //////////////////////////////////////////////////////////////////////////////
            Button_Start = new cButton(Content.Load<Texture2D>("Button1_StartMenu.png"), graphics.GraphicsDevice);
            Button_Rating = new cButton(Content.Load<Texture2D>("Button2_StartMenu.png"), graphics.GraphicsDevice);
            Button_Exit = new cButton(Content.Load<Texture2D>("Button3_StartMenu.png"), graphics.GraphicsDevice);
            Button_Start.setPosition(new Vector2(110, 270));
            Button_Start.sizeButton(new Vector2(208, 79));
            Button_Rating.setPosition(new Vector2(110, 370));
            Button_Rating.sizeButton(new Vector2(254, 84));
            Button_Exit.setPosition(new Vector2(110, 470));
            Button_Exit.sizeButton(new Vector2(160, 83));
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            Scrolling_Background_1 = new MainScrolling(Content.Load<Texture2D>("Background_01"), new Rectangle(0, 0, 1280, 720));
            Scrolling_Background_2 = new MainScrolling(Content.Load<Texture2D>("Background_02"), new Rectangle(1280, 0, 1280, 720));

            ScreenWidth = GraphicsDevice.Viewport.Width;
            ScreenHeight = GraphicsDevice.Viewport.Height;

            CreateNewObject();
        }

        protected void CreateNewObject()
        {
            gameObject = new spriteComp(this, ref texture, new Rectangle(1, 1, 885, 95), new Vector2(330, 65));
            Components.Add(gameObject);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            switch (CurrentGameState)
            {
                case GameState.MainMenu:                                // Меню
                    if (Button_Start.isClicked == true){
                        CurrentGameState = GameState.Playing;
                    }
                    if (Button_Rating.isClicked == true){
                        Exit();
                    }
                    if (Button_Exit.isClicked == true){
                        Exit();
                    }
                    Button_Start.Update(mouse);
                    Button_Rating.Update(mouse);
                    Button_Exit.Update(mouse);
                    break;
                case GameState.Playing:                                 // Игра
                    // Описание движущего фона
                    if (Scrolling_Background_1.Rec_Background.X + Scrolling_Background_1.Rec_Background.Width <= 0)
                        Scrolling_Background_1.Rec_Background.X = Scrolling_Background_2.Rec_Background.X + Scrolling_Background_2.Tex_Background.Width;
                    if (Scrolling_Background_2.Rec_Background.X + Scrolling_Background_2.Rec_Background.Width <= 0)
                        Scrolling_Background_2.Rec_Background.X = Scrolling_Background_1.Rec_Background.X + Scrolling_Background_1.Tex_Background.Width;


                    if ((sprite.Position.X >= ScreenHeight) & (Keyboard.GetState().IsKeyDown(Keys.Right)))
                    {
                        sprite.Update_AnimationBlackDragon_Stop(gameTime);
                        Scrolling_Background_1.UpdateRight_Scrolling_Background();
                        Scrolling_Background_2.UpdateRight_Scrolling_Background();
                    }
                    else
                    {
                        if (((sprite.Position.X <= 100) & (Keyboard.GetState().IsKeyDown(Keys.Left))))
                            sprite.Update_AnimationBlackDragon_Stop(gameTime);
                        sprite.Update_AnimationBlackDragon(gameTime);
                    }
                    break;
            }
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(Content.Load<Texture2D>("Picture_StartMenu.png"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    base.Draw(gameTime);
                    //spriteBatch.Draw(GameNameText, positionGameNameText, Color.White);
                    Button_Start.Draw(spriteBatch);
                    Button_Rating.Draw(spriteBatch);
                    Button_Exit.Draw(spriteBatch);
                    break;
                case GameState.Playing:
                    Scrolling_Background_1.Draw(spriteBatch);
                    Scrolling_Background_2.Draw(spriteBatch);
                    sprite.Draw(spriteBatch);
                    break;
            }
            //base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
