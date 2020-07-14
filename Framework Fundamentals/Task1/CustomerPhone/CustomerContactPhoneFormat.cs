using System.Linq;

namespace Customer.CustomerPhone
{
    /// <summary>
    /// The class represents customer contact phone formatting.
    /// </summary>
    public static class CustomerContactPhoneFormat
    {
        /// <summary>
        /// The method returns formatted string depending on the digits numbers.
        /// </summary>
        /// <param name="contactPhone">Contact phone to format.</param>
        ///  <returns>Formated phone number.</returns>
        public static string GetFormattedCustomerPhone(string contactPhone)
        {
            string formatContactPhone = string.Empty;
            var sign = contactPhone.First().Equals('+') ? "+" : "";
            var phoneNumber = double.Parse(contactPhone);
            var phoneLength = contactPhone.Length;

            //Switch according to phone length.
            switch (phoneLength)
            {
                case 3:
                    {
                        formatContactPhone = string.Format("{0:###}", phoneNumber);
                        break;
                    }
                case 4:
                    {
                        formatContactPhone = string.Format("{0:##-##}", phoneNumber);
                        break;
                    }
                case 5:
                    {
                        formatContactPhone = string.Format("{0:###-##}", phoneNumber);
                        break;
                    }
                case 6:
                    {
                        formatContactPhone = string.Format("{0:##-##-##}", phoneNumber);
                        break;
                    }
                case 7:
                    {
                        formatContactPhone = string.Format("{0:###-##-##}", phoneNumber);
                        break;
                    }
                case 8:
                    {
                        formatContactPhone = string.Format("{0:####-##-##}", phoneNumber);
                        break;
                    }
                case 9:
                    {
                        formatContactPhone = string.Format("{0:(###)##-##-##}", phoneNumber);
                        break;
                    }
                case 10:
                    {
                        formatContactPhone = string.Format("{0:#(###)##-##-##}", phoneNumber);
                        break;
                    }
                case 11:
                    {
                        formatContactPhone = string.Format("{0:#(###)###-##-##}", phoneNumber);
                        break;
                    }
                default:
                    {
                        formatContactPhone = string.Format("{0:#(###)###-##-##}", phoneNumber);
                        break;
                    }
            }
                       
            return sign + formatContactPhone;
        }
    }
}
