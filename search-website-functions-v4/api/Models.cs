using Azure.Search.Documents.Models;
using System.Text.Json.Serialization;

namespace WebSearch.Models
{
    public class RequestBodyLookUp
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }

    public class RequestBodySuggest
    {
        [JsonPropertyName("q")]
        public string SearchText { get; set; }

        [JsonPropertyName("top")]
        public int Size { get; set; }

        [JsonPropertyName("suggester")]
        public string SuggesterName { get; set; }
    }

    public class RequestBodySearch
    {
        [JsonPropertyName("q")]
        public string SearchText { get; set; }

        [JsonPropertyName("skip")]
        public int Skip { get; set; }

        [JsonPropertyName("top")]
        public int Size { get; set; }

        [JsonPropertyName("filters")]
        public List<SearchFilter> Filters { get; set; }
    }

    public class SearchFilter
    {
        public string field { get; set; }
        public string value { get; set; }
    }

    public class FacetValue
    {
        public string value { get; set; }
        public long? count { get; set; }
    }

    class SearchOutput
    {
        [JsonPropertyName("count")]
        public long? Count { get; set; }
        [JsonPropertyName("results")]
        public List<SearchResult<SearchDocument>> Results { get; set; }
        [JsonPropertyName("facets")]
        public Dictionary<String, IList<FacetValue>> Facets { get; set; }
    }
    class LookupOutput
    {
        [JsonPropertyName("document")]
        public SearchDocument Document { get; set; }
    }

    public class VacancyModel
    {
        public string id { get; set; }

        public string VacancyId { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }
        public string Client { get; set; }
        public string Contract { get; set; }
        public string HiringManager { get; set; }
        public string AddressCity { get; set; }

        public string AddressPostCode { get; set; }
        public string AddressCountry { get; set; }
        // public int TotalPositions { get; set; }
        // public int RemainingPositions { get; set; }
        // public string FurthestStatus { get; set; }
         public double Salary { get; set; }
        // public int PermPackageValue { get; set; }
        // public int TempFrequency { get; set; }
        // public int TempSalary { get; set; }
        // public int HoursPerWeek { get; set; }
        // public int DaysPerWeek { get; set; }
        // public int NumberOfWeeks { get; set; }
        // public string Currency { get; set; }
        // public string? JobDescription { get; set; }
        // public string? Tags { get; set; }
    }
}

