using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using static PipedriveIntegration.Mapper.OrganizationFromWebconMapper;

namespace PipedriveIntegration.Service
{
    public interface IPipedriveService
    {
        JObject getAllOrganizations();
        JObject SendToPipedrive(string body);
    }
}