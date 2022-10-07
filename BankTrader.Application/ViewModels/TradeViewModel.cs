using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankTrader.Application.ViewModels
{
    public class TradeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Value is Required")]
        [DataType(DataType.Currency, ErrorMessage = "The type format is invalid")]
        [DisplayName("Value")]
        public double Value { get; set; }

        [Required(ErrorMessage = "The Client Sector is Required")]
        [MinLength(2)]
        [MaxLength(150)]
        [DisplayName("Client Sector")]
        public string ClientSector { get; set; }
    }
}
