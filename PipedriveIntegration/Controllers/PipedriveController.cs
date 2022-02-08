using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PipedriveIntegration.DTO;
using PipedriveIntegration.Mapper;
using PipedriveIntegration.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipedriveIntegration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PipedriveController : ControllerBase
    {
        private readonly IPipedriveService _pipedriveService;
        private readonly IWebconService _webconService;
        private readonly IOrganizationFromWebconMapper _organizationFromWebconMapper;
        private readonly WebconMapping _webconMapping;

        public PipedriveController(IPipedriveService pipedriveService, IWebconService webconService, IOrganizationFromWebconMapper organizationFromWebconMapper, WebconMapping webconMapping)
        {
            _pipedriveService = pipedriveService;
            _webconService = webconService;
            _organizationFromWebconMapper = organizationFromWebconMapper;
            _webconMapping = webconMapping;
        }

        [HttpPost("SendToPipedrive/{wfdID}")]
        public IActionResult SendToPipedrive(int wfdID)
        {
            var webconElement = _webconService.GetElemenmt(wfdID);
            var organization = _organizationFromWebconMapper.mapOrganizationFromWebcon(webconElement);
            var pipedriveOrganization = _organizationFromWebconMapper.mapOrganizationFromPipedrive(organization);
            _pipedriveService.SendToPipedrive(pipedriveOrganization);
            return Ok();
        }


        [HttpPost("SendToWebcon")]
        public IActionResult AddToWebcon([FromBody] JObject body)
        {
            var organization = new Organization()
            {
                name = body["data"][$"{PipedriveOrganization.name}"].ToString(),
                nip = body["data"][$"{PipedriveOrganization.nip}"].ToString(),
                adres = body["data"][$"{PipedriveOrganization.adres}"].ToString()
            };

            var webconElement = new WebconElement()
            {
                workflow = new Workflow() { Guid = new Guid(_webconMapping.guids.workflow) },
                formType = new FormType() { Guid = new Guid(_webconMapping.guids.formType) }
            };

            var json = JsonConvert.SerializeObject(webconElement);

            _webconService.StartElement(_webconMapping.guids.path, json);
            return Ok();
        }
    }
}
