using SearchService.Api.Context;
using SearchService.Api.Interfaces;
using SearchService.Api.Models;

namespace SearchService.Api.Services
{
    public class SearchRepository : ISearchRepository
    {
        private readonly IDatabase _database;
        public SearchRepository(IDatabase database)
        {
            _database = database;
        }

        public ServiceSearchResult Search(SearchInput input)
        {
            var results = _database.Services.Where(service => input.IsMatch(service.Name))
                .Select(service => new ServiceModel(service, input))
                .OrderByDescending(result => result.Score)
                .ToList();

            return new ServiceSearchResult()
            {
                TotalHits = results.Count,
                TotalDocuments = _database.Services.Count(),
                Results = results,
            };
        }
    }
}
