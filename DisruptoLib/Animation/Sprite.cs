using System.Collections.Generic;
using SharpKit.JavaScript;

namespace DisruptoLib.Animation
{
    [JsType(JsMode.Clr, Filename = "../res/Animation.js")]
    public class Sprite
    {
        private List<Animation> _animations = new List<Animation>();

        public Animation CurrentAnimation { get { return _animations[0]; } }

        public void AddAnimation(string animationName, string animationFrame)
        {
            Animation animation = new Animation(animationName);

            animation.AddAnimationFrame(animationFrame);

            _animations.Add(animation);
        }
    }
}
