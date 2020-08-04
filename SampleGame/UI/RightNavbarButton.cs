using HopeEngine.Engine.Objects.UI;
using HopeEngine.Engine.Textures;
using OpenTK;

namespace HopeEngineSampleGame.SampleGame.UI
{
    public class RightNavbarButton : Button
    {

        bool isPressed = false;

        public RightNavbarButton(string text, Texture texture, Vector3 position) : base(text, texture)
        {
            // BackgroundColor = new Color(0, 0, 0, 125);
            // BorderColor = Color.White;
            // BorderWidth = new Vector4(0.005f, 0.005f, 0, 0.005f);
            Transform.Scale = new Vector3(texture.Width, texture.Height, 0);
            Transform.Position = position;

            Text.FontSize = 32;
            Text.Transform.Position.X += 50.0f;
            Text.SetTextVerticalAlign(TextVerticalAlignment.CENTER);
            Text.SetTextHorizontalAlign(TextHorizontalAlignment.LEFT);
        }

        public override void OnFingerDown(float x, float y)
        {
            base.OnFingerDown(x, y);
            if (Transform.IsInside2D(x, y))
            {
                // BackgroundColor = new Color(125, 125, 125, 125);
                isPressed = true;
            }
        }

        public override void OnFingerUp(float x, float y)
        {
            base.OnFingerUp(x, y);
            if (isPressed)
            {
                // BackgroundColor = new Color(0, 0, 0, 125);
            }
        }

    }
}