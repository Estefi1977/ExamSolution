using Microsoft.Web.Administration;
using Newtonsoft.Json;
using PriceCalculatorService.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PriceCalculatorService.Clients
{
    public class FindBargainClient : IFindBargainClient
    {
        public async Task<List<BargainItemDTO>> Query(int DestinationId, int NumberOfNights)
        {
            //Configuration parameters
            var builder = new ConfigurationBuilder().SetBasePath(System.AppContext.BaseDirectory).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();

            var serviceURL = configuration.GetSection("serviceURL").Value;
            var serviceCode = configuration.GetSection("serviceCode").Value;
            //
            var serializer = new DataContractJsonSerializer(typeof(List<BargainItemDTO>));
            var httpClient = new HttpClient();

            httpClient.Timeout = TimeSpan.FromSeconds(1);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string url = $"{serviceURL}findBargain?destinationId={DestinationId}&nights={NumberOfNights}&code={serviceCode}";
            
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

            List<BargainItemDTO> responseList = new List<BargainItemDTO>();

            try
            {
                HttpResponseMessage response = httpClient.SendAsync(request).Result;

                if (response.IsSuccessStatusCode)
                {
                    var streamTask = response.Content.ReadAsStreamAsync();

                    responseList = serializer.ReadObject(await streamTask) as List<BargainItemDTO>;
                }
            }

            catch (Exception ex) {

                throw ex;
            }

            return responseList;

        }
    }
}
