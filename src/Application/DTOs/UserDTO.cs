using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;
using Domain.enums;

namespace Application.DTOs
{
    public class UserDTO
    {
        [NotMapped]
        public Guid Id { get; set; }
        [NotMapped]
        public string Name { get; set; }
        [NotMapped]
        public string EmailAddress { get; set; }
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string NewPassword { get; set; }
        [NotMapped]
        public bool ReceiveEmail { get; set; }
        [NotMapped]
        public string? ImageUrl { get; set; }
        [NotMapped]
        public Role Role { get; set; }

        public UserDTO()
        {
            
        }

        public UserDTO(User user)
        {
            Id = user.Id;
            Name = user.Name;
            EmailAddress = user.EmailAddress;
            Role = user.Role;
        }
    }
}