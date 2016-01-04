﻿using System;
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
                Width = 30,
                Weight = 40,
                Height = 50,
                Length = 999999999999999,
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