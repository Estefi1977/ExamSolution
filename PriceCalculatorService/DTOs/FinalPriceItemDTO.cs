using System.Collections.Generic;

namespace PriceCalculatorService.DTOs
{
    public class FinalPriceItemDTO
    {
        public HotelDTO Hotel { get; set; }

        public List<FinalPriceRateDTO> Rates { get; set; }

    }
}