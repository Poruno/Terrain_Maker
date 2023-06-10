using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Terrain_Maker.Scripts.Entities;

namespace Terrain_Maker.Scripts {

    // To keep consistency: Update and Draw functions will function as:
    // line 1: Update Entities()
    // line 1+: World Logic
    // Entity logic input comes first and the world will adjust them to fit. 
    // i.e. Entity goes through a wall, World validates this logic and pushes it back inside of the world before drawing.
    // Preventing weird glitches before it shows up to the user
    internal class World {
        List<Entity> entities;
        EventManager eventManager;
        public World() {
            entities = new List<Entity>();
            eventManager = new EventManager();
        }

        public void LoadContent(ContentManager content, SpriteBatch spriteBatch) {
            entities.Add(new Tile());

            foreach (Entity entity in entities) {
                foreach (Component component in entity.Components) {
                    component.LoadComponent(content, spriteBatch);
                    
                }
            }
        }

        public void Update(GameTime gameTime) {
            foreach(Entity entity in entities) {
                foreach(Component component in entity.Components) {
                    component.Update(gameTime);
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            foreach (Entity entity in entities) {
                foreach (Component component in entity.Components) {
                    component.Draw(gameTime, spriteBatch);
                }
            }
        }

        public Entity CreateEntity () {
            return new EmptyEntity();
        }
    }
}
