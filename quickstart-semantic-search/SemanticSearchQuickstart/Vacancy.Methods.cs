using System;
using System.Text;

namespace SemanticSearch.Quickstart
{
    public partial class Vacancy
    {
        // This implementation of ToString() is only for the purposes of the sample console application.
        // You can override ToString() in your own model class if you want, but you don't need to in order
        // to use the Azure Search .NET SDK.
        public override string ToString()
        {
            var builder = new StringBuilder();

            if (!String.IsNullOrEmpty(VacancyId))
            {
                builder.AppendFormat("HotelId: {0}\n", VacancyId);
            }

            if (!String.IsNullOrEmpty(Name))
            {
                builder.AppendFormat("Name: {0}\n", Name);
            }
            if (!String.IsNullOrEmpty(Client))
            {
                builder.AppendFormat("Client: {0}\n", Client);
            }

            if (!String.IsNullOrEmpty(HiringManager))
            {
                builder.AppendFormat("HiringManager: {0}\n", HiringManager);
            }

            if (!String.IsNullOrEmpty(AddressCity))
            {
                builder.AppendFormat("AddressCity: {0}\n", AddressCity);
            }

            if (!String.IsNullOrEmpty(AddressPostCode))
            {
                builder.AppendFormat("AddressCity: {0}\n", AddressCity);
            }
            if (!String.IsNullOrEmpty(AddressCountry))
            {
                builder.AppendFormat("AddressCity: {0}\n", AddressCity);
            }

            if (!Double.IsNaN(Salary))
            {
                builder.AppendFormat("Salary: {0}\n", Salary);
            }

            return builder.ToString();
        }
    }
}
