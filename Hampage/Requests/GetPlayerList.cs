using Nancy;
using Newtonsoft.Json;
using DisruptoLib.Factories;

namespace Hampage.Requests
{
    public class GetPlayerList : NancyModule
    {
        public GetPlayerList()
        {
            Get["/GetPlayerList"] = ReturnPlayerList;
        }

        private object ReturnPlayerList(dynamic parameters)
        {
            return JsonConvert.SerializeObject(CharacterFactory.Players);
        }
    }
}
