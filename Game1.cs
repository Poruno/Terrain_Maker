using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Terrain_Maker.Scripts;
using Terrain_Maker.Scripts.UI;

namespace Terrain_Maker {
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        World world;
        UI ui;

        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here

            world = new World();
            world.Initialize();

            ui = new UI();
            ui.Initialize();

            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = GAME_SETTINGS.GAME_WINDOW_WIDTH;
            _graphics.PreferredBackBufferHeight = GAME_SETTINGS.GAME_WINDOW_HEIGHT;
            _graphics.ApplyChanges();

            generic = Content.Load<Texture2D>("Generic/1x1rectangle");
            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            world.LoadContent(Content, _spriteBatch);
            // TODO: use this.Content to load your game content here

            ui.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            world.Update(gameTime);
            ui.Update(gameTime);
            base.Update(gameTime);
        }

        Texture2D generic;
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(new Color(128, 143, 75));
            //GraphicsDevice.Clear(new Color(135, 148, 71));

            // TODO: Add your drawing code here
            _spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp);
            world.Draw(gameTime, _spriteBatch);
            ui.Draw(gameTime, _spriteBatch);
            //_spriteBatch.Draw(generic, new Rectangle(0, 0, 500, 500), new Rectangle(0, 0, 1, 1), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
            //_spriteBatch.Draw(generic, new Rectangle(0, 0, 100, 100), new Rectangle(0, 0, 1, 1), Color.Red, 0, Vector2.Zero, SpriteEffects.None, .1f);
            //_spriteBatch.Draw(generic, new Rectangle(50, 0, 200, 200), new Rectangle(0, 0, 1, 1), Color.Black, 0, Vector2.Zero, SpriteEffects.None, .2f);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}