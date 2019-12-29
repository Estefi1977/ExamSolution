using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PriceCalculatorService.DTOs
{
    [DataContract(Name = "anonymous")]
    public class BargainItemDTO
    {

        [DataMember(Name = "hotel")]
        public HotelDTO Hotel { get; set; }

        [DataMember(Name = "rates")]
        public List<BargainRateDTO> Rates { get; set; }

    }
}
