namespace SmartWeightAPI.Controllers
{
    public enum Endpoints
    {
        CONNECTIONS,
        MEASUREMENTS,
        PARTIAL_MEASUREMENTS,
        USERS
    }

    public abstract partial class BaseModelController<Entity>
    {
        protected readonly Dictionary<Endpoints, string> _endpoints = new Dictionary<Endpoints, string>
        {
            {Endpoints.CONNECTIONS, "connections"},
            {Endpoints.MEASUREMENTS, "measurements"},
            {Endpoints.PARTIAL_MEASUREMENTS, "measurements/partials"},
            {Endpoints.USERS, "users"}
        };
    }
}
