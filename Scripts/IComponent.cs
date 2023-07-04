using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Terrain_Maker.Scripts {
    public interface IComponent {

        /* Will not fully work if the entity does not possess the other components required. Hard coded */
        string[] REQUIRED_COMPONENTS { get; }

        void LoadComponent(ContentManager content);
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        void Initialize();
    }

    public class EmptyComponent : IComponent {
        public string[] REQUIRED_COMPONENTS { get { return new string[] { }; } }

        public EmptyComponent() {

        }

        public void Update(GameTime gameTime) {

        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {

        }   
        public void Initialize() {

        }

        public void LoadComponent(ContentManager content) {
            throw new NotImplementedException();
        }
    }
}
