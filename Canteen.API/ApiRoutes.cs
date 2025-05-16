namespace Canteen.API
{
    public class ApiRoutes
    {
        public const string BaseRoute = "api/v{version:apiVersion}/[controller]";
        public const string OrdersBase = "orders";

        public class UserProfiles
        {
            public const string IdRoute = "{id}";
            public const string FirstNameRoute = "{id}/firstName";
            public const string LastNameRoute = "{id}/lastName";
            public const string EmailRoute = "{id}/email";
            public const string PhoneRoute = "{id}/phone";
            public const string DateOfBirthRoute = "{id}/dateOfBirth";
            public const string CurrentCityRoute = "{id}/currentCity";
        }

        public class MenuItems
        {
            public const string IdRoute = "{id}";
            public const string NameRoute =  "/{id}/name";
            public const string DescriptionRoute =  "/{id}/description";
            public const string PriceRoute =  "/{id}/price";
        }

        

        public static class Orders
        {
            public const string IdRoute = "{id}";
            public const string StatusRoute = "/{id}/status";
            public const string Create = OrdersBase;
            public const string GetById = OrdersBase + "/{id}";
            public const string UpdateStatus = OrdersBase + "/{id}/status";
        }

        public class OrderItems
        {
            public const string IdRoute = "{id}";
            public const string NameRoute = "/{id}/name";
            public const string PriceRoute = "/{id}/price";
            public const string QuantityRoute = "/{id}/quantity";
        }
    }
}
