using Newtonsoft.Json;
using SearchService.Api.Entities;

namespace SearchService.Api.Context
{
    public class Database : IDatabase
    {
        private readonly string _path = @"..\SearchService.Api\Data\data.json";
        public List<Service> Services { get; private set; }

        public Database()
        {
            var servicesJson = File.ReadAllText(_path);
            var services = JsonConvert.DeserializeObject<List<Service>>(servicesJson);
            Services = services ?? new();
        }
    }
}
