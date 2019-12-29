using PriceCalculatorService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculatorService.Clients
{
    public interface IFindBargainClient
    {
        Task<List<BargainItemDTO>> Query(int DestinationId, int NumberOfNights);
    }
}
