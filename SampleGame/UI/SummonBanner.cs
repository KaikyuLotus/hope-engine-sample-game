using Android.Graphics;
using HopeEngine.Engine;
using HopeEngine.Engine.Objects;
using HopeEngine.Engine.Objects.Geometrics;
using HopeEngine.Engine.Objects.UI;
using HopeEngine.Engine.Textures;
using HopeEngineSampleGame.SampleGame.StaticComponents;
using OpenTK;

namespace HopeEngineSampleGame.SampleGame.UI
{
    public class SummonBanner : GameObject
    {

        private float _verticalMovementLeft = 0.0f;
        private float _startingMovementLeft = 0.0f;

        public SummonBanner()
        {
            Transform.Position.Y = GameTheme.NavBarHeight + Hope.ScreenSize.Y;
            Transform.Scale.Y = Hope.ScreenSize.Y - GameTheme.NavBarHeight;
            Transform.Scale.X = Hope.ScreenSize.X;
        }

        public override void Update()
        {
            if (_verticalMovementLeft < 0)
            {
                float move = _startingMovementLeft * (float)Hope.FrameTime * GameTheme.AnimationsMultiplier;
                _verticalMovementLeft -= move;
                Transform.Position.Y += move;
            }
            // else if (_verticalMovementLeft < 0)
            // {
            // Transform.Position.Y += _verticalMovementLeft;
            // _verticalMovementLeft = 0;
            //  }
        }

        public void Setup(string bannerName)
        {
            Texture banner1st = Texture.FromResources("HopeEngineSampleGame.Resources.images.ui.banners.banner_1st.png", typeof(SummonBanner));

            Text text = new Text(bannerName)
            {
                FontSize = 23
            };
            text.SetTextHorizontalAlign(TextHorizontalAlignment.CENTER);
            text.SetTextVerticalAlign(TextVerticalAlignment.CENTER);
            text.Prepare(); // TODO elements added after setup cause problems due to prepare not called

            Square bannerImage = new Square(banner1st);
            bannerImage.Transform.Scale.X = 1700;
            bannerImage.Transform.Scale.Y = 800;
            bannerImage.Transform.Position.X = Transform.Scale.X / 2.0f - 1700 / 2.0f;
            bannerImage.Transform.Position.Y = Transform.Scale.Y / 2.0f - 800 / 2.0f;

            float bannerTopMargin = 100;
            float buttonRightMargin = 100;
            float buttonMargin = 100;



            ColoredButton gatcha1x = new ColoredButton("Summon x1", Color.White);
            ColoredButton gatcha11x = new ColoredButton("Summon x10+1", Color.White);

            bannerImage.AddComponents(gatcha1x, gatcha11x);

            gatcha1x.Text.Color = Color.Black;
            gatcha11x.Text.Color = Color.Black;

            gatcha1x.Transform.Scale = new Vector3(300, 150, 0);
            gatcha11x.Transform.Scale = new Vector3(300, 150, 0);

            gatcha11x.Transform.Position.X = bannerImage.Transform.Scale.X - buttonRightMargin;
            gatcha1x.Transform.Position.X = bannerImage.Transform.Scale.X - buttonMargin - buttonRightMargin - 300;

            gatcha1x.Transform.Position.Y = bannerImage.Transform.Position.Y + bannerImage.Transform.Scale.Y - 150;
            gatcha11x.Transform.Position.Y = bannerImage.Transform.Position.Y + bannerImage.Transform.Scale.Y - 150;

            gatcha1x.Text.SetTextVerticalAlign(TextVerticalAlignment.CENTER);
            gatcha1x.Text.SetTextHorizontalAlign(TextHorizontalAlignment.CENTER);
            gatcha11x.Text.SetTextVerticalAlign(TextVerticalAlignment.CENTER);
            gatcha11x.Text.SetTextHorizontalAlign(TextHorizontalAlignment.CENTER);


            _verticalMovementLeft = -Hope.ScreenSize.Y;
            _startingMovementLeft = -Hope.ScreenSize.Y;

            AddComponents(bannerImage, text, gatcha1x, gatcha11x);
        }

    }
}