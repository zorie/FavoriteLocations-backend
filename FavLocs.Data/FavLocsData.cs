using FavLocs.Data.Contracts;
using System;
using FavLocs.Data.Repositories;
using FavLocs.Models;

namespace FavLocs.Data
{
    public class FavLocsData : IFavLocsData
    {
        private readonly IFavLocsDbContext dbContext;
        public FavLocsData(
            IFavLocsDbContext dbContext,
            IEFRepository<Location> locationsRepo,
            IEFRepository<User> usersRepo,
            IEFRepository<Country> countriesRepo)
        {
            if(dbContext == null)
            {
                throw new ArgumentNullException("Database context cannot be null.");
            }

            if (locationsRepo == null)
            {
                throw new ArgumentNullException("Locations repo cannot be null.");
            }

            if (usersRepo == null)
            {
                throw new ArgumentNullException("Users repo cannot be null.");
            }                                             
                                                          
            if (countriesRepo == null)                    
            {                                             
                throw new ArgumentNullException("Countries repo cannot be null.");
            }

            this.dbContext = dbContext;
            this.Users = usersRepo;
            this.Locations = locationsRepo;
            this.Countries = countriesRepo;
        }
        public IEFRepository<Country> Countries { get; private set; }

        public IEFRepository<Location> Locations { get; private set; }

        public IEFRepository<User> Users { get; private set; }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }
    }
}
