using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MonsterClickerAPI.Enumfolder;

namespace MonsterClickerAPI.Models
{
    [Table("player_inventory")]
    public class PlayerInventory
    {
        [Key]
        [Column("id")] public int Id { get; set; }
        [Column("user_id")][ForeignKey("AppUser")] public string UserId { get; set; }
        public AppUser AppUser { get; set; }

        [Column("item_id")][ForeignKey("Item")] public int ItemId { get; set; }
        public Item Item { get; set; }

        [Column("amount")] public int Amount { get; set; }

    }
}
