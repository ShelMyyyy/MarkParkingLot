using ParkingLot.Core.Service.Interface;
using ParkingLot.Models.DataBaseModels;
using ParkingLot.ORM;

namespace ParkingLot.Core.Service.DBServices
{
    public class SysMenuDbService : DbBaseService<ParkingLotDbContext>, ISysMenuDbService
    {
        public SysMenuDbService(ParkingLotDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<SysMenu> GetMenuList()
        {
            return Query<SysMenu>(x => 1 == 1).ToList();
        }
    }
}
