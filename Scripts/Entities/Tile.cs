using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terrain_Maker.Scripts.Components;

namespace Terrain_Maker.Scripts.Entities {
    internal class Tile : Entity {
        public Tile () {

            AddComponent<CTransform>();
            AddComponent(new CDrawable(this, "sample_tilesheet256"));
            AddComponent(new CHoverable(this, "Generic/1x1rectangle"));
            AddComponent(new CTileBehavior(this));
            this.GetComponent<CTransform>().Transform(GAME_SETTINGS.TILESIZE, GAME_SETTINGS.TILESIZE);
        }
    }
}
