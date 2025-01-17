﻿using System;

namespace HotelProject.WebUI.Dtos.ReservationDto
{
    public class ResultLast6ReservationDto
    {
        public int ReservationID { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public int RoomCount { get; set; }
        public string SpecialRequest { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

    }
}
