using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Collections.Specialized.BitVector32;

namespace Terrain_Maker.Scripts.UI
{
    /// <summary>
    /// Aims to be like HTML
    /// All elements are SHARED. Hoverable, clickable, everything a single element does everyone can do it too
    /// </summary>
    internal class UIElement
    {
        public UIElement Parent { get { return parent; } }
        public List<UIElement> Children { get { return children; } }
        public Dictionary<string, string> Stylesheet { get { return stylesheet; } }
        public string Name { get { return name; } }

        UIElement parent;
        List<UIElement> children;

        Rectangle srcRectangle;
        Texture2D texture2D;
        SpriteFont spritefont;

        string name, text;
        float layerDepth;
        Action onHover, onClick, onHeld, onRelease;

        IntVector2 position;
        IntVector2 size { get { return new IntVector2(Int32.Parse(stylesheet["width"]), Int32.Parse(stylesheet["height"])); } }
        Rectangle boundingBox { get { return new Rectangle(position.X, position.Y, size.X, size.Y); } }

        Dictionary<string, string> stylesheet;

        public UIElement() {
            children = new List<UIElement>();
            stylesheet = new Dictionary<string, string>();
        }

        public UIElement(UIElement parent) {
            this.parent = parent;
            parent.children.Add(this);

            children = new List<UIElement>();
            stylesheet = new Dictionary<string, string>();

            layerDepth = CountAncestry(this) * 0.01f;
        }

        public void Initialize () {

            onHover = () => { };
            onClick = () => { };
            onHeld = () => { };
            onRelease = () => { };

            text = string.Empty;

            stylesheet["position"] = "absolute"; // static, relative, fixed, absolute, sticky
            stylesheet["x"] = "0";
            stylesheet["y"] = "0";
            stylesheet["visibility"] = "visible"; // visible, hidden, collapse // collapse - notimplemented()
            stylesheet["display"] = "block"; // block, inline-block, none, flex, grid // inline-block, flex, grid -  notimplemented()

            // if no parent OR UIElement is "root". Width and height will be the size of the game window
            stylesheet["width"] = GAME_SETTINGS.GAME_WINDOW_WIDTH.ToString();
            stylesheet["height"] = GAME_SETTINGS.GAME_WINDOW_HEIGHT.ToString();

            if (Parent != null) {
                stylesheet["width"] = Parent.Stylesheet["width"];
                stylesheet["height"] = Parent.stylesheet["height"];
            }

            stylesheet["background-color"] = "#00000000";
            stylesheet["background-image"] = "Generic/1x1rectangle";

            // font styles
            stylesheet["fontScaling"] = "1"; //  font size scaling
            stylesheet["color"] = "#00000000"; // pertains to font color, usually
        }
    
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {

            if (stylesheet["visibility"] == "hidden") return;
            if (stylesheet["display"] == "none") return;

            var color = ColorUtility.ConvertHexToRGBA(stylesheet["background-color"]);
            spriteBatch.Draw(texture2D, boundingBox, srcRectangle, color, 0, Vector2.Zero, SpriteEffects.None, this.layerDepth);

            if (text == string.Empty) return;
            var textSize = spritefont.MeasureString(text);
            Vector2 stringPosition = new Vector2(this.position.X + size.X / 2 - textSize.X / 2, this.position.Y + size.Y / 2 - textSize.Y / 2);
            spriteBatch.DrawString(spritefont, text, stringPosition, ColorUtility.ConvertHexToRGBA(stylesheet["color"]), 0, Vector2.Zero, Int32.Parse(stylesheet["fontScaling"]), SpriteEffects.None, this.layerDepth + 0.001f);
        }

        public void Update(GameTime gameTime) {

            if (stylesheet["display"] == "none") return;
            MouseBehavior();
            position = ComputePosition();
        }

        public void LoadContent(ContentManager content) {

            texture2D = content.Load<Texture2D>(stylesheet["background-image"]);
            spritefont = content.Load<SpriteFont>("Fonts/defaultFont");
        }

        public void ChangeTexture(Texture2D texture2D) {

            this.texture2D = texture2D;
        }

        public void SetName (string name) {
            this.name = name;
        }

        public void SetText (string text) {
            this.text = text;
        }

        public void OnHover (Action action) {
            this.onHover = action;
        }

        public void OnClick (Action action) {
            this.onClick = action;
        }

        public void OnHeld (Action action) {
            this.onHeld = action;
        }

        public void OnRelease (Action action) {
            this.onRelease = action;
        }

        int CountAncestry(UIElement node) {
            int count = 0;
            var temp = node;
            while (temp.Parent != null) {
                ++count;
                temp = temp.Parent;
            }
            return count;
        }

        //IntVector2 position;
        IntVector2 ComputePosition () {
            var positionX = 0;
            var positionY = 0;
            
            var temp = this;
            while (temp.Parent != null) {
                positionX += Int32.Parse(temp.stylesheet["x"]);
                positionY += Int32.Parse(temp.stylesheet["y"]);
                temp = temp.Parent;
            }
            return new IntVector2(positionX, positionY);
        }

        ButtonState previousButtonState;
        void MouseBehavior() {
            if (boundingBox.Contains(Mouse.GetState().X, Mouse.GetState().Y)) {
                onHover();

                if (Mouse.GetState().LeftButton == ButtonState.Pressed) {
                    onHeld();
                }

                if (Mouse.GetState().LeftButton == ButtonState.Released) {
                    if (previousButtonState == ButtonState.Pressed) {
                        onClick();
                    }
                }
            }
            previousButtonState = Mouse.GetState().LeftButton;
        }
    }

    struct BoxModel
    {
        public Rectangle Margin;
        public Rectangle Border;
        public Rectangle Padding;
        public Rectangle Content;

        public BoxModel()
        {
            Margin = Rectangle.Empty;
            Border = Rectangle.Empty;
            Padding = Rectangle.Empty;
            Content = Rectangle.Empty;
        }
    }
}
