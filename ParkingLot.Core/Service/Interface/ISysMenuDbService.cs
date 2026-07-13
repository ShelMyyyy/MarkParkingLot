using ParkingLot.Models.DataBaseModels;

namespace ParkingLot.Core.Service.Interface
{
    public interface ISysMenuDbService : IDbBaseService
    {
        public IEnumerable<SysMenu> GetMenuList();
    }
}
