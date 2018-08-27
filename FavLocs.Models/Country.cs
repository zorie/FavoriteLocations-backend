using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// using System.ComponentModel.DataAnnotations.Schema;

namespace FavLocs.Models
{
    public class Country
    {
        private ICollection<Location> locations;

        public Country()
        {
            this.locations = new HashSet<Location>();
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        // does not recognize it
        // [Index(IsUnique = true)]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Location> Locations
        {
            get { return this.locations; }
            set { this.locations = value; }
        }
    }
}