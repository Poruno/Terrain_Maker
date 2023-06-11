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
        public string[] REQUIRED_COMPONENTS { get { return new string[] { "transform" };  } }
        string texturePath;
        Texture2D texture2D;
        Entity entity;
        Transform entityTransform;

        public Drawable(Entity entity, string texturePath) { 
            this.texturePath = texturePath;
            this.entity = entity;
            this.entityTransform = entity.GetComponent<Transform>();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            var rectangle = new Rectangle(entityTransform.Position.X, entityTransform.Position.Y, entityTransform.Size.X, entityTransform.Size.Y);
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }

        public void Update(GameTime gameTime) {
            
        }

        public void LoadComponent(ContentManager content, SpriteBatch spriteBatch) {
            texture2D = content.Load<Texture2D>(texturePath);
        }
    }
}
