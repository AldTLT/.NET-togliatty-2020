using System;
using System.Text.RegularExpressions;
using Customer.CustomerName;
using Customer.CustomerPhone;
using Customer.CustomerRevenue;

namespace Customer
{
    /// <summary>
    /// The class represents customer, that contains customer name, contact phone and revenue.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Full name of customer.
        /// </summary>
        public string Name { 
            get 
            {
                return Name;
            }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name not set");
                }

                Name = value;
            } 
        }

        /// <summary>
        /// Contact phone of customer, three or more symbols.
        /// </summary>
        public string ContactPhone {
            get 
            {
                return ContactPhone;
            }
        set
            {
                if (string.IsNullOrEmpty(value))
                {
                    var message = "Contact phone not set";
                    throw new ArgumentException(message);
                }

                var phoneIsCorrect = new Regex(@"^\+?\d{3,11}$").IsMatch(value);

                if (!phoneIsCorrect)
                {
                    var message = "Contact phone not correct. The contact phone may start with a plus and must contain three to eleven digits!";
                    throw new ArgumentException(message);
                }

                ContactPhone = value;
            }
        }

        /// <summary>
        /// Revenue of customer.
        /// </summary>
        public decimal Revenue { 
            get 
            {
                return Revenue;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Revenue must be positiv!");
                }

                Revenue = value;
            }
        }

        /// <summary>
        /// Constructor of Customer class.
        /// </summary>
        /// <param name="name">Customer name.</param>
        /// <param name="contactPhone">Customer contact phone.</param>
        /// <param name="revenue">Customer revenue.</param>
        public Customer(string name, decimal revenue, string contactPhone)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }

        /// <summary>
        /// Print customer default.
        /// </summary>
        public string PrintCustomer()
        {
            return PrintCustomer(new CustomerFormat());
        }

        /// <summary>
        /// The method returns formatted string, contains customer data according customer format.
        /// </summary>
        /// <param name="customerFormat">Customer format.</param>
        public string PrintCustomer(CustomerFormat customerFormat)
        { 
            var name = CustomerNameFormat.GetFormattedCustomerName(this, customerFormat);
            var contactPhone = CustomerContactPhoneFormat.GetFormattedCustomerPhone(this.ContactPhone);
            var revenue = CustomerRevenueFormat.GetFormattedRevenue(this.Revenue, customerFormat);

            switch (customerFormat.CustomerRepresentation)
            {
                case CustomerRepresentation.Name:
                    {
                        return string.Format("- Customer record: {0}", name);
                    }

                case CustomerRepresentation.Phone:
                    {
                        return string.Format("- Customer record: {0}", contactPhone);
                    }

                case CustomerRepresentation.Revenue:
                    {
                        return string.Format("- Customer record: {0}", revenue);
                    }

                case CustomerRepresentation.NamePhone:
                    {
                        return string.Format("- Customer record: {0}, {1}", name, contactPhone);
                    }

                case CustomerRepresentation.NameRevenue:
                    {
                        return string.Format("- Customer record: {0}, {1}", name, revenue);
                    }

                case CustomerRepresentation.RevenuePhone:
                    {
                        return string.Format("- Customer record: {0}, {1}", revenue, contactPhone);
                    }

                default:
                    {
                        return string.Format("- Customer record: {0}, {1}, {2}", name, revenue, contactPhone);
                    }
            }
        }
    }
}
