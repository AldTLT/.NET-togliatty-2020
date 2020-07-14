using System;
using System.Globalization;

namespace Customer.CustomerRevenue
{
    /// <summary>
    /// The class represents customer revenue formating.
    /// </summary>
    public class CustomerRevenueFormat
    {
        /// <summary>
        /// The method returns formatted revenue depending on the formatting.
        /// </summary>
        /// <param name="revenue">Revenue to format.</param>
        /// <param name="customerFormat">Revenue formatting.</param>
        /// <returns>Formatted revenue</returns>
        public static string GetFormattedRevenue(decimal revenue, CustomerFormat customerFormat)
        {
            CultureInfo.CurrentCulture = customerFormat.CulturelInfo;

            switch (customerFormat.RevenueRepresentation)
            {
                case RevenueRespresentation.Decimal:
                    {
                        return String.Format("{0:D}", (int)revenue);
                    }

                case RevenueRespresentation.Number:
                    {
                        return String.Format("{0:N}", revenue);
                    }

                default:
                    {
                        throw new FormatException("Unknown revenue representation");
                    }
            }
        }
    }
}
