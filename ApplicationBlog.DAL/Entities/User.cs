using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApplicationBlog.DAL.Entities
{
    public class User : IdentityUser
    {
        [DisplayName("Prenom")]
        public string? FirstName { get; set; }
        [DisplayName("Nom")]
        public string? LastName { get; set; }
        [DisplayName("Photo de profile")]
        public string? profilePic { get; set; }
    }
}
