using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Terrain_Maker.Scripts.Components {

    internal class Transform : Component {

        IntVector2 position, size;

        public Transform () {
            this.position = IntVector2.Zero;
            this.size = IntVector2.Zero;
        }

            
        public IntVector2 Position { get { return position; } }
        public IntVector2 Size { get { return size; } }

        public string[] REQUIRED_COMPONENTS { get { return Array.Empty<string>(); } }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            // Does not draw
        }

        public void LoadComponent(ContentManager content, SpriteBatch spriteBatch) {
            // Does not load
        }

        public void Move(int x, int y) {
            this.position = new IntVector2(x, y);
        }

        public void Resize(int width, int height) {
            this.size = new IntVector2(width, height);
        }

        public void Update(GameTime gameTime) {
            // Does not update?
        }
    }

}
