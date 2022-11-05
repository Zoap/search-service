using Microsoft.AspNetCore.Mvc;
using SearchService.Api.Interfaces;
using SearchService.Api.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace SearchService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly ISearchRepository _searchRepo;

        public SearchController(ILogger<SearchController> logger, ISearchRepository searchRepo)
        {
            _logger = logger;
            _searchRepo = searchRepo;
        }

        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ServiceSearchResult))]
        [HttpGet(Name = "SearchService")]
        public IActionResult Get(string name, double lat, double lng)
        {
            var search = new SearchInput(name, lat, lng);
            return Ok(_searchRepo.Search(search));
        }
    }
}