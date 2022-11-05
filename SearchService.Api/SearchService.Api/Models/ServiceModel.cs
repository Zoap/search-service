using SearchService.Api.Entities;

namespace SearchService.Api.Models
{
    public class ServiceModel : Service
    {
        public ServiceModel(Service service, SearchInput search)
        {
            CopyServiceProperties(service);
            SetDistance(search.Position);
            Score = search.GetSearchScore(Name);
        }

        public string Distance { get; private set; }
        public int Score { get; private set; }

        private void CopyServiceProperties(Service service)
        {
            Id = service.Id;
            Name = service.Name;
            Position = service.Position;
        }

        private void SetDistance(Location location)
        {
            var distance = Math.Round(Position.GetDistance(location), 2);
            var km = 1000;
            var distanceString = distance < km ? $"{distance}m" : $"{Math.Round(distance / km, 2)}km";
            Distance = distanceString.Replace(',', '.');
        }
    }
}
