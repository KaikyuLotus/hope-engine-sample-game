using HopeEngine.Engine;
using HopeEngine.Engine.Objects.Geometrics;
using HopeEngine.Engine.Objects.UI;
using HopeEngineSampleGame.SampleGame.StaticComponents;

namespace HopeEngineSampleGame.SampleGame.UI
{
    public class NavBar : ColoredSquare
    {

        private ColoredSquare expBar;

        public override void Update()
        {
            StaticEntities.Player.Exp += (int)(5000 * (float)Hope.FrameTime);
            int neededExp = 100345;
            float expPercentage = StaticEntities.Player.Exp / (float)neededExp * 100.0f;

            float expBarWidth = Hope.ScreenSize.X / 100.0f * expPercentage;
            expBar.Transform.Scale.X = expBarWidth;
        }

        public NavBar() : base(GameTheme.NavBarBgColor)
        {

            int fontSize = 17;
            int labelFontSize = 15;
            int labelTextSize = 16;

            int neededExp = 100345;
            float expPercentage = StaticEntities.Player.Exp / (float)neededExp * 100.0f;

            float expBarWidth = Hope.ScreenSize.X / 100.0f * expPercentage;

            Transform.Scale.Y = GameTheme.NavBarHeight;
            Transform.Scale.X = Hope.ScreenSize.X;

            Text username = new Text(StaticEntities.Player.Name)
            {
                FontSize = fontSize
            }; // TODO dynamic username
            username.Transform.Position.X += GameTheme.MarginLeft;
            username.SetTextVerticalAlign(TextVerticalAlignment.CENTER);

            Text userLevel = new Text($"lv{StaticEntities.Player.Level}")
            {
                FontSize = fontSize
            };
            userLevel.SetTextVerticalAlign(TextVerticalAlignment.CENTER);
            userLevel.Transform.Position.X = username.Transform.Position.X + username.Width + 20;

            expBar = new ColoredSquare(GameTheme.ExpBarColor);
            expBar.Transform.Scale.Y = GameTheme.ExpLineHeight;
            expBar.Transform.Scale.X = expBarWidth;
            expBar.Transform.Position.Y = GameTheme.NavBarHeight; // - _expBarHeight;

            Text coinsLabel = new Text("coins")
            {
                FontSize = labelFontSize
            };
            coinsLabel.SetTextVerticalAlign(TextVerticalAlignment.CENTER);
            coinsLabel.Transform.Position.X = Hope.ScreenSize.X - GameTheme.MarginLeft - StaticComponents.Components.FPSCounter.Width - 60 - coinsLabel.Width;

            Text coinsText = new Text(StaticEntities.Player.Coins.ToString())
            {
                FontSize = labelTextSize
            };
            coinsText.SetTextVerticalAlign(TextVerticalAlignment.CENTER);
            coinsText.Transform.Position.X = coinsLabel.Transform.Position.X - 10 - coinsText.Width;

            Text gemsLabel = new Text("gems")
            {
                FontSize = labelFontSize
            };
            gemsLabel.SetTextVerticalAlign(TextVerticalAlignment.CENTER);
            gemsLabel.Transform.Position.X = coinsText.Transform.Position.X - 60 - gemsLabel.Width;

            Text gemsText = new Text(StaticEntities.Player.Gems.ToString())
            {
                FontSize = labelTextSize
            };
            gemsText.SetTextVerticalAlign(TextVerticalAlignment.CENTER);
            gemsText.Transform.Position.X = gemsLabel.Transform.Position.X - 10 - gemsText.Width;

            AddComponents(username, userLevel, expBar, coinsLabel, coinsText, gemsLabel, gemsText, StaticComponents.Components.FPSCounter);

        }
    }
}