namespace HostOcean.Domain.Entities
{
    public enum RequestType
    {
        PlaceSwap = 0
    }

    public enum RequestState
    {
        Pending = 0,
        Declined = 1,
        Accepted = 2,
        Expired = 3
    }
}
