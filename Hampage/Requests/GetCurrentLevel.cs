using DisruptoLib.Factories;
using Nancy;
using Newtonsoft.Json;

namespace Hampage.Requests
{
    internal class GetCurrentLevel : NancyModule
    {
        public GetCurrentLevel()
        {
            Get["/GetCurrentLevel"] = ReturnCurrentLevel;
        }

        private object ReturnCurrentLevel(dynamic parameters)
        {
            return JsonConvert.SerializeObject(LevelFactory.CurrentLevel);
        }
    }
}
