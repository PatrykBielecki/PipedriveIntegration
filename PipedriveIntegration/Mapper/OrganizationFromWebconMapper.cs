using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PipedriveIntegration.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PipedriveIntegration.Mapper
{
    public class OrganizationFromWebconMapper : IOrganizationFromWebconMapper
    {
        private readonly WebconMapping _webconMapping;

        public OrganizationFromWebconMapper(WebconMapping webconMapping)
        {
            _webconMapping = webconMapping;
        }
        public Organization mapOrganizationFromWebcon(JObject webconElement)
        {
            var organization = new Organization();

            organization.name = webconElement["formFields"].ToList().Where(e => e["guid"].ToString() == _webconMapping.guids.nazwa).Select(e => e["value"]).FirstOrDefault().ToString();
            organization.nip = webconElement["formFields"].ToList().Where(e => e["guid"].ToString() == _webconMapping.guids.nip).Select(e => e["value"]).FirstOrDefault().ToString();
            organization.adres = webconElement["formFields"].ToList().Where(e => e["guid"].ToString() == _webconMapping.guids.adres).Select(e => e["value"]).FirstOrDefault().ToString();
            organization.miejscowosc = webconElement["formFields"].ToList().Where(e => e["guid"].ToString() == _webconMapping.guids.miejscowosc).Select(e => e["value"]).FirstOrDefault().ToString();
            organization.kodPocztowy = webconElement["formFields"].ToList().Where(e => e["guid"].ToString() == _webconMapping.guids.kodPocztowy).Select(e => e["value"]).FirstOrDefault().ToString();
            organization.REGON = webconElement["formFields"].ToList().Where(e => e["guid"].ToString() == _webconMapping.guids.REGON).Select(e => e["value"]).FirstOrDefault().ToString();

            return organization;
        }

        public string mapOrganizationFromPipedrive(Organization organization)
        {
            var result = new StringBuilder();
            result.Append("{");
            result.Append($"\"{PipedriveOrganization.name}\" : \"{organization.name}\",");
            result.Append($"\"{PipedriveOrganization.nip}\" : \"{organization.nip}\",");
            result.Append($"\"{PipedriveOrganization.adres}\" : \"{organization.adres}\",");
            result.Append($"\"{PipedriveOrganization.miejscowosc}\" : \"{organization.miejscowosc}\",");
            result.Append($"\"{PipedriveOrganization.kodPocztowy}\" : \"{organization.kodPocztowy}\",");
            result.Append($"\"{PipedriveOrganization.REGON}\" : \"{organization.REGON}\"");
            result.Append("}");

            return result.ToString();

        }
    }
}
