﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mono2D
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager Graphics { get; private set; }
        public SpriteBatch SpriteBatch { get; private set; }

        public KeyboardState KeyboardState { get; private set; }

        public Map Map { get; } = new Map();
        public Player Player { get; } = new Player();

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Drawing.InitializeGraphics(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState = Keyboard.GetState();
            ProcessKeyboardState();

            // Update player
            Player.Update(gameTime, this);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin(); // Begin sprite batch
            Map.Draw(gameTime, this); // Draw map
            SpriteBatch.End(); // End sprite batch

            base.Draw(gameTime);
        }

        private void ProcessKeyboardState()
        {
            KeyboardState state = KeyboardState;

            if (state.IsKeyDown(Keys.Escape)) Exit();
        }
    }
}
