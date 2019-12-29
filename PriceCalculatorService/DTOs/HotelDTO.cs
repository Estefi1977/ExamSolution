using System.Runtime.Serialization;

namespace PriceCalculatorService.DTOs
{
    [DataContract(Name = "hotel")]
    public class HotelDTO
    {
        [DataMember(Name = "propertyID")]
        public int PropertyId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "geoId")]
        public int GeoId { get; set; }

        [DataMember(Name = "rating")]
        public int Rating { get; set; }

    }
}