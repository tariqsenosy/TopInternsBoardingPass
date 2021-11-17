using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TopInternsBoardingPassSorter.Domain.Models.TopInternsTransportationCards;
using TopInternsBoardingPassSorter.Services;

namespace TopInternsBoardingPassSorter.Controllers
{
    [ApiController]
    [Route("topInternstransportationcard")]
    public class TopInternsTransportationCardController  : ControllerBase
    {
        private readonly ILogger<TopInternsTransportationCardController> _logger;
        private readonly ITopInternsBusService _topInternsBusService;
        public TopInternsTransportationCardController(ILogger<TopInternsTransportationCardController> logger,
            ITopInternsBusService topInternsBusService)
        {
            _logger = logger;
            _topInternsBusService = topInternsBusService;
        }

        [HttpPost]
        public IActionResult setCards([FromBody] List<TopInternsTransportationCard> cards)
        {
            try
            {
                if (_topInternsBusService.isValidList(cards))
                    return Ok(_topInternsBusService.GetTripList(cards));
                return BadRequest("The provided list doesn't match the correct criteria");
            }
            catch(Exception e)
            {
                return  BadRequest(e.Message);
            }
           

        }

    }
}
