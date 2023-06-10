using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Terrain_Maker.Scripts.Components {
    internal class Drawable : Component {
        public string[] REQUIRED_COMPONENTS { get { return new string[] { "" };  } }
        string texturePath;
        Texture2D texture2D;
        Entity entity;

        public Drawable(Entity entity, string texturePath) { 
            this.texturePath = texturePath;
            this.entity = entity;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture2D, new Rectangle(entity.Position.X, entity.Position.Y, entity.Size.X, entity.Size.Y), Color.White);
        }

        public void Update(GameTime gameTime) {
            
        }

        public void LoadComponent(ContentManager content, SpriteBatch spriteBatch) {
            texture2D = content.Load<Texture2D>(texturePath);
            Debug.WriteLine(texturePath);
            
        }
    }
}
