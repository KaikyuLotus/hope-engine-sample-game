using HopeEngine.Engine;
using HopeEngine.Engine.Objects.Geometrics;
using HopeEngine.Engine.Textures;
using OpenTK;

namespace HopeEngineSampleGame.SampleGame.UI
{
    public class SceneBackground : Square
    {

        public SceneBackground(Texture texture) : base(texture)
        {
            float ratio = texture.Height / texture.Width;
            float newHeight = (Hope.ScreenSize.X * ratio);

            float halfHeightDiff = (newHeight - texture.Height) / 2;

            Transform.Scale = new Vector3(Hope.ScreenSize.X, newHeight, 0);
            Transform.Position = new Vector3(0, -halfHeightDiff, 0);
        }

    }
}