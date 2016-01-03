using System;
using System.ComponentModel.DataAnnotations;

namespace LogisticSolutions.Models
{
    public class AddDeliveryViewModel
    {
        [Display(Name = "Waga")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [Range(1, 1000, ErrorMessage = "Wartość pola {0} musi zawierać się pomiędzy {1} a {2}")]
        public decimal Weight { get; set; }

        [Display(Name = "Wysokość")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [Range(1, 200, ErrorMessage = "Wartość pola {0} musi zawierać się pomiędzy {1} a {2}")]
        public decimal Height { get; set; }

        [Display(Name = "Szerokość")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [Range(1, 1500, ErrorMessage = "Wartość pola {0} musi zawierać się pomiędzy {1} a {2}")]
        public decimal Width { get; set; }

        [Display(Name = "Długość")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [Range(1, 3000, ErrorMessage = "Wartość pola {0} musi zawierać się pomiędzy {1} a {2}")]
        public decimal Length { get; set; }

        [Display(Name = "Data odbioru")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [DataType(DataType.Date)]
        public DateTime ReceiptDate { get; set; }

        [Display(Name = "Data dostawy")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "Zawartość")]
        [StringLengthAttribute(100, MinimumLength = 0, ErrorMessage = "Maksymalna wartość pola {0} wynosi 100 znaków!")]
        public string Content { get; set; }

        [Display(Name = "Dodatkowe informacje")]
        [StringLengthAttribute(200, MinimumLength = 0, ErrorMessage = "Maksymalna wartość pola {0} wynosi 200 znaków!")]
        public string AdditionalInfo { get; set; }

        public PostalAddress PickupAddress { get; set; }

        public PostalAddress DestinationAddress { get; set; }

    }
}