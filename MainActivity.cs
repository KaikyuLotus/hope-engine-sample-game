using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using HopeEngine.Engine;
using HopeEngine.Engine.Scenes;
using HopeEngineSampleGame.SampleGame.Entities;
using HopeEngineSampleGame.SampleGame.Scenes;
using HopeEngineSampleGame.SampleGame.StaticComponents;
using HopeEngineSampleGame.SampleGame.UI;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace HopeEngineSampleGame
{
    [Activity(Label = "OpenGLDemo.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, WindowSoftInputMode = SoftInput.AdjustPan, ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : FormsApplicationActivity
    {

        public HopeEngineView EngineView { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Window.Attributes.LayoutInDisplayCutoutMode = LayoutInDisplayCutoutMode.ShortEdges;
            Window.AddFlags(WindowManagerFlags.Fullscreen | WindowManagerFlags.TranslucentStatus);

            Forms.Init(this, bundle);

            Scene scene = new MainScene();

            EngineView = new HopeEngineView(this, scene);

            EngineView.OnReady += () =>
            {
                Components.FPSCounter = new FPSCounter();
                StaticEntities.Player = new Player("Kaikyu", 7408, 53, 1230, 69); // TODO get this from API
            };
            SetContentView(EngineView);

        }

    }
}