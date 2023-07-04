using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Terrain_Maker.Scripts.UI.Pages;

namespace Terrain_Maker.Scripts.UI {
    internal class UI {

        UIElement root;
        List<IPage> pages;

        public UI () {
            pages = new List<IPage> ();
        }

        public void Initialize () {

            root = new UIElement ();
            root.SetName("root");
            pages.Add(new BuildModePage(root));

            TraverseUIElement(root, (node) => { node.Initialize();});
            foreach (var page in pages) {
                page.Initialize();
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            TraverseUIElement(root, (node) => { node.Draw(gameTime, spriteBatch); });
        }


        public void Update(GameTime gameTime) {

            TraverseUIElement(root, (node) => { node.Update(gameTime); });

            foreach (var page in pages) {
                page.Update(gameTime);
            }
        }

        public void LoadContent(ContentManager content) {

            TraverseUIElement(root, (node) => { node.LoadContent(content); });
        }

        void TraverseUIElement(UIElement node, Action<UIElement> func) {

            //add function here 
            func(node);

            foreach (var uielement in node.Children) {
                TraverseUIElement(uielement, func);
            }
        }
    }
}
