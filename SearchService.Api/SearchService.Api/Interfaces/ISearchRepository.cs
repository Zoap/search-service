using SearchService.Api.Models;

namespace SearchService.Api.Interfaces
{
    public interface ISearchRepository
    {
        ServiceSearchResult Search(SearchInput input);
    }
}
