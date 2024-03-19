using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MonsterClickerAPI.Models;

namespace MonsterClickerAPI.Data
{

    public class Seeder
    {
        private List<Item> _items = new List<Item>();
        private List<Monster> _monsters = new List<Monster>();
        private List<MonsterItemTable> monsterItemTables = new List<MonsterItemTable>();
        private List<MonsterStats> _stats = new List<MonsterStats>();


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

        };


        public Seeder()
        {
            
        }
    }


}
