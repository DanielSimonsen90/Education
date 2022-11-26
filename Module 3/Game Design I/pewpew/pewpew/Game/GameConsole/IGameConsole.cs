namespace pewpew
{
    public interface IGameConsole
    {
        public Position TopLeft { get; }
        public Position TopRight { get; }
        public Position BottomLeft { get; }
        public Position BottomRight { get; }
        public Position Center { get; }
    }
}
