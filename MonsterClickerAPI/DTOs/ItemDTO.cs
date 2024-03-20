namespace MonsterClickerAPI.DTOs
{
    public class ItemDTO
    {
        public string ItemName { get; set; }
        public string ItemSpriteUrl { get; set; }
        public float Value { get; set; }   
        public float DropRate { get; set; }
        public int MinDrop { get; set; }
        public int MaxDrop { get; set; }
        
    }
}
