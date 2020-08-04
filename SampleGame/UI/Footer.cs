using Android.Graphics;
using HopeEngine.Engine;
using HopeEngine.Engine.Objects.Geometrics;
using HopeEngine.Engine.Objects.UI;

namespace HopeEngineSampleGame.SampleGame.UI
{
    public class Footer : ColoredSquare
    {

        private static readonly float _height = 50;

        private static readonly Color _bgColor = new Color(0, 0, 0, 125);

        private static readonly string _copyrightText = "Copyright Kaikyu 2020";

        private static readonly string _title = "Hope Engine";

        private static readonly int _margin = 100;

        public Footer() : base(_bgColor)
        {
            Transform.Scale.Y = _height;
            Transform.Scale.X = Hope.ScreenSize.X;
            Transform.Position.Y = Hope.ScreenSize.Y - _height;

            Text copyrightText = new Text(_copyrightText)
            {
                FontSize = 13
            };
            copyrightText.Transform.Position.X += _margin;
            copyrightText.Transform.Position.Y += 10;

            Text titleText = new Text(_title)
            {
                FontSize = 13
            };
            titleText.SetTextHorizontalAlign(TextHorizontalAlignment.RIGHT);
            titleText.Transform.Position.X = Hope.ScreenSize.X - _margin;
            titleText.Transform.Position.Y += 10;

            AddComponents(copyrightText, titleText);

        }

    }
}