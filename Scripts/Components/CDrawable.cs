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
    internal class CDrawable : IComponent {
        public string[] REQUIRED_COMPONENTS { get { return new string[] { "ctransform" };  } }
        string texturePath;
        Texture2D texture2D;
        Entity entity;
        CTransform entityTransform;
        Rectangle srcRectangle;

        public CDrawable(Entity entity, string texturePath) { 
            this.texturePath = texturePath;
            this.entity = entity;
            this.entityTransform = entity.GetComponent<CTransform>();
            this.srcRectangle = Rectangle.Empty;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            var rectangle = new Rectangle(entityTransform.Position.X, entityTransform.Position.Y, entityTransform.Size.X, entityTransform.Size.Y);
            spriteBatch.Draw(texture2D, rectangle, srcRectangle, Color.White);
        }

        public void Update(GameTime gameTime) {
            
        }

        public void ChangeTexture (Texture2D texture2D) {
            this.texture2D = texture2D;
        }

        public void ChangeSrcRectangle (Rectangle srcRectangle) {
            this.srcRectangle = srcRectangle;
        }

        public void LoadComponent(ContentManager content) {
            texture2D = content.Load<Texture2D>(texturePath);
        }

        public void Initialize() {
            
        }
    }
}
