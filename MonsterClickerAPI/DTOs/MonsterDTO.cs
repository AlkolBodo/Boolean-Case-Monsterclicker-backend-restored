using MonsterClickerAPI.Models;

namespace MonsterClickerAPI.DTOs
{
    public class MonsterDTO
    {
        public string MonsterName { get; set; }
        public string MonsterSpriteUrl { get; set; }
        public MonsterStatsDTO MonsterStats { get; set; }

    }
}
