using System;


public class OutOfBoundsEventArgs : EventArgs
{
    public int X { get; }
    public int Y { get; }

    public OutOfBoundsEventArgs(int x, int y)
    {
        X = x;
        Y = y;
    }
}