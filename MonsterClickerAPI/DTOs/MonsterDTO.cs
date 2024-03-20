using MonsterClickerAPI.Models;

namespace MonsterClickerAPI.DTOs
{
    public class MonsterDTO
    {
        public int Id { get; set; }
        public string MonsterName { get; set; }
        public string MonsterSpriteUrl { get; set; }
        public float BaseHealth { get; set; }
        public float ExtraHealth { get; set; }
        public int GoldDrop { get; set; }
        public int Location { get; set; }
        public ICollection<ItemDTO> Items { get; set; } 
    }
}
