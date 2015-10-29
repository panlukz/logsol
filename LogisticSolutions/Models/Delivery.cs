using System;
using System.Collections.Generic;

namespace LogisticSolutions.Models
{
    public class Delivery
    {
        private string _number;
        private PostalAddress _pickupAddress;
        private PostalAddress _destinationAddress;
        private List<TrackingStatus> _trackingHistory;

        public Delivery(PostalAddress pickupAddress, PostalAddress destinationAddress)
        {
            _number =
                (DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute +
                 DateTime.Now.Second).ToString();
            _pickupAddress = pickupAddress;
            _destinationAddress = destinationAddress;

            _trackingHistory = new List<TrackingStatus>();

            var trackingHistoryPoint = new TrackingStatus()
            {
                //TODO retrieve author name from identity class
                Author = "Author name",
                DateTime = DateTime.Now,
                Location = "System",
                Status = TrackingStatusEnum.RegistredInSystem
            };

            _trackingHistory.Add(trackingHistoryPoint);

        }

        public string Number
        {
            get { return _number; }
        }

        public PostalAddress PickupAddress
        {
            get { return _pickupAddress; }
        }

        public PostalAddress DestinatonAddress
        {
            get { return _destinationAddress; }
        }

        public List<TrackingStatus> TrackingHistory
        {
            get { return _trackingHistory; }
        }

        public void AddTrackingPoint(TrackingStatusEnum trackingStatus)
        {
            var trackingHistoryPoint = new TrackingStatus()
            {
                //TODO retrieve author name from identity class
                Author = "Author name",
                DateTime = DateTime.Now,
                //TODO retrieve location name from identity location
                Location = "Location name",
                Status = trackingStatus
            };

            _trackingHistory.Add(trackingHistoryPoint);
        }
    }
}