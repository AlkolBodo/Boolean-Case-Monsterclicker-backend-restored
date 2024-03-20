using Microsoft.AspNetCore.Mvc;
using MonsterClickerAPI.DTOs;
using MonsterClickerAPI.IRepo;
using MonsterClickerAPI.Models;
using MonsterClickerAPI.Payload;
using System.Runtime.CompilerServices;
using System.Threading;

namespace MonsterClickerAPI.Endpoints
{
    public static class MonsterEndpoint
    {
        public static void ConfigureMonsterEndpoint (this WebApplication webApp)
        {
            var monsters = webApp.MapGroup("monsters");
            monsters.MapGet("/", GetMonsters);
            monsters.MapGet("/bestiary/{limit}/{offset}", GetMonstersBestiary);
            monsters.MapGet("/{id}", GetMonsterById);
            monsters.MapGet("/stage/{stage}", GetMonstersByStage);
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
                var monsterstats = statsresult.FirstOrDefault(x  => x.Id == monster.Id);

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

                    Id = monster.Id,
                    MonsterName = monster.MonsterName,
                    MonsterSpriteUrl = monster.MonsterSpriteUrl,
                    GoldDrop = monsterstats?.GoldDrop ?? 0,
                    BaseHealth = monsterstats?.BaseHealth ?? 0,
                    ExtraHealth = monsterstats?.ExtraHealth ?? 0,
                    Location = monster.Location,
                    Items = monsteritems.ToArray()
                };
                monsterDTOs.Add(dto);
            }


            Payload<IEnumerable<MonsterDTO>> payload = new Payload<IEnumerable<MonsterDTO>>();
            payload.data = monsterDTOs;
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> GetMonsterById(IRepository<Monster> monsterrepo, IRepository<MonsterStats> statsrepo, IRepository<MonsterItemTable> monstertablerepo, int id)
        {
            var result = await monsterrepo.GetById(id);
            var statsresult = await statsrepo.GetById(id);
            var tablesresult = await monstertablerepo.GetAll();

            List<ItemDTO> items = new List<ItemDTO>();
            foreach (var table in tablesresult)
            {
                if (table.MonsterId == id)
                {
                    ItemDTO itemDTO = new ItemDTO()
                    {
                        ItemName = table.Item.ItemName,
                        ItemSpriteUrl = table.Item.ItemSpriteUrl,
                        DropRate = table.DropRate,
                        MinDrop = table.MinDrop,
                        MaxDrop = table.MaxDrop,
                    };
                    items.Add(itemDTO);
                }
                
            }

            MonsterDTO dto = new MonsterDTO()
            {
                Id = id,
                MonsterName = result.MonsterName,
                MonsterSpriteUrl = result.MonsterSpriteUrl,
                GoldDrop = statsresult?.GoldDrop ?? 0,
                BaseHealth = statsresult?.BaseHealth ?? 0,
                ExtraHealth = statsresult?.ExtraHealth ?? 0,
                Location = result.Location,
                Items = items.ToArray()
            };

            Payload<MonsterDTO> payload = new Payload<MonsterDTO>();
            payload.data = dto;
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> GetMonstersByStage(IRepository<Monster> monsterrepo, IRepository<MonsterStats> statsrepo, IRepository<MonsterItemTable> tablerepo, int stage)
        {
            var monsterresult = await monsterrepo.GetAll();
            var statsresult = await statsrepo.GetAll();
            var tablesresult = await tablerepo.GetAll();

            List<MonsterDTO> stagemonsters = new List<MonsterDTO>();

            foreach(var monster in monsterresult)
            {
                if(stage == monster.Location)
                {
                    var monsterstats = statsresult.FirstOrDefault(x => x.Id == monster.Id);

                    List<ItemDTO> monsteritems = new List<ItemDTO>();

                    foreach (var monstertable in tablesresult)
                    {
                        if (monster.Id == monstertable.MonsterId)
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

                        Id = monster.Id,
                        MonsterName = monster.MonsterName,
                        MonsterSpriteUrl = monster.MonsterSpriteUrl,
                        GoldDrop = monsterstats?.GoldDrop ?? 0,
                        BaseHealth = monsterstats?.BaseHealth ?? 0,
                        ExtraHealth = monsterstats?.ExtraHealth ?? 0,
                        Location = monster.Location,
                        Items = monsteritems.ToArray()
                    };
                    stagemonsters.Add(dto);
                }
            }

            Payload<IEnumerable<MonsterDTO>> payload = new Payload<IEnumerable<MonsterDTO>>();
            payload.data = stagemonsters;
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> GetMonstersBestiary(IRepository<Monster> monsterrepository, IRepository<MonsterStats> statsrepo, IRepository<MonsterItemTable> monstertablerepo, int limit, int offset)
        {
            var result = await monsterrepository.GetAll();
            var statsresult = await statsrepo.GetAll();
            var tablesresult = await monstertablerepo.GetAll();

            List<MonsterDTO> monsterDTOs = new List<MonsterDTO>();
            
            //pagination
            var paginatedResult = result.Skip(offset).Take(limit);

            foreach (var monster in paginatedResult)
            {
                var monsterstats = statsresult.FirstOrDefault(x => x.Id == monster.Id);

                List<ItemDTO> monsteritems = new List<ItemDTO>();

                foreach (var monstertable in tablesresult)
                {
                    if (monster.Id == monstertable.MonsterId)
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

                    Id = monster.Id,
                    MonsterName = monster.MonsterName,
                    MonsterSpriteUrl = monster.MonsterSpriteUrl,
                    GoldDrop = monsterstats?.GoldDrop ?? 0,
                    BaseHealth = monsterstats?.BaseHealth ?? 0,
                    ExtraHealth = monsterstats?.ExtraHealth ?? 0,
                    Location = monster.Location,
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
