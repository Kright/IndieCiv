using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace IndieCivCore {
    public enum ButtonState {

        Up,
        Down,
        Pressed,
        Released,
    }

    public static class MouseState {
        public static Vector2 Position;
        public static Vector2 Moved;

        public static Vector2 MouseDownPosition;

        public static ButtonState Left;
        public static ButtonState Right;
        public static ButtonState Middle;

        static MouseState() {
            MouseState.Moved.X = 0;
            MouseState.Moved.Y = 0;
        }

        public static void Update(int x, int y) {
            Moved.X = Position.X - x;
            Moved.Y = Position.Y - y;

            Position.X = x;
            Position.Y = y;

        }

        public static void Reset() {
            if (MouseState.Left == ButtonState.Pressed) {
                MouseState.Left = ButtonState.Down;
            }
            else if (MouseState.Left == ButtonState.Released) {
                MouseState.Left = ButtonState.Up;
            }
            /*if (MouseState.Left == ButtonState.Released) {
                MouseState.Left = 0;
            }
            if (MouseState.Right == ButtonState.Released) {
                MouseState.Right = 0;
            }
            if (MouseState.Middle == ButtonState.Released) {
                MouseState.Middle = 0;
            }*/
        }

        public static bool IsMouseDown() {
            return MouseState.Left == ButtonState.Pressed || MouseState.Right == ButtonState.Pressed || MouseState.Middle == ButtonState.Pressed;
        }
    }
}
