using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopInternsBoardingPassSorter.Application.Logic;
using TopInternsBoardingPassSorter.Domain.Models.TopInternsTransportationCards;

namespace TopInternsBoardingPassSorter.Services.TopInternsBusService
{
    public class TopInternsBusService : ITopInternsBusService
    {
        private readonly ITopInternsTransCardsSorter<TopInternsTransportationCard> _topInternsTransCardsSorter;
        public TopInternsBusService(ITopInternsTransCardsSorter<TopInternsTransportationCard> topInternsTransCardsSorter)
        {
            _topInternsTransCardsSorter = topInternsTransCardsSorter;
        }
        public List<string> GetTripList(List<TopInternsTransportationCard> cards)
        {
            List<string> trip = new List<string>();
            List<TopInternsTransportationCard> sortedCards = new List<TopInternsTransportationCard>();
            //1- Sort cards 
            sortedCards = _topInternsTransCardsSorter.SortListOfCards(cards);
            //2- Generate human readable list 
            trip = humanReadable(sortedCards);
            //3- return the list 
            return trip;
        }

        public List<string> humanReadable(List<TopInternsTransportationCard> cards)
        {
            List<string> tripDetails = new List<string>();
            foreach (var card in cards)
            {
                StringBuilder details = new StringBuilder();

                if (card.StationName != string.Empty)
                {
                    details.Append("From ");
                    details.Append(card.StationName + ", ");
                    details.Append("take ");
                }
                else
                {
                    details.Append("Take ");
                }
                details.Append(card.TransType + " ");
                details.Append(card.TransNumber + " ");
                details.Append("From ");
                details.Append(card.StartPoint + " ");
                details.Append("To ");
                details.Append(card.EndPoint + ". ");
                details.Append(card.SeatInfo + " ");
                tripDetails.Add(details.ToString());

            }
            tripDetails.Add("You have arrived at your final destination.");
            return tripDetails;
        }

        public bool isValidList(List<TopInternsTransportationCard> cards)
        {
            if (cards.Count < 1)
                return false;
            return true;
        }
    }
}
