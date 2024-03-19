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
        public static async Task<IResult> GetMonsters(IRepository<Monster> monsterrepository, IRepository<MonsterStats> statsrepo, IRepository<MonsterItemTable> monstertablerepo)
        {
            var result = await monsterrepository.GetAll();
            var statsresult = await statsrepo.GetAll();
            var tablesresult = await monstertablerepo.GetAll();


            List<MonsterDTO> monsterDTOs = new List<MonsterDTO>();
            

            foreach (var monster in result)
            {
                List<ItemDTO> monsteritems = new List<ItemDTO>();
                foreach (var monstertable in tablesresult)
                {
                    if ( monster.Id == monstertable.MonsterId)
                    {
                        ItemDTO item = new ItemDTO()
                        {
                            ItemName = monstertable.Item.ItemName,
                            ItemSpriteUrl = monstertable.Item.ItemSpriteUrl,
                            DropRate = monstertable.DropRate,
                            MinDrop = monstertable.MinDrop,
                            MaxDrop = monstertable.MaxDrop,
                        };
                        monsteritems.Add(item);
                    }
                }

                MonsterDTO dto = new MonsterDTO()
                {
                   MonsterName = monster.MonsterName,
                   MonsterSpriteUrl = monster.MonsterSpriteUrl,
                   GoldDrop = ,
                   Health = ,
                   Items = monsteritems.ToArray()

                };
                monsterDTOs.Add(dto);
            }


            Payload<IEnumerable<MonsterDTO>> payload = new Payload<IEnumerable<MonsterDTO>>();
            payload.data = monsterDTOs;
            return TypedResults.Ok(payload);
        }
    }
}
