using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Terrain_Maker.Scripts.UI {
    internal interface IPage {
        string Name { get; }

        void Initialize();
        void Update(GameTime gameTime);
        void AppendPage(IPage ipage); // add children, update depth
    }
}
