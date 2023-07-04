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
    internal class CTileBehavior : IComponent {
        public string[] REQUIRED_COMPONENTS { get { return new string[] { "ctransform", "cdrawable" };  } }
        Entity entity;
        CTransform entityTransform;

        int BitLocation { get { return bitLocation; } }

        int bitLocation; // binary location
        int bitState = 1 << 15; // bits // 15 is the full value

        public enum BitStates {
            empty = 0,
            left = 1,
            top = 2,
            right = 4, 
            bottom = 8,
            topleft = 3,
            leftright = 5,
            bottomleft = 9,
            topright = 6,
            topbottom = 10,
            bottomright = 12,
            leftrightbottom = 7,
            lefttopbottom = 11,
            leftrighttop = 13,
            topbottomright = 14,
            all = 15
        }

        public CTileBehavior(Entity entity) {

            this.entity = entity;
            this.entityTransform = entity.GetComponent<CTransform>();

            this.bitLocation = 0; // unused
            this.bitState = 15; // default state is 15; all entry points open
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
        }

        public void Update(GameTime gameTime) {
            
        }

        public void LoadComponent(ContentManager content) {
            
        }

        public void ChangeBitState(int bitState) {
            this.bitState = bitState;
            //entity.GetComponent<CDrawable>().ChangeSrcRectangle(
            //    new Rectangle(GAME_SETTINGS.TEXTURE_SIZE * x, 
            //    GAME_SETTINGS.TEXTURE_SIZE * y, 
            //    GAME_SETTINGS.TEXTURE_SIZE, 
            //    GAME_SETTINGS.TEXTURE_SIZE));
        }

        public void ChangeBitState(BitStates bitState) {
            this.bitState = (int) bitState;
            Rectangle srcRectangle = Rectangle.Empty;
            switch (this.bitState) {
                case 1: srcRectangle = new Rectangle(GAME_SETTINGS.TEXTURE_SIZE * 0, GAME_SETTINGS.TEXTURE_SIZE * 0, GAME_SETTINGS.TEXTURE_SIZE, GAME_SETTINGS.TEXTURE_SIZE); break;
                case 2: srcRectangle = new Rectangle(GAME_SETTINGS.TEXTURE_SIZE * 1, GAME_SETTINGS.TEXTURE_SIZE * 0, GAME_SETTINGS.TEXTURE_SIZE, GAME_SETTINGS.TEXTURE_SIZE); break;
                case 4: srcRectangle = new Rectangle(GAME_SETTINGS.TEXTURE_SIZE * 2, GAME_SETTINGS.TEXTURE_SIZE * 0, GAME_SETTINGS.TEXTURE_SIZE, GAME_SETTINGS.TEXTURE_SIZE); break;
                case 8: srcRectangle = new Rectangle(GAME_SETTINGS.TEXTURE_SIZE * 3, GAME_SETTINGS.TEXTURE_SIZE * 0, GAME_SETTINGS.TEXTURE_SIZE, GAME_SETTINGS.TEXTURE_SIZE); break;
                case 3: srcRectangle = new Rectangle(GAME_SETTINGS.TEXTURE_SIZE * 0, GAME_SETTINGS.TEXTURE_SIZE * 1, GAME_SETTINGS.TEXTURE_SIZE, GAME_SETTINGS.TEXTURE_SIZE); break;
                case 5: srcRectangle = new Rectangle(GAME_SETTINGS.TEXTURE_SIZE * 1, GAME_SETTINGS.TEXTURE_SIZE * 1, GAME_SETTINGS.TEXTURE_SIZE, GAME_SETTINGS.TEXTURE_SIZE); break;
                case 9: srcRectangle = new Rectangle(GAME_SETTINGS.TEXTURE_SIZE * 2, GAME_SETTINGS.TEXTURE_SIZE * 1, GAME_SETTINGS.TEXTURE_SIZE, GAME_SETTINGS.TEXTURE_SIZE); break;
                case 6: srcRectangle = new Rectangle(GAME_SETTINGS.TEXTURE_SIZE * 3, GAME_SETTINGS.TEXTURE_SIZE * 1, GAME_SETTINGS.TEXTURE_SIZE, GAME_SETTINGS.TEXTURE_SIZE); break;
                case 10: srcRectangle = new Rectangle(GAME_SETTINGS.TEXTURE_SIZE * 0, GAME_SETTINGS.TEXTURE_SIZE * 2, GAME_SETTINGS.TEXTURE_SIZE, GAME_SETTINGS.TEXTURE_SIZE); break;
                case 12: srcRectangle = new Rectangle(GAME_SETTINGS.TEXTURE_SIZE * 1, GAME_SETTINGS.TEXTURE_SIZE * 2, GAME_SETTINGS.TEXTURE_SIZE, GAME_SETTINGS.TEXTURE_SIZE); break;
                case 7: srcRectangle = new Rectangle(GAME_SETTINGS.TEXTURE_SIZE * 2, GAME_SETTINGS.TEXTURE_SIZE * 2, GAME_SETTINGS.TEXTURE_SIZE, GAME_SETTINGS.TEXTURE_SIZE); break;
                case 11: srcRectangle = new Rectangle(GAME_SETTINGS.TEXTURE_SIZE * 3, GAME_SETTINGS.TEXTURE_SIZE * 2, GAME_SETTINGS.TEXTURE_SIZE, GAME_SETTINGS.TEXTURE_SIZE); break;
                case 13: srcRectangle = new Rectangle(GAME_SETTINGS.TEXTURE_SIZE * 0, GAME_SETTINGS.TEXTURE_SIZE * 3, GAME_SETTINGS.TEXTURE_SIZE, GAME_SETTINGS.TEXTURE_SIZE); break;
                case 14: srcRectangle = new Rectangle(GAME_SETTINGS.TEXTURE_SIZE * 1, GAME_SETTINGS.TEXTURE_SIZE * 3, GAME_SETTINGS.TEXTURE_SIZE, GAME_SETTINGS.TEXTURE_SIZE); break;
                case 15: srcRectangle = new Rectangle(GAME_SETTINGS.TEXTURE_SIZE * 2, GAME_SETTINGS.TEXTURE_SIZE * 3, GAME_SETTINGS.TEXTURE_SIZE, GAME_SETTINGS.TEXTURE_SIZE); break;
                case 0: srcRectangle = new Rectangle(GAME_SETTINGS.TEXTURE_SIZE * 3, GAME_SETTINGS.TEXTURE_SIZE * 3, GAME_SETTINGS.TEXTURE_SIZE, GAME_SETTINGS.TEXTURE_SIZE); break;
            }
            entity.GetComponent<CDrawable>().ChangeSrcRectangle(srcRectangle);
        }

        public void ChangeLocation(int bitLocation) {
            this.bitLocation = bitLocation;

        }

        public void Initialize() {
            throw new NotImplementedException();
        }
    }
}
