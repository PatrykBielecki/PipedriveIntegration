using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static PipedriveIntegration.Mapper.OrganizationFromWebconMapper;

namespace PipedriveIntegration.Service
{
    public class PipedriveService : IPipedriveService
    {
        private readonly RestClient _restClient;
        public PipedriveService()
        {
            _restClient = new RestClient("");
        }
        public JObject SendToPipedrive(string body)
        {
            var request = new RestRequest($"", Method.POST);
            request.AddJsonBody(body);
            request.AddHeader("Content-Type", "application/json");
            var response = _restClient.Execute(request);
            return JObject.Parse(response.Content);
        }

        public JObject getAllOrganizations()
        {
            var request = new RestRequest($"", Method.GET);   
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            var response = _restClient.Execute(request);
            return JObject.Parse(response.Content);
        }

    }
}
