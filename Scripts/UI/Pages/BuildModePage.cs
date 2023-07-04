using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Terrain_Maker.Scripts.UI.Pages {
    internal class BuildModePage : IPage {
        public string Name => throw new NotImplementedException();

        UIElement placeRoadButton;
        UIElement removeRoadButton;
        UIElement screenLabel;

        int counter;

        // Parent and Child system is set up via UIElement Constructor
        public BuildModePage (UIElement root) {
            placeRoadButton = new UIElement(root);
            removeRoadButton = new UIElement(root);
            screenLabel = new UIElement(root);
        }

        public void AppendPage(IPage ipage) {
            throw new NotImplementedException();
        }

        public void Initialize() {

            placeRoadButton.SetName("place road button");
            placeRoadButton.SetText("Place Road");
            placeRoadButton.Stylesheet["background-color"] = "#4CAF50FF";
            placeRoadButton.Stylesheet["width"] = "100";
            placeRoadButton.Stylesheet["height"] = "100";
            placeRoadButton.Stylesheet["color"] = "#ffffffff";
            placeRoadButton.Stylesheet["x"] = "50";
            placeRoadButton.OnClick(() => {
                screenLabel.SetText("Placing Road!");
            });

            screenLabel.SetName("Screen Label");
            screenLabel.SetText("Screen Label");
            screenLabel.Stylesheet["color"] = "#000000ff";
            screenLabel.Stylesheet["background-color"] = "#00000000";
            screenLabel.Stylesheet["fontScaling"] = "1";
            screenLabel.Stylesheet["width"] = "120";
            screenLabel.Stylesheet["height"] = "40";
            screenLabel.Stylesheet["x"] = (GAME_SETTINGS.GAME_WINDOW_WIDTH / 2 - 120 / 2).ToString();

            removeRoadButton.SetName("remove road button");
            removeRoadButton.Stylesheet["background-color"] = "#0015ffff";
            removeRoadButton.Stylesheet["width"] = "100";
            removeRoadButton.Stylesheet["height"] = "100";
            removeRoadButton.Stylesheet["x"] = "300";
            removeRoadButton.OnClick(() => {
                screenLabel.SetText("Removing Road!");
            });
        }

        public void Update(GameTime gameTime) {
            ++counter;
            var alpha = (int)(counter % 255);
            var alphaHex = alpha.ToString("x");
            placeRoadButton.Stylesheet["background-color"] = $"{placeRoadButton.Stylesheet["background-color"].Substring(0, 7)}{alphaHex}";
        }
    }
}
