using Microsoft.AspNetCore.Mvc;
using MonsterClickerAPI.DTOs;
using MonsterClickerAPI.IRepo;
using MonsterClickerAPI.Models;
using MonsterClickerAPI.Payload;
using System.Runtime.CompilerServices;

namespace MonsterClickerAPI.Endpoints
{
    public static class MonsterEndpoint
    {
        public static void ConfigureMonsterEndpoint (this WebApplication webApp)
        {
            var monsters = webApp.MapGroup("monsters");
            monsters.MapGet("/", GetMonsters);
            ///monsters.MapGet("/{id}", GetMonsterById);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetMonsters(IRepository<Monster> repository)
        {
            var result = await repository.GetAll();
            List<MonsterDTO> monsterDTOs = new List<MonsterDTO>();

            foreach (var monster in result)
            {
                MonsterDTO dto = new MonsterDTO()
                {
                    MonsterName = monster.MonsterName,
                    MonsterSpriteUrl = monster.MonsterSpriteUrl,
                    MonsterStats = new MonsterStatsDTO()
                    {
                        Health = monster.MonsterStats.Health,
                        GoldDrop = monster.MonsterStats.GoldDrop
                    }
                };
                monsterDTOs.Add(dto);
            }

            Payload<IEnumerable<MonsterDTO>> payload = new Payload<IEnumerable<MonsterDTO>>();
            payload.data = monsterDTOs;
            return TypedResults.Ok(payload);
        }
    }
}
