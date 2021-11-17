using System;
using System.Collections.Generic;
using System.Linq;
using TopInternsBoardingPassSorter.Domain.Models.TopInternsTransportationCards;

namespace TopInternsBoardingPassSorter.Application.Logic
{
    public class TopInternsTransCardsSorter: ITopInternsTransCardsSorter<TopInternsTransportationCard>
    {

        public List<TopInternsTransportationCard> SortListOfCards(List<TopInternsTransportationCard> cards)
        {
            List<TopInternsTransportationCard> sortedCards = new List<TopInternsTransportationCard>();
            //1- Determine the startPointCard
            TopInternsTransportationCard startPointCard =getStartPointCard(cards);
            //2-Sort Rest Cards
            sortedCards = sortCards(cards, startPointCard);
            //3-Return sorted to service
            return sortedCards;
        }

        //Sort algorithm 
        //Best Case O(N)
        //Worest Case O(N2)
        //Average Case O(LogN)

        private List<TopInternsTransportationCard> sortCards(List<TopInternsTransportationCard> cards, TopInternsTransportationCard startPointCard)
        {
            List<TopInternsTransportationCard> sortedCards = new List<TopInternsTransportationCard>();
            cards.Remove(startPointCard);
            sortedCards.Add(startPointCard);
            TopInternsTransportationCard currentCard = new TopInternsTransportationCard();
            currentCard = startPointCard;
            while (cards.Count>0)
            {
                Boolean found = false;
                for (int j = 0; j < cards.Count; j++)
                {
                    if (currentCard.EndPoint == cards.ElementAt(j).StartPoint)
                    {
                        currentCard = cards.ElementAt(j);
                        sortedCards.Add(currentCard);
                        cards.Remove(currentCard);
                        found = true;
                         break;
                    }
                }
                if (!found) throw new Exception("Un completed list provided!!");
            }
            return sortedCards;
        }

       
        //Search algorithm 
        //Best Case O(N)
        //Worest Case O(N2)
        //Average Case O(LogN)
        private TopInternsTransportationCard getStartPointCard(List<TopInternsTransportationCard> cards)
        {
            TopInternsTransportationCard startPoint = new TopInternsTransportationCard();
            startPoint = cards.ElementAt(0);
            for (int i = 0; i < cards.Count; i++)
            {
                Boolean visited = false;
                for (int j=i+1; j< cards.Count; j++)
                {
                    if(startPoint.StartPoint== cards.ElementAt(j).EndPoint)
                    {
                        startPoint = cards.ElementAt(j);
                        visited = true;
                        break;
                    }
                }

                if (!visited) break;
            }
           
            return startPoint;
        }
    }
}
