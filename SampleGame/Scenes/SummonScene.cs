using HopeEngine.Engine.Scenes;
using HopeEngine.Engine.Textures;
using HopeEngineSampleGame.SampleGame.StaticComponents;
using HopeEngineSampleGame.SampleGame.UI;
using System.Collections.Generic;

namespace HopeEngineSampleGame.SampleGame.Scenes
{
    public class SummonScene : Scene
    {
        public override void Setup()
        {
            Texture bgTexture = Texture.FromResources("HopeEngineSampleGame.Resources.images.summon-bg.jpg", typeof(MainScene));
            SceneBackground sceneBackground = new SceneBackground(bgTexture);

            NavBar navbar = new NavBar();

            HorizontalBannerScroller bannerScroller = new HorizontalBannerScroller(new List<string>() { "Banner 1", "Banner 2", "Banner 3" });

            SummonBanner banner = new SummonBanner();

            AddGameObjects(sceneBackground, Components.FPSCounter, navbar, bannerScroller, banner);
        }
    }
}