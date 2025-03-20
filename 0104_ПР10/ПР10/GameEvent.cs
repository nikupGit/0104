using System;


namespace ПР10
{
    public class GameEvent
    {
        public event EventHandler<OutOfBoundsEventArgs> OutOfBounds;

        public void OnOutOfBounds(object sender, int x, int y)
        {
            OutOfBounds?.Invoke(sender, new OutOfBoundsEventArgs(x, y));
        }
    }
}