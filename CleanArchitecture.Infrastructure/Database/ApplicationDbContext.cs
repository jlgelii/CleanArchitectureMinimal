using CleanArchitecture.Application.Configurations.Database;
using CleanArchitecture.Application.Configurations.Services;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Database
{
    public class ApplicationDbContext : AppDbContext, IApplicationDatabase
    {
        private readonly IJwtServices _jwtServices;
        private readonly IDateTimeServices _dateTimeServices;

        public ApplicationDbContext(IConfiguration configuration,
            IJwtServices jwtServices,
            IDateTimeServices dateTimeServices) : base(configuration.GetConnectionString("DefaultConnection"))
        {
            this._jwtServices = jwtServices;
            this._dateTimeServices = dateTimeServices;
        }

        void IApplicationDatabase.SaveChanges()
        {
            SaveChanges();
        }


        public override int SaveChanges()
        {
            if (_jwtServices.GetLoggedUser() == null)
                return base.SaveChanges();

            foreach (var entry in ChangeTracker.Entries<BaseEntities>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _jwtServices.GetLoggedUser().UserId;
                        entry.Entity.CreatedDate = _dateTimeServices.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = _jwtServices.GetLoggedUser().UserId;
                        entry.Entity.UpdatedDate = _dateTimeServices.Now;
                        break;
                }
            }

            return base.SaveChanges();
        }
    }
}
