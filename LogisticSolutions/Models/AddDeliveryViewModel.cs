using System;
using System.ComponentModel.DataAnnotations;

namespace LogisticSolutions.Models
{
    public class AddDeliveryViewModel
    {
        [Required(ErrorMessage = "Podanie wagi jest wymagane!")]
        [Range(1,1000, ErrorMessage = "Waga musi zawierać się pomiędzy {1} a {2}")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Podanie wysokości jest wymagane!")]
        [Range(1, 200, ErrorMessage = "Wysokośc musi zawierać się pomiędzy {1} a {2}")]
        public decimal Height { get; set; }

        [Required(ErrorMessage = "Podanie szerokości jest wymagane!")]
        [Range(1, 1500, ErrorMessage = "Szerokość musi zawierać się pomiędzy {1} a {2}")]
        public decimal Width { get; set; }

        [Required(ErrorMessage = "Podanie długości jest wymagane!")]
        [Range(1, 3000, ErrorMessage = "Długość musi zawierać się pomiędzy {1} a {2}")]
        public decimal Length { get; set; }

        [Required(ErrorMessage = "Podanie daty odbioru jest wymagane!")]
        [DataType(DataType.Date)]
        public DateTime ReceiptDate { get; set; }

        [Required(ErrorMessage = "Podanie daty dostawy jest wymagane!")]
        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }

        [StringLengthAttribute(100, MinimumLength = 0, ErrorMessage = "Maksymalna długość opisu zawartości wynosi 100 znaków!")]
        public string Content { get; set; }

        [StringLengthAttribute(200, MinimumLength = 0, ErrorMessage = "Maksymalna długość dodatowych informacji wynosi 200 znaków!")]
        public string AdditionalInfo { get; set; }

        public PostalAddress PickupAddress { get; set; }

        public PostalAddress DestinationAddress { get; set; }

    }
}