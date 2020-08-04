using HopeEngine.Engine;
using HopeEngine.Engine.Objects;
using HopeEngine.Engine.Objects.UI;
using HopeEngine.Engine.Textures;
using HopeEngineSampleGame.SampleGame.StaticComponents;
using System;
using System.Collections.Generic;

namespace HopeEngineSampleGame.SampleGame.UI
{
    public class HorizontalBannerScroller : GameObject
    {

        private float _lastPosition = 0.0f;

        private float _scrollerCardStartX;

        private float _scrollerCardLine;

        private float _leftInertia = 0.0f;

        private float _lastDiff = 0.0f;

        private float _verticalMovementLeft = 0.0f;
        private float _startingMerticalMovementLeft = 0.0f;

        private bool _moved = false;

        private float _diffLimit = 10.0f;

        private float _inertia = 10.0f;

        public HorizontalBannerScroller(List<string> bannerNames) // TODO a more elaborated way will be used
        {

            Texture banner1st = Texture.FromResources("HopeEngineSampleGame.Resources.images.ui.banners.banner_1st.png", typeof(HorizontalBannerScroller));

            Transform.Position.Y = GameTheme.NavBarHeight;
            Transform.Scale.Y = Hope.ScreenSize.Y - GameTheme.NavBarHeight;
            Transform.Scale.X = Hope.ScreenSize.X;

            _scrollerCardStartX = Transform.Scale.X / 2.0f - GameTheme.CardWidth / 2.0f;

            _scrollerCardLine = Transform.Scale.Y / 2.0f - GameTheme.CardHeight / 2.0f;

            int index = 0;
            foreach (string bannerName in bannerNames)
            {

                Action bannerClickEvent = () =>
                {
                    if (_moved) return;
                    _verticalMovementLeft = -Hope.ScreenSize.Y;
                    _startingMerticalMovementLeft = -Hope.ScreenSize.Y;
                    SummonBanner summonBanner = (SummonBanner)Hope.EngineView.Scene.FindGameObjects((obj) => obj is SummonBanner)[0];
                    summonBanner.Setup(bannerName);

                };

                Button coloredSquare = new HopeEngine.Engine.Objects.UI.Button(" ", banner1st);  // TODO button without text
                AddComponents(coloredSquare);

                coloredSquare.Transform.Scale.X = GameTheme.CardWidth;
                coloredSquare.Transform.Scale.Y = GameTheme.CardHeight;
                coloredSquare.Transform.Position.Y = _scrollerCardLine;
                coloredSquare.Transform.Position.X = _scrollerCardStartX + ((GameTheme.CardWidth + GameTheme.CardMargin) * index);
                coloredSquare.Text.SetTextHorizontalAlign(TextHorizontalAlignment.CENTER);
                coloredSquare.Text.SetTextVerticalAlign(TextVerticalAlignment.CENTER);
                coloredSquare.OnClick += bannerClickEvent;



                index++;
            }

        }

        private void MoveComponents(float move)
        {
            if (move < 0 && ((GameObject)Components[0]).Transform.Position.X > _scrollerCardStartX)
            {
                return;
            }

            if (move > 0 && ((GameObject)Components[Components.Count - 1]).Transform.Position.X < _scrollerCardStartX)
            {
                return;
            }

            foreach (GameObject card in Components)
            {
                card.Transform.Position.X -= move;
            }

            /* if (move < 0 && ((GameObject)Components[0]).Transform.Position.X > _scrollerCardStartX)
             {
                 MoveComponents(((GameObject)Components[0]).Transform.Position.X - _scrollerCardStartX);
                 return;
             }

             if (move > 0 && ((GameObject)Components[Components.Count - 1]).Transform.Position.X < _scrollerCardStartX)
             {
                 MoveComponents(((GameObject)Components[Components.Count - 1]).Transform.Position.X - _scrollerCardStartX);
                 return;
             }*/

        }

        public override void Update()
        {
            if (_verticalMovementLeft < 0)
            {
                float move = _startingMerticalMovementLeft * (float)Hope.FrameTime * GameTheme.AnimationsMultiplier;
                _verticalMovementLeft -= move;
                Transform.Position.Y += move;
            }
            if (_leftInertia < -1 || _leftInertia > 1)
            {
                float frameInertiaMove = _leftInertia * (float)Hope.FrameTime;
                _leftInertia -= frameInertiaMove;
                MoveComponents(frameInertiaMove);
            }

            // if (_verticalMovementLeft < 0)
            // {
            //  Transform.Position.Y += _verticalMovementLeft;
            //  _verticalMovementLeft = 0;
            // }

            // if (_leftInertia < 0)
            // {
            // MoveComponents(_leftInertia);
            // _leftInertia = 0;
            // }
        }

        public override void OnFingerDown(float x, float y)
        {
            _moved = false;
            _leftInertia = 0.0f;
            _lastPosition = x;
        }

        public override void OnFingerUp(float x, float y)
        {
            /*if (_lastDiff > 200 || _lastDiff < -200)
            {
                _lastDiff = 200 * (_lastDiff > 0 ? 1 : -1);
            }*/
            _leftInertia = _inertia * _lastDiff;
        }

        public override void OnFingerMove(float x, float y)
        {
            _moved = true;
            float diff = _lastPosition - x;

            MoveComponents(diff);
            _lastPosition = x;
            _lastDiff = diff;
        }


    }
}