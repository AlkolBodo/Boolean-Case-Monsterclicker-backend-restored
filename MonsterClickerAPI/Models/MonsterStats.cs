using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonsterClickerAPI.Models
{
    [Table("monster_stats")]
    public class MonsterStats
    {
        [Key][Column("id")] public int Id { get; set; }
        [Column("monster_id")] [ForeignKey("Monster")] public int MonsterId { get; set; }
        public Monster Monster { get; set; }
        [Column("health")] public float Health { get; set; }
        [Column("gold_drop")] public int GoldDrop { get; set; }
    }
}
