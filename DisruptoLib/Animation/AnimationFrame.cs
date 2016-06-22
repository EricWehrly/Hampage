using SharpKit.JavaScript;

namespace DisruptoLib.Animation
{
    [JsType(JsMode.Clr, Filename = "../res/Animation.js")]
    public class AnimationFrame
    {
        public string Source { get; private set; }

        protected internal AnimationFrame(string imageSrc)
        {
            Source = imageSrc;
        }
    }
}
