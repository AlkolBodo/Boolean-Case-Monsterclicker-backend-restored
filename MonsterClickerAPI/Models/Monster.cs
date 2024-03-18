using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonsterClickerAPI.Models
{
    [Table("monster")]
    public class Monster
    {
        [Key][Column("id")] public int Id { get; set; }
        [Column("monster_name")] public string MonsterName { get; set; }
        [Column("monster_sprite_ulr")] public string MonsterSpriteUrl { get; set; }

    }
}
