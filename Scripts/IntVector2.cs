using System.Security;

namespace Terrain_Maker.Scripts {
 
    public struct IntVector2 {
        public int X { get; }
        public int Y { get; }

        public IntVector2(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public IntVector2(float x, float y) {
            this.X = (int)x;
            this.Y = (int)y;
        }

        public IntVector2 (IntVector2 value) {
            this.X = value.X;
            this.Y = value.Y;
        }

        public static IntVector2 Zero { get { return new IntVector2(0, 0); } }
    }
}
