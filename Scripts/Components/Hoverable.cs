using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Terrain_Maker.Scripts.Components {
    internal class Hoverable : IComponent {

        public string[] REQUIRED_COMPONENTS { get { return new string[] { "transform" }; } }
        string texturePath;
        Texture2D texture2D;
        Entity entity;
        Transform entityTransform;
        Color currentColor;
        Color hoverColor;
        Color defaultColor;

        public Hoverable (Entity entity, string texturePath) {
            this.texturePath = texturePath;
            this.entity = entity;
            this.entityTransform = entity.GetComponent<Transform>();

            currentColor = new Color();
            defaultColor = new Color();
            hoverColor = Color.HotPink;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            var rectangle = new Rectangle(entityTransform.Position.X, entityTransform.Position.Y, entityTransform.Size.X, entityTransform.Size.Y);
            spriteBatch.Draw(texture2D, rectangle, currentColor);
        }

        public void Update(GameTime gameTime) {
            var entityRectangle = new Rectangle(entityTransform.Position.X, entityTransform.Position.Y, entityTransform.Size.X, entityTransform.Size.Y);
            var mouseRectangle = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);

            if (entityRectangle.Intersects(mouseRectangle)) {
                currentColor = hoverColor;
            } else {
                currentColor = defaultColor;
            }
        }

        public void LoadComponent(ContentManager content, SpriteBatch spriteBatch) {
            texture2D = content.Load<Texture2D>(texturePath);
        }
    }
}
