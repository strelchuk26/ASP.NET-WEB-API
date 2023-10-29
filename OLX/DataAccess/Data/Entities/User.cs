using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Data.Entities
{
    public class User : IdentityUser
    {
        public ICollection<Advert> Adverts { get; set; }
    }
}
