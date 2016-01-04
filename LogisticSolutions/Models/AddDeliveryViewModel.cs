﻿using System;
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
        [StringLengthAttribute(100, MinimumLength = 0, ErrorMessage = "Maksymalna wartość pola {0} wynosi {2} znaków!")]
        public string Content { get; set; }

        [Display(Name = "Dodatkowe informacje")]
        [StringLengthAttribute(200, MinimumLength = 0, ErrorMessage = "Maksymalna wartość pola {0} wynosi {2} znaków!")]
        public string AdditionalInfo { get; set; }



        [Display(Name = "Nazwa nadawcy")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [StringLengthAttribute(50, MinimumLength = 9, ErrorMessage = "Maksymalna wartość pola {0} wynosi {2} znaków!")]
        public string PickupAddressName { get; set; }

        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [StringLengthAttribute(20, MinimumLength = 9, ErrorMessage = "Maksymalna wartość pola {0} wynosi {2} znaków!")]
        public string PickupAddressPhone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [StringLengthAttribute(50, MinimumLength = 5, ErrorMessage = "Maksymalna wartość pola {0} wynosi {2} znaków!")]
        public string PickupAddressEmail { get; set; }

        [Display(Name = "Osoba kontaktowa")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [StringLengthAttribute(50, MinimumLength = 9, ErrorMessage = "Maksymalna wartość pola {0} wynosi {2} znaków!")]
        public string PickupAddressContactPerson { get; set; }

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [StringLengthAttribute(20, MinimumLength = 5, ErrorMessage = "Maksymalna wartość pola {0} wynosi {2} znaków!")]
        public string PickupAddressAddressLine1 { get; set; }

        [Display(Name = "Adres cd.")]
        [StringLengthAttribute(20, MinimumLength = 0, ErrorMessage = "Maksymalna wartość pola {0} wynosi {2} znaków!")]
        public string PickupAddressAddressLine2 { get; set; }

        [Display(Name = "Kod pocztowy")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [StringLengthAttribute(6, MinimumLength = 6, ErrorMessage = "Maksymalna wartość pola {0} wynosi {2} znaków!")]
        public string PickupAddressPostalCode { get; set; }

        [Display(Name = "Miasto")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [StringLengthAttribute(30, MinimumLength = 1, ErrorMessage = "Maksymalna wartość pola {0} wynosi {2} znaków!")]
        public string PickupAddressCity { get; set; }


        [Display(Name = "Nazwa nadawcy")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [StringLengthAttribute(50, MinimumLength = 9, ErrorMessage = "Maksymalna wartość pola {0} wynosi {2} znaków!")]
        public string DestinationAddressName { get; set; }

        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [StringLengthAttribute(20, MinimumLength = 9, ErrorMessage = "Maksymalna wartość pola {0} wynosi {2} znaków!")]
        public string DestinationAddressPhone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [StringLengthAttribute(50, MinimumLength = 5, ErrorMessage = "Maksymalna wartość pola {0} wynosi {2} znaków!")]
        public string DestinationAddressEmail { get; set; }

        [Display(Name = "Osoba kontaktowa")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [StringLengthAttribute(50, MinimumLength = 9, ErrorMessage = "Maksymalna wartość pola {0} wynosi {2} znaków!")]
        public string DestinationAddressContactPerson { get; set; }

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [StringLengthAttribute(20, MinimumLength = 5, ErrorMessage = "Maksymalna wartość pola {0} wynosi {2} znaków!")]
        public string DestinationAddressAddressLine1 { get; set; }

        [Display(Name = "Adres cd.")]
        [StringLengthAttribute(20, MinimumLength = 0, ErrorMessage = "Maksymalna wartość pola {0} wynosi {2} znaków!")]
        public string DestinationAddressAddressLine2 { get; set; }

        [Display(Name = "Kod pocztowy")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [StringLengthAttribute(6, MinimumLength = 6, ErrorMessage = "Maksymalna wartość pola {0} wynosi {2} znaków!")]
        public string DestinationAddressPostalCode { get; set; }


        [Display(Name = "Miasto")]
        [Required(ErrorMessage = "Uzupełnienie pola {0} jest wymagane!")]
        [StringLengthAttribute(30, MinimumLength = 1, ErrorMessage = "Maksymalna wartość pola {0} wynosi {2} znaków!")]
        public string DestinationAddressCity { get; set; }

    }
}