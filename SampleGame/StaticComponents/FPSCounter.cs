using HopeEngine.Engine;
using HopeEngine.Engine.Objects.UI;
using HopeEngineSampleGame.SampleGame.StaticComponents;

namespace HopeEngineSampleGame.SampleGame.UI
{
    public class FPSCounter : Text
    {

        private int counted = 0;

        private float elapsedSeconds = 0.0f;

        public FPSCounter() : base("60 FPS")
        {
            Transform.Position.X = Hope.ScreenSize.X - GameTheme.MarginRight;
            FontSize = 17;
            SetTextHorizontalAlign(TextHorizontalAlignment.RIGHT);
            SetTextVerticalAlign(TextVerticalAlignment.CENTER);
        }

        public override void Update()
        {
            counted++;
            elapsedSeconds += (float)Hope.FrameTime;

            if (elapsedSeconds >= 1.0f)
            {
                if (elapsedSeconds != 1.0f)
                {
                    counted--;
                }
                SetText($"{counted} FPS");
                elapsedSeconds = 0;
                counted = 0;
            }
        }

    }
}

