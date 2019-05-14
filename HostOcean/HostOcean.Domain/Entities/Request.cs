using Newtonsoft.Json;
using System;

namespace HostOcean.Domain.Entities
{
    public class Request : Entity
    {
        public string CreatorUserId { get; set; }
        public virtual User CreatorUser { get; set; }
        public string ReceiverUserId { get; set; }
        public virtual User ReceiverUser { get; set; }

        public string QueueId { get; set; }

        public RequestType Type { get; set; }
        public RequestState State { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
