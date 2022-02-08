using Newtonsoft.Json.Linq;
using PipedriveIntegration.DTO;
using System.Collections.Generic;
using static PipedriveIntegration.Mapper.OrganizationFromWebconMapper;

namespace PipedriveIntegration.Mapper
{
    public interface IOrganizationFromWebconMapper
    {
        Organization mapOrganizationFromWebcon(JObject webconElement);
        string mapOrganizationFromPipedrive(Organization organization);
    }
}