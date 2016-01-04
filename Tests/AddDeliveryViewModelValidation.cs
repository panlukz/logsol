using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LogisticSolutions.Models;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AddDeliveryModelValidation
    {
        [Test]
        public void ShouldPassValidation()
        {
            var sut = new AddDeliveryViewModel
            {
                Width = 30,
                Weight = 40,
                Height = 50,
                Length = 100,
                Content = "Artykuły biurowe",
                AdditionalInfo = "Nr zamówienia 21344221",
                ReceiptDate = new DateTime(2016, 01, 12),
                DeliveryDate = new DateTime(2016, 01, 15),
                PickupAddressName = "ArtBiurNa100%",
                PickupAddressContactPerson = "Arkadiusz Domagała",
                PickupAddressEmail = "arkadiusz@artbiur100.pl",
                PickupAddressPhone = "698232323",
                PickupAddressAddressLine1 = "Karmelkowa 123",
                PickupAddressPostalCode = "23-432",
                PickupAddressCity = "Poznań",
                DestinationAddressName = "Robert Kowalski",
                DestinationAddressContactPerson = "Robert Kowalski",
                DestinationAddressEmail = "kowal213@gmail.com",
                DestinationAddressPhone = "787654212",
                DestinationAddressAddressLine1 = "Piotrkowska 123/12",
                DestinationAddressPostalCode = "56-324",
                DestinationAddressCity = "Łódź"
            };

            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.That(isModelStateValid, Is.True);
        }
    }

}
