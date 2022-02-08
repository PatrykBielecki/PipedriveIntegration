using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipedriveIntegration.DTO.Exceptions
{
    public class WebconException : AppException
    {
        public override string ErrorCode => "webcon_error";
        public WebconException(IRestResponse response)
            : base($"Błąd zapytania response={response.StatusCode} " +
                    $"body={response.Content} " +
                    $"success={response.IsSuccessful} " +
                    $"request={JsonConvert.SerializeObject(response.Request.Body)} " +
                    $"Error Message={response.ErrorMessage}")
        {

        }
    }
}
