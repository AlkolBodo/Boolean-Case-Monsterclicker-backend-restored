using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonsterClickerAPI.Models
{
    [Table("player_inventory")]
    public class PlayerInventory
    {
        [Key]
        [Column("id")] public int Id { get; set; }
        [Column("player_id")][ForeignKey("User")] public int UserId { get; set; }
        public User User { get; set; }

        [Column("item_id")][ForeignKey("Item")] public int ItemId { get; set; }
        public Item Item { get; set; }

        [Column("amount")] public int Amount { get; set; }

    }
}
