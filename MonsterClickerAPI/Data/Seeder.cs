using MonsterClickerAPI.Models;

namespace MonsterClickerAPI.Data
{

    public class Seeder
    {
        private List<Item> _items = new List<Item>();

        public List<Item> Items { get { return _items; } }

        public Seeder()
        {
            Items.Add(new Item(){Id = 1, ItemName = "Bone", ItemSpriteUrl = "NONE"});
        }
    }


}
