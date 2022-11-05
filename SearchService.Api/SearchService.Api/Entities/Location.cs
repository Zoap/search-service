using SearchService.Api.Interfaces;

namespace SearchService.Api.Entities
{
    public class Location : ILocation
    {
        public Location(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }
        public double Lat { get; set; }
        public double Lng { get; set; }

        /// <summary>
        /// Returns distance in meters
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public double GetDistance(Location location)
        {
            //https://stackoverflow.com/questions/60700865/find-distance-between-2-coordinates-in-net-core
            var rad = Math.PI / 180.0;
            var d1 = Lat * rad;
            var num1 = Lng * rad;
            var d2 = location.Lat * rad;
            var num2 = location.Lng * rad - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2), 2) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2), 2);
            return 6376500 * (2 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1 - d3)));
        }
    }
}
