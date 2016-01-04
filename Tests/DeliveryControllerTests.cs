using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LogisticSolutions.Controllers;
using LogisticSolutions.Interfaces;
using LogisticSolutions.Models;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DeliveryControllerTests
    {
        [Test]
        public void TestMethod1()
        {
            var fakeDeliveryService = new FakeDeliveryService();
            var sut = new DeliveryController(fakeDeliveryService);

            var deliveryToAdd = new AddDeliveryViewModel
            {
                /*Width = 30,
                Weight = 40,
                Height = 50,
                Length = 100,
                Content = "Artykuły biurowe",
                AdditionalInfo = "Nr zamówienia 21344221",*/
                ReceiptDate = new DateTime(2016, 01, 12),
                DeliveryDate = new DateTime(2016, 01, 15),
                /*PickupAddress = new PostalAddress()
                {
                    Name = "ArtBiurNa100%",
                    ContactPerson = "Arkadiusz Domagała",
                    Email = "arkadiusz@artbiur100.pl",
                    Phone = "698232323",
                    AddressLine1 = "Karmelkowa 123",
                    PostalCode = "23-432",
                    City = "Poznań"
                },
                DestinationAddress = new PostalAddress()
                {
                    Name = "Robert Kowalski",
                    ContactPerson = "Robert Kowalski",
                    Email = "kowal213@gmail.com",
                    Phone = "787654212",
                    AddressLine1 = "Piotrkowska 123/12",
                    PostalCode = "56-324",
                    City = "Łódź"
                }*/
            };

            sut.AddDelivery(deliveryToAdd);

            Assert.That(fakeDeliveryService.IsRegistered, Is.True);
            Assert.That(sut.ModelState.IsValid, Is.True);
        }
    }

    public class FakeDeliveryService : IDeliveryService
    {
        public bool IsRegistered { get; set; }

        public bool RegisterDelivery(AddDeliveryViewModel delivery)
        {
            IsRegistered = true;
            return true;
        }

        public IEnumerable<DeliveryViewModel> GetDeliveries()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TrackingHistoryPointViewModel> GetTrackingDetails(string id)
        {
            throw new NotImplementedException();
        }
    }
}