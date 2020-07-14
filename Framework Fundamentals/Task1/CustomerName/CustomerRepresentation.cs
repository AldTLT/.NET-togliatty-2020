namespace Customer
{
    /// <summary>
    /// The customer representation for the printing. Selection of components for output.
    /// </summary>
    public enum CustomerRepresentation
    {
        //Output customer name.
        Name = 0,

        //Output customer phone.
        Phone = 1,

        //Output customer revenue.
        Revenue = 2,

        //Output customer name and phone.
        NamePhone = 3,

        //Output customer name and revenue.
        NameRevenue = 4,

        //Output customer revenue and phone.
        RevenuePhone = 5,

        //Output full customer data.
        NameRevenuePhone = 6
    }
}
