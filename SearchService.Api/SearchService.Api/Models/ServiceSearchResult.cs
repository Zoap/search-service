namespace SearchService.Api.Models
{
    public class ServiceSearchResult
    {
        public int TotalHits { get; set; }
        public int TotalDocuments { get; set; }
        public List<ServiceModel> Results { get; set; }
    }
}
