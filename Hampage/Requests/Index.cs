using Nancy;

namespace Hampage.Requests
{
    public class Index : NancyModule
    {
        public Index()
        {
            // Get["/"] = BuildIndexPage;
            Get["/"] = _ => View["index"];
        }

        private object BuildIndexPage(dynamic parameters)
        {
            /*
            return new Response
            {
                StatusCode = HttpStatusCode.OK
            };
            */
            return "<body><script type=\"text\\javascript\">alert('sup');</script>Hi.</body>";
        } 
    }
}
