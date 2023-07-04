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
    internal class CHoverable : IComponent {

        public string[] REQUIRED_COMPONENTS { get { return new string[] { "ctransform" }; } }

        public bool isDisabled;

        string texturePath;
        Texture2D texture2D;
        Entity entity;
        CTransform entityTransform;
        Color currentColor;
        Color hoverColor;
        Color defaultColor;

        public CHoverable (Entity entity, string texturePath) {
            this.texturePath = texturePath;
            this.entity = entity;
            this.entityTransform = entity.GetComponent<CTransform>();

            this.isDisabled = false;
            this.currentColor = new Color();
            this.defaultColor = new Color(0, 0, 0, 0);
            this.hoverColor = new Color(0,0,0,.2f);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            if (isDisabled) return;

            var rectangle = new Rectangle(entityTransform.Position.X, entityTransform.Position.Y, entityTransform.Size.X, entityTransform.Size.Y);
            spriteBatch.Draw(texture2D, rectangle, currentColor);
        }

        public void Update(GameTime gameTime) {
            if (isDisabled) return;

            var entityRectangle = new Rectangle(entityTransform.Position.X, entityTransform.Position.Y, entityTransform.Size.X, entityTransform.Size.Y);
            var mouseRectangle = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);

            if (entityRectangle.Contains(mouseRectangle)) {
                currentColor = hoverColor;
            } else {
                currentColor = defaultColor;
            }
        }

        public void LoadComponent(ContentManager content) {
            texture2D = content.Load<Texture2D>(texturePath);
        }

        public void Initialize() {
            throw new NotImplementedException();
        }
    }
}
