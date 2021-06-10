namespace pewpew
{
    public class Hitbox
    {
        public Position TopLeft { get; set; }
        public Position BottomRight { get; set; }

        public int Width => BottomRight.X - TopLeft.X;
        public int Height => BottomRight.Y - TopLeft.Y;

        public Hitbox(Position bottomLeft, Position topRight)
        {
            TopLeft = bottomLeft;
            BottomRight = topRight;
        }

        public bool Includes(Position position) =>
            BottomRight.X > position.X && TopLeft.X < position.X &&
            BottomRight.Y > position.Y && TopLeft.Y < position.Y;
    }
}
