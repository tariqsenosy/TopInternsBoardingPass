using System;
using System.Collections.Generic;
using TopInternsBoardingPassSorter.Domain.Models.TopInternsTransportationCards;

namespace TopInternsBoardingPassSorter.Services
{
  public  interface ITopInternsBusService
    {

        public Boolean isValidList(List<TopInternsTransportationCard> cards);
        public List<string> GetTripList(List<TopInternsTransportationCard> cards);
    }
}
