using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MonsterClickerAPI.Models;

namespace MonsterClickerAPI.Data
{

    public class Seeder
    {
        private List<Monster> _monsters = new List<Monster>();
        private List<MonsterStats> _stats = new List<MonsterStats>();
        private List<Item> _items = new List<Item>();
        private List<MonsterItemTable> monsterItemTables = new List<MonsterItemTable>();


        //All monsters
        private List<string> _monsternames = new List<string>() 
        {
            //Crypt stage
            "Mass of Bones", //Broken amulet
            "Fallen Angel", //broken discusting fork
            "Crypt Bat", //Ancient sweet bag
            "Purple Demon", //fossilized banana
            "Starfish Lich", //grand old bag
            "Wraith", //huge book
            "Valkyrie", //overlord (1)
            "Vengeful chimera", //salty beet
            "Arms", //sweet sunflower
            "Broken warrior", //terrible artichoke
            //Field stage
            "Possessed Corn", //big corn
            "Haunted Beetle", //dark amulet
            "Corrupted Mantis", //Ancient shallot
            "Toxic Presence", //huge fork
            "Corrupted spider", //massive pencil
            "Corrupting fungus", //quartz cloud
            "Mysterious Bread", //we know
            "Corrupted lizard", //small sandals
            "Farm golem", //stone carrot
            "Forgotten farmer", //spicy sandals of purifying
            //Atlantis
            "Ancient golem", //cheesy brocoli
            "Azure Ghoul", //crusty beautiful vitamins
            "Cannonhead", //dark metal alien
            "Futuristic frog", //floating banana
            "Surveilance Drone", //fresh cheesy pepper
            "PK-3000", //light gem
            "Atlantian spirit", //salty banana
            "Emerald squid", //spicy quartz sunflower
            "Sentient shrine", //toxic wooden finger
            "Watcher" //unique squash
        };

        private string urlstring = "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/";
        private string pngaddon = ".png";

        //All the urls
        private List<string> _spriteurls = new List<string>()
        {
            "Broken%20Amulet",
            "Broken%20Discusting%20Fork",
            "Ancient%20Sweet%20Bag",
            "Fossilized%20Banana",
            "Grand%20Old%20Bag",
            "Huge%20Book",
            "Overlord%20(1)",
            "Salty%20Beet",
            "Sweet%20Sunflower",
            "Terrible%20Artichoke",
            //Field stage
            "Big%20Corn",
            "Dark%20Amulet",
            "Ancient%20Shallot",
            "Huge%20Fork",
            "Massive%20Pencil",
            "Quartz%20Cloud",
            "Mysterious%20Bread",
            "Small%20Sandals",
            "Stone%20Carrot",
            "Spicy%20Sandals%20Of%20Purifying",
            //Atlantis
            "Cheesy%20Broccoli",
            "Crusty%20Beautiful%20Vitamins",
            "Dark%20Metal%20Alien",
            "Floating%20bBanana",
            "Fresh%20Cheesy%20Pepper",
            "Light%20Gem",
            "Salty%20Banana",
            "Spicy%20Quartz%20Sunflower",
            "Toxic%20Wooden%20Finger",
            "Unique%20Squash"
        };

    

        static Random random = new Random();

        //Basehealth for monsters
        private int baseHealth = 10;

        //Extra health randomizer
        private int generateHealth()
        {
            return random.Next(5, 10);
        }
        //Gold drop randomizer
        private int generateGoldDrop()
        {
            return random.Next(1, 5);
        }




        //All items
        private List<string> _monsteritems = new List<string>()
        {
            "Bone",
            "Blob",
            "Spirit energy",
            "Scrap",
        };


        public Seeder()
        {
            int amount = _monsternames.Count();
            for (int x = 1; x < amount+1; x++)
            {
                //  missing location
                Monster monster = new Monster();
                monster.Id = x;
                monster.MonsterSpriteUrl = urlstring + _spriteurls[x-1] + pngaddon;
                monster.Location = (x-1) / 10;
                monster.MonsterName = _monsternames[x-1];
                _monsters.Add(monster);
            }

            for (int i = 1; i < amount+1; i++)
            {   
                //  missing min/max health/gold
                MonsterStats stats = new MonsterStats();
                stats.Id = i;
                stats.MonsterId = i; 
                stats.BaseHealth = baseHealth;
                stats.ExtraHealth = generateHealth();
                stats.GoldDrop = generateGoldDrop();
                _stats.Add(stats);
            }

            for (int i = 1; i < _monsteritems.Count()+1; i++)
            {
                Item item = new Item();
                item.Id = i;
                item.ItemName = _monsteritems[i-1];
                item.ItemSpriteUrl = urlstring + _spriteurls[i];    
                _items.Add(item);
            }

            int idSetter = 1;
            for (int i = 1; i < amount + 1; i++)
            {
                for(int j = 0; j < random.Next(1, 3); j++)
                {
                    MonsterItemTable drop = new MonsterItemTable();
                    drop.Id = idSetter++;
                    drop.MonsterId = i;
                    do
                    {
                    drop.ItemId = _items[random.Next(_items.Count)].Id;
                    }while (0 < monsterItemTables.Where(p => p.MonsterId == i && p.ItemId == drop.ItemId).Count()); 
                    drop.DropRate = random.Next(20, 80);
                    drop.MinDrop = random.Next(1, 5);
                    drop.MaxDrop = drop.MinDrop + random.Next(1, 5);
                    monsterItemTables.Add(drop);
                }
            }
        }
        public List<Monster> Monsters { get { return _monsters; } }
        public List<MonsterStats> Stats { get { return _stats; } }
        public List<Item> Items {  get { return _items; } }
        public List<MonsterItemTable> MonsterItemTables { get { return monsterItemTables; } }
    }


}
