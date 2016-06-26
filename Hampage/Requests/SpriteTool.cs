using Nancy;

namespace Hampage.Requests
{
    public class SpriteTool : NancyModule
    {
        public SpriteTool()
        {
            Get["/"] = _ => View["spriteTool"];
        }
    }
}
