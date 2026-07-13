using System.ComponentModel.DataAnnotations;

namespace ParkingLot.Models.DataBaseModels
{
    public class SysMenu
    {
        [Key]
        public int Id { get; set; }
        public string? Header { get; set; }
        public string? TargetView { get; set; }
        public int? ParentId { get; set; }
        public string? MenuIcon { get; set; }
        public int? Index { get; set; }
        public int? MenuType { get; set; }
        public int State { get; set; }
    }
}
