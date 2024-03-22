using MonsterClickerAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonsterClickerAPI.DTOs
{
    public class UserStatsDTO
    { 
        public int Clicks { get; set; }
        public int MonstersKilled { get; set; }
        public int Gold { get; set; }
    }
}

