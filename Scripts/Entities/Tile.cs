using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terrain_Maker.Scripts.Components;

namespace Terrain_Maker.Scripts.Entities {
    internal class Tile : Entity {
        public Tile () {

            AddComponent(new Drawable(this, "Generic/1x1rectangle"));
            this.Resize(100, 100);
            this.Move(0, 0);
        }
    }
}
