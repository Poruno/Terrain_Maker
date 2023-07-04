using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terrain_Maker.Scripts.Components;

namespace Terrain_Maker.Scripts.Entities {
    internal class Road : Tile {

        public Road (): base() {

            AddComponent(new CDrawable(this, "sample_tilesheet256"));
            this.GetComponent<CTransform>().Transform(GAME_SETTINGS.TILESIZE, GAME_SETTINGS.TILESIZE);
        }

        public void ChangeState (int state) {
            throw new NotImplementedException();
        }
    }
}
