using ParkingLot.Core.Service.Interface;
using ParkingLot.ORM;

namespace ParkingLot.Core.Service.DBServices
{
    public class UserDbService : DbBaseService<ParkingLotDbContext>, IUserDbService
    {
        public UserDbService(ParkingLotDbContext dbContext) : base(dbContext)
        {
        }
    }
}
