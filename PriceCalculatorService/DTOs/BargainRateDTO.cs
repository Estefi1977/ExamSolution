using System.Runtime.Serialization;

namespace PriceCalculatorService.DTOs
{
    [DataContract(Name = "rate")]
    public class BargainRateDTO
    {
        [DataMember(Name = "rateType")]
        public string RateType { get; set; }
        
        [DataMember(Name = "boardType")]
        public string BoardType { get; set; }
        
        [DataMember(Name = "value")]
        public decimal Value { get; set; }
    }
}