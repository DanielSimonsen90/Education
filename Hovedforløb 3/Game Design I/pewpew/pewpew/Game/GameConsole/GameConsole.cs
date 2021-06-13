using System;

namespace pewpew
{
    public class GameConsole : IGameConsole
    {
        #region Properties
        public Position TopLeft => new(1, 1);
        public Position TopRight => new(Console.WindowWidth - 1, 1);
        public Position BottomLeft => new(1, Console.WindowHeight - 3);
        public Position BottomRight => new(Console.WindowWidth - 1, Console.WindowHeight - 3);
        public Position Center => new((TopRight.X - TopLeft.X) / 2, (BottomRight.Y - TopRight.Y) / 2);
        #endregion

        public GameConsole()
        {
            Console.SetWindowSize(150, 30);
            Console.CursorVisible = false;
        }

        public void CenterText(string text, int heightOffset = 0)
        {
            var center = new Position(text.Length / 2 - Center.X, Center.Y + heightOffset);
            SetPosition(center, text);
        }

        #region SetPosition(pos: GameConsolePositions | Position, text/c?: string/char
        //No 2nd argument
        public void SetPosition(GameConsolePositions pos) => SetPosition(GetPosition(pos));
        public void SetPosition(Position pos) => Console.SetCursorPosition(pos.X, pos.Y);
        
        //char support
        public void SetPosition(GameConsolePositions position, char c) => SetPosition(position, c.ToString());
        public void SetPosition(Position pos, char c) => SetPosition(pos, c.ToString());
        
        //string support
        public void SetPosition(GameConsolePositions position, string text) => SetPosition(GetPosition(position), text);
        public void SetPosition(Position pos, string text)
        {
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write(text);
        }

        private Position GetPosition(GameConsolePositions position) => position switch
        {
            GameConsolePositions.TopLeft => TopLeft,
            GameConsolePositions.TopRight => TopRight,
            GameConsolePositions.BottomLeft => BottomLeft,
            GameConsolePositions.BottomRight => BottomRight,
            GameConsolePositions.Center => Center,
            _ => null,
        };
        #endregion
    }
}
