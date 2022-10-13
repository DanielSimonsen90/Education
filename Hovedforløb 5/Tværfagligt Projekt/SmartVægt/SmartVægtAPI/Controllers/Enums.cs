namespace SmartWeightAPI.Controllers
{
    public enum Endpoints
    {
        CONNECTIONS,
        MEASUREMENTS,
        PARTIAL_MEASUREMENTS,
        USERS
    }

    public enum MeasurementPartialTypes
    {
        USER,
        PARTIAL_MEASUREMENT
    }

    public enum MeasurementFilter
    {
        ALL,
        FULL,
        PARTIALS
    }
}
