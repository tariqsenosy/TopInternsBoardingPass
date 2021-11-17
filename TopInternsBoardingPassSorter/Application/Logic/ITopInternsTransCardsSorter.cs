using System;
using System.Collections.Generic;

namespace TopInternsBoardingPassSorter.Application.Logic
{
   public  interface ITopInternsTransCardsSorter<T>
    {
        List<T> SortListOfCards(List<T> cards);
    }
}
