namespace Game.Core.GamePaths
{
    public static class GamePaths
    {
        public static string _screenShotPath { get; private set; }

        public static void SetScreenShotPath(string path)
        {
            _screenShotPath = path;
        }
    }
}