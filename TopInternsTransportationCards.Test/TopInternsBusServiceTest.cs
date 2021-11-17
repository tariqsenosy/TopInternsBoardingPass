using System;
using System.Collections.Generic;
using TopInternsBoardingPassSorter.Application.Logic;
using TopInternsBoardingPassSorter.Domain.Models.TopInternsTransportationCards;
using TopInternsBoardingPassSorter.Services.TopInternsBusService;
using Xunit;

namespace TopInternsTransportationCards.Test
{
    public class TopInternsBusServiceTest
    {
       [Fact]
        public void GetTripList_Returns_Correct_List_Of_Trip()
        {
            //Arrange
            TopInternsTransCardsSorter sorter = new TopInternsTransCardsSorter();
            var service = new TopInternsBusService(sorter);
            //cards 
            List<TopInternsTransportationCard> cards = new List<TopInternsTransportationCard>();
            cards.Add(new TopInternsTransportationCard()
            {
                TransType = "Train",
                TransNumber = "002",
                StartPoint = "B",
                EndPoint = "C",
                StationName = "B-Stattion",
                SeatInfo = "Gate 45B, seat 3A. Baggage drop at ticket counter 344"
            });
        cards.Add(new TopInternsTransportationCard()
                {
                 TransType="Bus",
                TransNumber="001",
                StartPoint="A",
                EndPoint="B",
                StationName="",
                SeatInfo="Sit in seat 45B"
                });


            //Act
            List<string> trip = service.GetTripList(cards);
            //Assert
            Assert.Equal("Take Bus 001 From A To B. Sit in seat 45B ", trip[0]);
           }

        [Fact]
        public void GetTripList_Returns_Count_List_Of_Trip()
        {
            //Arrange
            TopInternsTransCardsSorter sorter = new TopInternsTransCardsSorter();
            var service = new TopInternsBusService(sorter);
            //cards 
            List<TopInternsTransportationCard> cards = new List<TopInternsTransportationCard>();
            cards.Add(new TopInternsTransportationCard()
            {
                TransType = "Train",
                TransNumber = "002",
                StartPoint = "B",
                EndPoint = "C",
                StationName = "B-Stattion",
                SeatInfo = "Gate 45B, seat 3A. Baggage drop at ticket counter 344"
            });
            cards.Add(new TopInternsTransportationCard()
            {
                TransType = "Bus",
                TransNumber = "001",
                StartPoint = "A",
                EndPoint = "B",
                StationName = "",
                SeatInfo = "Sit in seat 45B"
            });
            //Act
            List<string> trip = service.GetTripList(cards);
            //Assert
            Assert.Equal(3, trip.Count);
        }

        [Fact]
        public void GetTripList_Returns_Last_Element_In_List_Of_Trip()
        {
            //Arrange
            TopInternsTransCardsSorter sorter = new TopInternsTransCardsSorter();
            var service = new TopInternsBusService(sorter);
            //cards 
            List<TopInternsTransportationCard> cards = new List<TopInternsTransportationCard>();
            cards.Add(new TopInternsTransportationCard()
            {
                TransType = "Train",
                TransNumber = "002",
                StartPoint = "B",
                EndPoint = "C",
                StationName = "B-Stattion",
                SeatInfo = "Gate 45B, seat 3A. Baggage drop at ticket counter 344"
            });
            cards.Add(new TopInternsTransportationCard()
            {
                TransType = "Bus",
                TransNumber = "001",
                StartPoint = "A",
                EndPoint = "B",
                StationName = "",
                SeatInfo = "Sit in seat 45B"
            });
            //Act
            List<string> trip = service.GetTripList(cards);
            //Assert
            Assert.Equal("You have arrived at your final destination.", trip[2]);
        }

    }
}
