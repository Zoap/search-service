using SearchService.Api.Entities;

namespace SearchService.Api.Interfaces
{
    public interface IService
    {
        public string Name { get; set; }
        public Location Position { get; set; }
    }
}
