using SearchService.Api.Entities;

namespace SearchService.Api.Interfaces
{
    public interface ISearch
    {
        public string Name { get; set; }
        public Location Position { get; set; }
    }
}
