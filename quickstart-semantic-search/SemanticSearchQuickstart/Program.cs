using System;
using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;

namespace SemanticSearch.Quickstart

{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceName = "dcb-cog-search-demo-1-svc";
            string apiKey = "dRusVowtb2z1DaVdDYrxsVEzMlQCm9PAVZpYjJTSnyAzSeDhlwzN";
            string indexName = "vacancies";
            

            // Create a SearchIndexClient to send create/delete index commands
            Uri serviceEndpoint = new Uri($"https://{serviceName}.search.windows.net/");
            AzureKeyCredential credential = new AzureKeyCredential(apiKey);
            SearchIndexClient adminClient = new SearchIndexClient(serviceEndpoint, credential);

            // Create a SearchClient to load and query documents
            SearchClient srchclient = new SearchClient(serviceEndpoint, indexName, credential);

            // Delete index if it exists
            Console.WriteLine("{0}", "Deleting index...\n");
            DeleteIndexIfExists(indexName, adminClient);

            // Create index
            Console.WriteLine("{0}", "Creating index...\n");
            CreateIndex(indexName, adminClient);

            SearchClient ingesterClient = adminClient.GetSearchClient(indexName);

            // Load documents
            Console.WriteLine("{0}", "Uploading documents...\n");
            UploadDocuments(ingesterClient);

            // Wait 2 secondsfor indexing to complete before starting queries (for demo and console-app purposes only)
            Console.WriteLine("Waiting for indexing...\n");
            System.Threading.Thread.Sleep(2000);

            // Call the RunQueries method to invoke a series of queries
            Console.WriteLine("Starting queries...\n");
            RunQueries(srchclient);

            // End the program
            Console.WriteLine("{0}", "Complete. Press any key to end this program...\n");
            Console.ReadKey();
        }

        // Delete the hotels-quickstart index to reuse its name
        private static void DeleteIndexIfExists(string indexName, SearchIndexClient adminClient)
        {
            adminClient.GetIndexNames();
            {
                adminClient.DeleteIndex(indexName);
            }
        }

        // Create hotels-quickstart index
        private static void CreateIndex(string indexName, SearchIndexClient adminClient)
        {

            FieldBuilder fieldBuilder = new FieldBuilder();
            var searchFields = fieldBuilder.Build(typeof(Vacancy));

            var definition = new SearchIndex(indexName, searchFields);

            var suggester = new SearchSuggester("sg", new[] { "Name", "Client", "HiringManager" });
            definition.Suggesters.Add(suggester);

            SemanticSettings semanticSettings = new SemanticSettings();
            semanticSettings.Configurations.Add(new SemanticConfiguration
                (
                    "my-semantic-config",
                    new PrioritizedFields()
                    {
                        TitleField = new SemanticField { FieldName = "Name" },
                        ContentFields = {
                        new SemanticField { FieldName = "Client" },
                        },
                        KeywordFields = {
                        new SemanticField { FieldName = "Name" }
                        }
                    })
                );

            definition.SemanticSettings = semanticSettings;

            adminClient.CreateOrUpdateIndex(definition);
        }

        // Upload documents in a single Upload request.
        private static void UploadDocuments(SearchClient searchClient)
        {
            IndexDocumentsBatch<Vacancy> batch = IndexDocumentsBatch.Create(
                IndexDocumentsAction.Upload(
                    new Vacancy()
                    {
                        VacancyId = "1",
                        Name = "Senior Business Analyst",
                        Client = "Larkin-Jones",
                        HiringManager = "Gloria Wolf",
                        AddressCountry = "United Kingdom",
                        AddressPostCode = "UW26 3AF",
                        AddressCity = "London",
                        Salary = 45000

                    }),
                IndexDocumentsAction.Upload(
                    new Vacancy()
                    {

                        VacancyId = "2",
                        Name = "Senior Systems Admin",
                        Client = "Rogahn-Sanford",
                        HiringManager = "Jo Zemlak",
                        AddressCountry = "United Kingdom",
                        AddressPostCode = "UW26 3AF",
                        AddressCity = "London",
                        Salary = 35000
                    }),
                IndexDocumentsAction.Upload(
                    new Vacancy()
                    {
                        VacancyId = "3",
                        Name = "C# Developer",
                        Client = "Barclays",
                        HiringManager = "Wilber Smith",
                        AddressCountry = "United Kingdom",
                        AddressPostCode = "UW26 3AF",
                        AddressCity = "London",
                        Salary = 100000

                    }),
                IndexDocumentsAction.Upload(
                    new Vacancy()
                    {

                        VacancyId = "4",
                        Name = "Business Analyst",
                        Client = "Kunde LLC",
                        HiringManager = "Zula Kuhic",
                        AddressCountry = "United Kingdom",
                        AddressPostCode = "UW26 3AF",
                        AddressCity = "London",
                        Salary = 75000
                    })
                );

            try
            {
                IndexDocumentsResult result = searchClient.IndexDocuments(batch);
            }
            catch (Exception)
            {
                // If for some reason any documents are dropped during indexing, you can compensate by delaying and
                // retrying. This simple demo just logs the failed document keys and continues.
                Console.WriteLine("Failed to index some of the documents: {0}");
            }
        }

        // Run queries, use WriteDocuments to print output
        private static void RunQueries(SearchClient srchclient)
        {
            SearchOptions options;
            SearchResults<Vacancy> response;

            // Query 1
            Console.WriteLine("Query #1: Search on empty term '*' to return in an arbitrary order...\n");

            options = new SearchOptions()
            {
                IncludeTotalCount = true,
                Filter = "",
                OrderBy = { "" }
            };

            options.Select.Add("Name");
            options.Select.Add("Salary");

            response = srchclient.Search<Vacancy>("*", options);
            WriteDocuments(response);

            //// Query 2
            //Console.WriteLine("Query #2: Full text search on 'what hotel has a good restaurant on site' with BM25 ranking. Sublime Cliff is ranked first because it includes 'site' in its description...\n");

            //options.Select.Add("Name");
            //options.Select.Add("Salary");

            //response = srchclient.Search<Vacancy>("what hotel has a good restaurant on site", options);
            //WriteDocuments(response);

            // Query 4
            Console.WriteLine("Query #3: Invoke semantic search on the same query. This time Business Analyst is first.\n");

            options = new SearchOptions()
            {
                QueryType = Azure.Search.Documents.Models.SearchQueryType.Semantic,
                QueryLanguage = QueryLanguage.EnUs,
                SemanticConfigurationName = "my-semantic-config",
                QueryCaption = QueryCaptionType.Extractive,
                QueryCaptionHighlightEnabled = true
            };
            options.Select.Add("Name");
            options.Select.Add("Salary");
            options.Select.Add("AddressCity");
            
            //response = srchclient.Search<Vacancy>("*", options);
            response = srchclient.Search<Vacancy>("", options);
            WriteDocuments(response);

        }

        // Write search results to console
        private static void WriteDocuments(SearchResults<Vacancy> searchResults)
        {
            foreach (SearchResult<Vacancy> result in searchResults.GetResults())
            {
                Console.WriteLine(result.Document);
            }

            Console.WriteLine();
        }
    }
}
