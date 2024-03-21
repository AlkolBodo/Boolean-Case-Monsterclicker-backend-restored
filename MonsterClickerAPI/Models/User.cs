using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonsterClickerAPI.Models
{
    [Table("user")]
    public class User
    {
        [Column("id")] [Key] public string Id { get; set; }
        [Column("username")] public string Username { get; set; }   
        [Column("password")] public string Password { get; set; }
        [Column("email")] public string Email { get; set; }

    }
}
