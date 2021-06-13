using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGame.Extended.Input
{
    public struct MouseStateExtended
    {
        private readonly MouseState _currentMouseState;
        private readonly MouseState _previousMouseState;

        public MouseStateExtended(MouseState currentMouseState, MouseState previousMouseState)
        {
            _currentMouseState = currentMouseState;
            _previousMouseState = previousMouseState;
        }

        public int X => _currentMouseState.X;
        public int Y => _currentMouseState.Y;
        public Point Position => _currentMouseState.Position;
        public bool PositionChanged => _currentMouseState.Position != _previousMouseState.Position;

        public int DeltaX => _previousMouseState.X - _currentMouseState.X;
        public int DeltaY => _previousMouseState.Y - _currentMouseState.Y;
        public Point DeltaPosition => new Point(DeltaX, DeltaY);

        public int ScrollWheelValue => _currentMouseState.ScrollWheelValue;
        public int DeltaScrollWheelValue => _previousMouseState.ScrollWheelValue - _currentMouseState.ScrollWheelValue;

        public ButtonState LeftButton => _currentMouseState.LeftButton;
        public ButtonState MiddleButton => _currentMouseState.MiddleButton;
        public ButtonState RightButton => _currentMouseState.RightButton;
        public ButtonState XButton1 => _currentMouseState.XButton1;
        public ButtonState XButton2 => _currentMouseState.XButton2;

        public bool IsButtonDown(MouseButton button)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (button)
            {
                case MouseButton.Left:     return IsPressed(_leftButtonStateDel);
                case MouseButton.Middle:   return IsPressed(_middleButtonStateDel);
                case MouseButton.Right:    return IsPressed(_rightButtonStateDel);
                case MouseButton.XButton1: return IsPressed(_xButton1StateDel);
                case MouseButton.XButton2: return IsPressed(_xButton2StateDel);
            }

            return false;
        }

        static ButtonState LeftButtonState(MouseState m) => m.LeftButton;
        static Func<MouseState, ButtonState> _leftButtonStateDel = LeftButtonState;
        static ButtonState MiddleButtonState(MouseState m) => m.MiddleButton;
        static Func<MouseState, ButtonState> _middleButtonStateDel = MiddleButtonState;
        static ButtonState RightButtonState(MouseState m) => m.RightButton;
        static Func<MouseState, ButtonState> _rightButtonStateDel = RightButtonState;
        static ButtonState XButton1State(MouseState m) => m.XButton1;
        static Func<MouseState, ButtonState> _xButton1StateDel = XButton1State;
        static ButtonState XButton2State(MouseState m) => m.XButton2;
        static Func<MouseState, ButtonState> _xButton2StateDel = XButton2State;



        public bool IsButtonUp(MouseButton button)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (button)
            {
                case MouseButton.Left:      return IsReleased(_leftButtonStateDel);
                case MouseButton.Middle:    return IsReleased(_middleButtonStateDel);
                case MouseButton.Right:     return IsReleased(_rightButtonStateDel);
                case MouseButton.XButton1:  return IsReleased(_xButton1StateDel);
                case MouseButton.XButton2:  return IsReleased(_xButton2StateDel);
            }

            return false;
        }

        public bool WasButtonJustDown(MouseButton button)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (button)
            {
                case MouseButton.Left:      return WasJustPressed(_leftButtonStateDel);
                case MouseButton.Middle:    return WasJustPressed(_middleButtonStateDel);
                case MouseButton.Right:     return WasJustPressed(_rightButtonStateDel);
                case MouseButton.XButton1:  return WasJustPressed(_xButton1StateDel);
                case MouseButton.XButton2:  return WasJustPressed(_xButton2StateDel);
            }

            return false;
        }

        public bool WasButtonJustUp(MouseButton button)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (button)
            {
                case MouseButton.Left:      return WasJustReleased(_leftButtonStateDel);
                case MouseButton.Middle:    return WasJustReleased(_middleButtonStateDel);
                case MouseButton.Right:     return WasJustReleased(_rightButtonStateDel);
                case MouseButton.XButton1:  return WasJustReleased(_xButton1StateDel);
                case MouseButton.XButton2:  return WasJustReleased(_xButton2StateDel);
            }

            return false;
        }

        private bool IsPressed(Func<MouseState, ButtonState> button) => button(_currentMouseState) == ButtonState.Pressed;
        private bool IsReleased(Func<MouseState, ButtonState> button) => button(_currentMouseState) == ButtonState.Released;
        private bool WasJustPressed(Func<MouseState, ButtonState> button) => button(_previousMouseState) == ButtonState.Released && button(_currentMouseState) == ButtonState.Pressed;
        private bool WasJustReleased(Func<MouseState, ButtonState> button) => button(_previousMouseState) == ButtonState.Pressed && button(_currentMouseState) == ButtonState.Released;
    }
}
