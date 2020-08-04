using HopeEngine.Engine;
using HopeEngine.Engine.Objects.UI;
using HopeEngine.Engine.Scenes;
using HopeEngine.Engine.Textures;
using HopeEngineSampleGame.SampleGame.StaticComponents;
using HopeEngineSampleGame.SampleGame.UI;

namespace HopeEngineSampleGame.SampleGame.Scenes
{
    public class FightScene : Scene
    {
        public override void Setup()
        {
            Texture bgTexture = Texture.FromResources("HopeEngineSampleGame.Resources.images.home-bg.jpg", typeof(MainScene));
            SceneBackground sceneBackground = new SceneBackground(bgTexture);
            Footer footer = new Footer();

            Texture buttonTexture = Texture.FromResources("HopeEngineSampleGame.Resources.images.ui.home_button.png", typeof(FightScene));

            Button backButton = new Button("Not supported yet, click to go back", buttonTexture);
            backButton.Transform.Scale.X = Hope.ScreenSize.X;
            backButton.Transform.Scale.Y = 200.0f;
            backButton.OnClick += () => Hope.EngineView.ChangeScene(new MainScene());
            // backButton.BackgroundColor = new Color(0, 0, 0, 125);
            backButton.Transform.Position.Y = Hope.ScreenSize.Y / 2.0f - 100.0f;
            // backButton.BorderWidth = new Vector4(0, 0.005f, 0, 0.005f);
            // backButton.BorderColor = Color.White;
            backButton.Text.SetTextHorizontalAlign(TextHorizontalAlignment.CENTER);
            backButton.Text.SetTextVerticalAlign(TextVerticalAlignment.CENTER);

            AddGameObjects(sceneBackground, Components.FPSCounter, footer, backButton);
        }
    }
}