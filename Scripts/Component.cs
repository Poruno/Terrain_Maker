using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Terrain_Maker.Scripts {
    public interface Component {

        /* Will not fully work if the entity does not possess the other components required. Hard coded */
        string[] REQUIRED_COMPONENTS { get; }

        void LoadComponent(ContentManager content, SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }

    public class EmptyComponent : Component {
        public string[] REQUIRED_COMPONENTS { get { return new string[] { }; } }

        public EmptyComponent() {

        }

        public void Update(GameTime gameTime) {

        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {

        }

        public void LoadComponent(ContentManager content, SpriteBatch spriteBatch) {
            throw new NotImplementedException();
        }
    }
}
