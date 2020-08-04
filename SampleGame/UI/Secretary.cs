using HopeEngine.Engine;
using HopeEngine.Engine.Objects.Geometrics;
using HopeEngine.Engine.Textures;
using OpenTK;
using System;

namespace HopeEngineSampleGame.SampleGame.UI
{
    class Secretary : Square
    {

        private Vector3 _startingPosition;

        private float multiplier = 1.0f;

        public Secretary(Texture texture) : base(texture)
        {
            float targetWaifuHeight = Hope.ScreenSize.Y * 1.2f;
            float waifuRatio = texture.Width / texture.Height;
            float newWaifuWidth = targetWaifuHeight * waifuRatio;

            Transform.Scale = new Vector3(newWaifuWidth, targetWaifuHeight, 0);
            Transform.Position.Y = Hope.ScreenSize.Y - targetWaifuHeight + 350;
            Transform.Position.X = Hope.ScreenSize.X / 10;
            _startingPosition = Transform.Position;
        }

        public override void Update()
        {
            Transform.Position.Y -= 30.0f * (float)Hope.FrameTime * multiplier;
            if (Math.Abs(Transform.Position.Y - _startingPosition.Y) > 50f)
            {
                _startingPosition.Y = Transform.Position.Y;
                multiplier *= -1;
            }
        }

    }
}