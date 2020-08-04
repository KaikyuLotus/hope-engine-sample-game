using Android.Graphics;
using HopeEngine.Engine;
using HopeEngine.Engine.Objects.Geometrics;
using HopeEngine.Engine.Objects.UI;
using HopeEngine.Engine.Textures;
using HopeEngineSampleGame.SampleGame.Scenes;
using OpenTK;

namespace HopeEngineSampleGame.SampleGame.UI
{
    public class RightHomeNavbar : ColoredSquare
    {

        private static readonly Color _bgColor = new Color(0, 0, 0, 0);

        public RightHomeNavbar() : base(_bgColor)
        {
            // BorderColor = Color.White;
            // BorderWidth = new Vector4(0.005f, 0, 0, 0);
            Transform.Scale = new Vector3(600, Hope.ScreenSize.Y, 0);
            Transform.Position = new Vector3(Hope.ScreenSize.X - 600, 0, 0);

            Texture buttonTexture = Texture.FromResources("HopeEngineSampleGame.Resources.images.ui.home_button.png", typeof(RightHomeNavbar));

            Button summonButton = new RightNavbarButton("Summon", buttonTexture, new Vector3(Transform.Scale.X - 500, 300, 0));
            summonButton.OnClick += () => Hope.EngineView.ChangeScene(new SummonScene());
            Button fightButton = new RightNavbarButton("Collection", buttonTexture, new Vector3(Transform.Scale.X - 500, 600, 0));
            fightButton.OnClick += () => Hope.EngineView.ChangeScene(new CollectionScene());
            AddComponents(fightButton, summonButton);

        }

    }
}