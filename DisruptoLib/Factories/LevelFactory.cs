using DisruptoLib.Entities;

namespace DisruptoLib.Factories
{
    public class LevelFactory
    {
        private static Level _currentLevel;

        public static Level CurrentLevel { get { return _currentLevel; } set { _currentLevel = value; } }
    }
}
