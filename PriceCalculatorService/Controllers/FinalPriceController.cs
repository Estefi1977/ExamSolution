using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PriceCalculatorService.Clients;
using PriceCalculatorService.DTOs;
using PriceCalculatorService.Services;

namespace PriceCalculatorService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinalPriceController : ControllerBase
    {
        private readonly ILogger<FinalPriceController> _logger;
        private readonly IFinalPriceService _finalPriceService;

        public FinalPriceController(ILogger<FinalPriceController> logger, IFinalPriceService finalPriceService)
        {
            _logger = logger;
            _finalPriceService = finalPriceService;
        }

        [HttpGet]
        public List<FinalPriceItemDTO> Get(int DestinationId, int NumberOfNights)
        {
           
            try
            {
                //Llamada al método que devuelve la lista de FinalPriceItemDTO.
                var result = _finalPriceService.GetFinalPrices(DestinationId, NumberOfNights);

                _logger.LogInformation("Get operation called with arguments: DestinationId:" + DestinationId + " NumberOfNights:" + NumberOfNights);

                result.Wait();
                return result.Result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error:" + ex.Message);

                throw ex;
            }   

        }
    }
}
