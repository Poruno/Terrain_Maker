using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terrain_Maker.Scripts.Components;

namespace Terrain_Maker.Scripts.Entities {
    internal class Tile : Entity {
        public Tile () {
            
            AddComponent<Transform>();
            AddComponent(new Drawable(this, "Generic/1x1rectangle"));
            this.GetComponent<Transform>().Resize(100, 100);
            this.GetComponent<Transform>().Move(50, 50);
        }
    }
}
