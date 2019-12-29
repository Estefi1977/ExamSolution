using PriceCalculatorService.Clients;
using PriceCalculatorService.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceCalculatorService.Services
{
    public class FinalPriceService : IFinalPriceService
    {
        private readonly IFindBargainClient _findBargainClient;

        public FinalPriceService(IFindBargainClient findBargainClient)
        {
            //Implementamos la interfaz.
            _findBargainClient = findBargainClient;
        }
        public async Task<List<FinalPriceItemDTO>> GetFinalPrices(int DestinationId, int NumberOfNights)
        {
            var result = new List<FinalPriceItemDTO>();

            try
            {
                //Llamada al método que devuelve la lista de BargainItemDTO.
                var bargains = await _findBargainClient.Query(DestinationId, NumberOfNights);

                foreach (var bargain in bargains)
                {
                    var priceItem = new FinalPriceItemDTO
                    {
                        Hotel = bargain.Hotel,
                        Rates = new List<FinalPriceRateDTO>()
                    };
                    foreach (var bargainRate in bargain.Rates)
                    {
                        var finalPriceRate = new FinalPriceRateDTO
                        {
                            BoardType = bargainRate.BoardType
                        };
                        //Cálculo precio según tipo de tarifa.
                        if (bargainRate.RateType.Equals("PerNight"))
                        {
                            finalPriceRate.finalPrice = bargainRate.Value * NumberOfNights;
                        }
                        else
                        {
                            finalPriceRate.finalPrice = bargainRate.Value;
                        }
                        priceItem.Rates.Add(finalPriceRate);
                    }
                    result.Add(priceItem);
                }
            }

            catch (Exception ex)
            {

                // throw ex;
            }

            return result;

        }

    }
}
