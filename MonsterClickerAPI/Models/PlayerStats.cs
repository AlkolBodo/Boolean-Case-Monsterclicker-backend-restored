using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.DataProtection;
using MonsterClickerAPI.Enumfolder;

namespace MonsterClickerAPI.Models
{
    [Table("player_stats")]
    public class PlayerStats
    {
        [Key]
        [Column("id")] public int Id { get; set; }
        [Column("user_id")][ForeignKey("AppUser")] public string UserId { get; set; }
        public AppUser AppUser { get; set; }

        [Column("click_damage")] public float ClickDamage { get; set; }
        [Column("crit_chance")] public float CritChance { get; set; }
    }
}
