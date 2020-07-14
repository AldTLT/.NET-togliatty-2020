using System.Globalization;
using Customer.CustomerName;
using Customer.CustomerRevenue;

namespace Customer
{
    /// <summary>
    /// The class represents customer format data.
    /// </summary>
    public class CustomerFormat
    {
        /// <summary>
        /// Representation of customer data for printing.
        /// </summary>
        public CustomerRepresentation CustomerRepresentation = CustomerRepresentation.NameRevenuePhone;

        /// <summary>
        /// Representation of customer name for printing.
        /// </summary>
        public NameRepresentation NameRepresentation = NameRepresentation.FullNameFormat;

        /// <summary>
        /// Representation of revenue for printing.
        /// </summary>
        public RevenueRespresentation RevenueRepresentation = RevenueRespresentation.Number;

        /// <summary>
        /// Culturell info for revenue representation.
        /// </summary>
        public CultureInfo CulturelInfo = new CultureInfo(string.Empty);
    }
}
