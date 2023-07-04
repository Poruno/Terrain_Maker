using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Terrain_Maker.Scripts.Components;
using Terrain_Maker.Scripts.Entities;

namespace Terrain_Maker.Scripts
{

    // To keep consistency: Update and Draw functions will function as:
    // line 1: Update Entities()
    // line 1+: World Logic
    // Entity logic input comes first and the world will adjust them to fit. 
    // i.e. Entity goes through a wall, World validates this logic and pushes it back inside of the world before drawing.
    // Preventing weird glitches before it shows up to the user
    internal class World {
        List<Entity> entities;
        EventManager eventManager;

        int totalTileCount;
        int horizontalTileCount;
        int verticalTileCount;
        Dictionary<int, Road> roads;

        SpriteFont defaultFont;

        int hoverTilesBitsPosition { get { return totalTileCount; } }

        public World() {
            entities = new List<Entity>();
            eventManager = new EventManager();
        }
        public void Initialize () {

            foreach (Entity entity in entities) {
                foreach (IComponent component in entity.Components) {
                    component.Initialize();
                }
            }
        }

        public void LoadContent(ContentManager content, SpriteBatch spriteBatch) {

            horizontalTileCount = (int)Math.Ceiling((float)(GAME_SETTINGS.GAME_WINDOW_WIDTH/GAME_SETTINGS.TILESIZE));
            verticalTileCount = (int)Math.Ceiling((float)(GAME_SETTINGS.GAME_WINDOW_HEIGHT / GAME_SETTINGS.TILESIZE));

            totalTileCount = horizontalTileCount * verticalTileCount;
            roads = new Dictionary<int, Road>();

            defaultFont = content.Load<SpriteFont>("Fonts/defaultFont");
            //// hover tiles
            //for (var x = 0; x < horizontalTileCount; ++x) {
            //    for (var y = 0; y < verticalTileCount; ++y) {
            //        var tile = new Tile ();
            //        IntVector2 tileSize = new IntVector2(tile.GetComponent<CTransform>().Size.X, tile.GetComponent<CTransform>().Size.Y);
            //        tile.GetComponent<CTransform>().Translate(x * tileSize.X, y * tileSize.Y);
            //        tile.GetComponent<CTileBehavior>().ChangeLocation(1 << (x * y));
            //        tile.GetComponent<CTileBehavior>().ChangeBitState(CTileBehavior.BitStates.all);
            //        entities.Add(tile);
            //    }
            //}

            //var sampleTile = new Tile();
            //var sampleTileSize = new IntVector2(sampleTile.GetComponent<CTransform>().Size.X, sampleTile.GetComponent<CTransform>().Size.Y);
            //sampleTile.GetComponent<CTileBehavior>().ChangeBitState(CTileBehavior.BitStates.left | CTileBehavior.BitStates.top);
            //sampleTile.GetComponent<CTransform>().Translate(0,0);
            //entities.Add(sampleTile);

            //Debug.WriteLine((int)(CTileBehavior.BitStates.top | CTileBehavior.BitStates.left));

            //// sample tilesheet
            //for (var x = 0; x < 4; ++x) {
            //    for (var y = 0; y < 4; ++y) {
            //        var road = new Road();
            //        road.GetComponent<CDrawable>().ChangeSrcRectangle(new Rectangle(GAME_SETTINGS.TEXTURE_SIZE * x, GAME_SETTINGS.TEXTURE_SIZE * y, GAME_SETTINGS.TEXTURE_SIZE, GAME_SETTINGS.TEXTURE_SIZE));
            //        road.GetComponent<CTransform>().Translate(GAME_SETTINGS.TILESIZE * x, GAME_SETTINGS.TILESIZE * y);
            //        entities.Add(road);
            //    }
            //}

            foreach (Entity entity in entities) {
                foreach (IComponent component in entity.Components) {
                    component.LoadComponent(content);
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
    }
}
