using HostOcean.Application.UserQueues.Models;
using HostOcean.Application.Users.Models;
using HostOcean.Domain.Entities;
using System;

namespace HostOcean.Application.Requests.Models
{
    public class RequestModel
    {
        public string Id { get; set; }

        public string CreatorUserId { get; set; }
        public UserModel CreatorUser { get; set; }

        public string ReceiverUserId { get; set; }
        public UserModel ReceiverUser { get; set; }

        public RequestType Type { get; set; }
        public RequestState State { get; set; }
        public DateTime CreatedOn { get; set; }

        public string QueueId { get; set; }
    }
}
