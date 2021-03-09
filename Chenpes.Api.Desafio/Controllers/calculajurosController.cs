using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Chenpes.Api.Desafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class calculajurosController : ControllerBase
    {
        [HttpGet()]
        [SwaggerResponse(HttpStatusCode.OK, typeof(string))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<double> Get(double valor, int meses)
        {
            string Uri = Properties.ResourceBase.UriBase; ;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(@Uri);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "relativeAddress");
                request.Content = new StringContent("", Encoding.UTF8, "application/json");
                using (var response = await client.GetAsync(@Uri))
                {
                    var jrs = await response.Content.ReadAsStringAsync();
                    NumberFormatInfo provider = new NumberFormatInfo();
                    provider.NumberDecimalSeparator = ".";
                    double juros = Math.Pow(Convert.ToDouble(jrs, provider), meses) + 1;
                    double result = valor * juros;
                    return TruncarValor(result);
                }
            }
        }

        private double TruncarValor(double val)
        {
            double integralValue = Math.Truncate(val);
            double fraction = val - integralValue;
            double factor = (double)Math.Pow(val, 2);
            double truncatedFraction = Math.Truncate(fraction * factor) / factor;
            return integralValue + truncatedFraction;
        }
    }
}
