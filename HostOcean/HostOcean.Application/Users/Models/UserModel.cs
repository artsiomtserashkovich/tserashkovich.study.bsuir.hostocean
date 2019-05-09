using HostOcean.Application.Groups.Models;

namespace HostOcean.Application.Users.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string GroupId { get; set; }
        public GroupModel Group { get; set; }
    }
}