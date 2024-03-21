using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MonsterClickerAPI.Enumfolder;

namespace MonsterClickerAPI.Models
{
    [Table("user_statistic")]
    public class UserStats
    {
        [Key]
        [Column("id")] public int Id { get; set; }
        [Column("user_id")] [ForeignKey("AppUser")] public string UserId { get; set; }
        public AppUser AppUser { get; set; }
        [Column("clicks")] public int Clicks { get; set; }
        [Column("monsters_killed")] public int MonstersKilled { get; set; }
    }
}
