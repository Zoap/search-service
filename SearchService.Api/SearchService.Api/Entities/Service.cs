using SearchService.Api.Interfaces;

namespace SearchService.Api.Entities
{
    public class Service : BaseEntity, ISearch
    {
        public string Name { get; set; }
        public Location Position { get; set; }
    }
}
