using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Terrain_Maker.Scripts.Components;
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

            var gridSize = 64;
            for (var x = 0; x < (int)Math.Sqrt(gridSize); ++x) {
                for (var y = 0; y < (int)Math.Sqrt(gridSize); ++y) {
                    var tile = new Tile();
                    IntVector2 tileSize = new IntVector2(tile.GetComponent<Transform>().Size.X, tile.GetComponent<Transform>().Size.Y);
                    tile.GetComponent<Transform>().Move(x * tileSize.X, y * tileSize.Y);
                    entities.Add(tile);
                }
            }

            foreach (Entity entity in entities) {
                foreach (IComponent component in entity.Components) {
                    component.LoadComponent(content, spriteBatch);
                    
                }
            }
        }

        public void Update(GameTime gameTime) {
            foreach(Entity entity in entities) {
                foreach(IComponent component in entity.Components) {
                    component.Update(gameTime);
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            foreach (Entity entity in entities) {
                foreach (IComponent component in entity.Components) {
                    component.Draw(gameTime, spriteBatch);
                }
            }
        }

        public Entity CreateEntity () {
            return new EmptyEntity();
        }
    }
}
