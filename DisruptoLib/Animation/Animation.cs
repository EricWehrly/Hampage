using System.Collections.Generic;
using SharpKit.JavaScript;

namespace DisruptoLib.Animation
{
    [JsType(JsMode.Clr, Filename = "../res/Animation.js")]
    public class Animation
    {
        public string Name { get; private set; }

        private List<AnimationFrame> _animationFrames = new List<AnimationFrame>();

        public AnimationFrame CurrentFrame { get { return _animationFrames[0]; } }

        protected internal Animation(string name)
        {
            Name = name;
        }

        protected internal void AddAnimationFrame(string source)
        {
            _animationFrames.Add(new AnimationFrame(source));
        }
    }
}
