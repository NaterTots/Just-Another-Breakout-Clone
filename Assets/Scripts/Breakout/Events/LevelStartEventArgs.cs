
class LevelStartEventArgs : IEventArgs
{
    private Level _level;
    public Level Level
    {
        get
        {
            return _level;
        }
    }
    public LevelStartEventArgs(Level level)
    {
        _level = level;
    }
}

