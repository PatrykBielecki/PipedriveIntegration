using Newtonsoft.Json.Linq;

namespace PipedriveIntegration.Service
{
    public interface IWebconService
    {
        JObject GetElemenmt(int wfd_id);
        string StartElement(string path, string json = null);
    }
}