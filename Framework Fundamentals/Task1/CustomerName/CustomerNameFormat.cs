using System;
using System.Text;

namespace Customer.CustomerName
{
    /// <summary>
    /// The class represents customer name formatting.
    /// </summary>
    public class CustomerNameFormat : ICustomFormatter, IFormatProvider
    {
        /// <summary>
        /// The method returns formatted customer depending on format type.
        /// </summary>
        /// <param name="customer">Customer to format.</param>
        /// <param name="customerFormat">The format of the customer name printing.</param>
        /// <returns>Formatter customer name.</returns>
        public static string GetFormattedCustomerName(Customer customer, CustomerFormat customerFormat)
        {
            string formatedName = String.Empty;

            switch (customerFormat.NameRepresentation)
            {
                case NameRepresentation.NameFormat:
                    {
                        //Just name
                        formatedName = String.Format(new CustomerNameFormat(), "{0:NameFormat}", customer.Name);
                        break;
                    }
                case NameRepresentation.NameInitialFormat:
                    {
                        //Name with initials
                        formatedName = String.Format(new CustomerNameFormat(), "{0:NameInitialFormat}", customer.Name);
                        break;
                    }
                default:
                    {
                        //Full name
                        formatedName = String.Format(new CustomerNameFormat(), "{0}", customer.Name);
                        break;
                    }
            }

            return formatedName;
        }

        /// <summary>
        /// Converts the value of a specified object to an equivalent string representation 
        /// using specified format and culture-specific formatting information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg">The object to format.</param>
        /// <param name="customerFormatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A copy of format in which the format item or items have been 
        /// replaced by the string representation of argument.</returns>
        public string Format(string format, object arg, IFormatProvider customerFormatProvider)
        {
            if (format == "NameInitialFormat")
            {
                return NameInitialsFormat(arg.ToString());
            }

            if (format == "NameFormat")
            {
                return NameFormat(arg.ToString());
            }

            return arg.ToString();
        }

        /// <summary>
        /// Returns an object that provides formatting services for the specified type.
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return.</param>
        /// <returns>An instance of the object specified by formatType 
        /// if the IFormatProvider implementation can supply that type of object; otherwise, null.</returns>
        public object GetFormat(Type formatType)
        {

            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }

        /// <summary>
        /// The method converts the full name into the format "Name".
        /// </summary>
        /// <param name="name">Full name to convert.</param>
        /// <returns>First name in full name.</returns>
        private string NameFormat(string name)
        {
            var nameArray = name.Split(' ');

            return nameArray[0];
        }

        /// <summary>
        /// The method converts the full name into the format "Name S.P.".
        /// </summary>
        /// <param name="name">Full name to convert.</param>
        /// <returns>Name with initials.</returns>
        private string NameInitialsFormat(string fullName)
        {
            var nameInitials = new StringBuilder();
            var nameArray = fullName.Split(' ');

            for (int i = 0; i < nameArray.Length; i++)
            {
                if (i == 0)
                {
                    var name = nameArray.Length == 1 ? nameArray[0] : nameArray[0] + " ";
                    nameInitials.Append(name);
                    continue;
                }

                nameInitials.Append(char.ToUpper(nameArray[i][0]).ToString() + ".");
            }

            return nameInitials.ToString();
        }
    }
}
