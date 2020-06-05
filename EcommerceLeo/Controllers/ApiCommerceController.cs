using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using EcommerceLeo.Web.Models;
using Newtonsoft.Json;

namespace EcommerceLeo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCommerceController : ControllerBase
    {
        [HttpGet("EnderecoRes/{zipcode}")]
        public async Task<IActionResult> EnderecoResidencial(string zipcode)
        {
            try
            {
                var client = new RestSharp.RestClient("https://viacep.com.br");
                var request = new RestRequest("/ws/" + zipcode + "/json", Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.RequestFormat = DataFormat.Json;

                IRestResponse<List<EnderecoRes>> response = await client.ExecuteTaskAsync<List<EnderecoRes>>(request);

                //se retornar com sucesso busca os dados
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    ErrorRest error = JsonConvert.DeserializeObject<ErrorRest>(response.Content);
                    throw new Exception(response.StatusCode.ToString() + ": " + error.Message);
                }

                return Ok(response.Data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}