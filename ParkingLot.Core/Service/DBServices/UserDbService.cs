using Microsoft.EntityFrameworkCore;
using ParkingLot.Core.Service.Interface;
using ParkingLot.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Core.Service.DBServices
{
    public class UserDbService : DbBaseService<UserDbContext>, IUserDbService
    {
        public UserDbService(UserDbContext dbContext) : base(dbContext)
        {
        }
    }
}
