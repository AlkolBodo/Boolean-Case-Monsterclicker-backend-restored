using MonsterClickerAPI.Models;

namespace MonsterClickerAPI.DTOs
{
    public class MonsterDTO
    {
        public string MonsterName { get; set; }
        public string MonsterSpriteUrl { get; set; }
        public float Health { get; set; }
        public int GoldDrop { get; set; }
        public ICollection<ItemDTO> Items { get; set; } 
    }
}
