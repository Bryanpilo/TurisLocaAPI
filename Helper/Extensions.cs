using Microsoft.AspNetCore.Http;

namespace TurisLocAPI.API.Helper
{
    public static class Extensions
    {
        public static void AddAplicationError(this HttpResponse response, string message){
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}