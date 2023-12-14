using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;

namespace SemanticSearch.Quickstart
{
    public partial class Vacancy
    {
        [SimpleField(IsKey = true, IsFilterable = true)]
        public string VacancyId { get; set; }


        [SearchableField(IsSortable = true)]
        public string Name { get; set; }

        [SearchableField(AnalyzerName = LexicalAnalyzerName.Values.EnLucene)]
        public string Client { get; set; }

        //[SearchableField(AnalyzerName = LexicalAnalyzerName.Values.FrLucene)]
        //[JsonPropertyName("Description_fr")]
        //public string DescriptionFr { get; set; }

        [SearchableField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        public string HiringManager { get; set; }


        [SearchableField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        public string AddressCity { get; set; }
        

        [SearchableField(IsFilterable = true, IsFacetable = true)]
        public string AddressPostCode { get; set; }

        [SearchableField(IsFilterable = true, IsFacetable = true)]
        public string AddressCountry { get; set; }



        [SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        public double Salary { get; set; }


        //[SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        //public bool? ParkingIncluded { get; set; }

        //[SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        //public DateTimeOffset? LastRenovationDate { get; set; }

        //[SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        //public double? Rating { get; set; }

        //[SearchableField]
        //public Address Address { get; set; }
    }
}
