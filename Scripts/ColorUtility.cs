using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Terrain_Maker.Scripts {
    static internal class ColorUtility {
        
        /// <summary>
        /// Includes an alpha channel
        /// </summary>
        public static Color ConvertHexToRGBA (string hex) {

            var hexTemp = hex;

            // if hex has a # sign. i.e. #FFAABB00
            if (hexTemp[0] == '#') {
                hexTemp = hexTemp.Substring(1);
            }

            // if hex does not contain an alpha sign
            if (hexTemp.Length != 8) {
                hexTemp = $"{hexTemp}FF";
            }

            // add validation here for
            // 1) sequences where theres multiple ##
            // 2) sequences where theres more than 8 hex bits
            //

            var r = Int32.Parse(hexTemp.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            var g = Int32.Parse(hexTemp.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            var b = Int32.Parse(hexTemp.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            var a = Int32.Parse(hexTemp.Substring(6), System.Globalization.NumberStyles.HexNumber);

            return new Color(r, g, b, a);
        }

        /// <summary>
        /// 
        /// </summary>
        public static Color ConvertHexToRGB (string hex) {
            var hexTemp = hex;

            // if hex has a # sign. i.e. #FFAABB00
            if (hexTemp[0] == '#') {
                hexTemp = hexTemp.Substring(1);
            }

            // if hex does not contain an alpha sign
            if (hexTemp.Length != 6) {
                hexTemp = $"{hexTemp}FF";
            }

            // add validation here for
            // 1) sequences where theres multiple ##
            // 2) sequences where theres more than 8 hex bits
            //

            var r = Int32.Parse(hexTemp.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            var g = Int32.Parse(hexTemp.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            var b = Int32.Parse(hexTemp.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

            return new Color(r, g, b);
        }
    }
}
