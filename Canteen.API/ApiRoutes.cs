﻿namespace Canteen.API
{
    public class ApiRoutes
    {
        public const string BaseRoute = "api/v{version:apiVersion}/[controller]";

        public class UserProfiles
        {
            public const string IdRoute = "{id}";
        }

        public class MenuItems
        {
            public const string IdRoute = "{id}";
        }
    }
}
