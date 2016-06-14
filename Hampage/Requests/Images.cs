using Nancy;

namespace Hampage.Requests
{
    public class Images : NancyModule
    {
        public Images()
        {
            Get["/images/{filename}"] = FetchImage;
        }

        private Response FetchImage(dynamic parameters)
        {
            string filePath = "images/" + parameters.filename;

            return Response.AsFile(filePath, "text/javascript");
        }
    }
}
