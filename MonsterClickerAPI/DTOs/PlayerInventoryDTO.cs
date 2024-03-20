using MonsterClickerAPI.Models;

namespace MonsterClickerAPI.DTOs
{
    public class PlayerInventoryDTO
    {

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemSpriteUrl { get; set; }
        public int Amount { get; set; }

    }
}
