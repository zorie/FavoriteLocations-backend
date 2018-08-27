using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FavLocs.Models
{
    public class Location
    {
        private ICollection<User> usersWhoLikedThis;
        public Location()
        {
            this.usersWhoLikedThis = new HashSet<User>();
        }

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(60)]
        public string Name { get; set; }

        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string Author { get; set; }
        //public virtual User Author { get; set; }

        public virtual ICollection<User> UsersWhoLikedThis
        {
            // validations
            get { return this.usersWhoLikedThis; }
            set { this.usersWhoLikedThis = value; }
        }
    }
}
