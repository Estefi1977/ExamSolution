using PriceCalculatorService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculatorService.Services
{
    public interface IFinalPriceService
    {
        Task<List<FinalPriceItemDTO>> GetFinalPrices(int DestinationId, int NumberOfNights);
    }
}
