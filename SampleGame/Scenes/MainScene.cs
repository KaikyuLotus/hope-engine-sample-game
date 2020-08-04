using HopeEngine.Engine.Scenes;
using HopeEngine.Engine.Textures;
using HopeEngineSampleGame.SampleGame.UI;


namespace HopeEngineSampleGame.SampleGame.Scenes
{
    public class MainScene : Scene
    {
        public override void Setup()
        {

            Texture bgTexture = Texture.FromResources("HopeEngineSampleGame.Resources.images.home-bg.jpg", typeof(MainScene));
            Texture secretaryTexture = Texture.FromResources("HopeEngineSampleGame.Resources.images.waifus.fubuki.fubuki.png", typeof(MainScene));

            SceneBackground sceneBackground = new SceneBackground(bgTexture);
            Secretary secretary = new Secretary(secretaryTexture);

            NavBar navbar = new NavBar();

            RightHomeNavbar rightHomeNavbar = new RightHomeNavbar();

            AddGameObjects(sceneBackground, rightHomeNavbar, secretary, navbar);
        }

    }
}
