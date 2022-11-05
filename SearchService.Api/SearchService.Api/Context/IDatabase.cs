using SearchService.Api.Entities;

namespace SearchService.Api.Context
{
    public interface IDatabase
    {
        List<Service> Services { get; }
    }
}