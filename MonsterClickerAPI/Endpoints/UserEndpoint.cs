using Microsoft.AspNetCore.Mvc;
using MonsterClickerAPI.DTOs;
using MonsterClickerAPI.IRepo;
using MonsterClickerAPI.Models;
using MonsterClickerAPI.Payload;
using System.Collections.Generic;
using MonsterClickerAPI.Enumfolder;

namespace MonsterClickerAPI.Endpoints
{
    public static class UserEndpoint
    {
        public static void ConfigureUserEndpoint(this WebApplication webApp)
        {
            var users = webApp.MapGroup("users");
            //users.MapGet("/all", GetUsers);
            //users.MapGet("/{id}", GetUserById);
            //users.MapPost("/", MakeUser);
            //TODO Delete user eventually if there is time

            users.MapGet("/all/PlayerStats", GetPlayerStats);
            users.MapGet("/{id}/PlayerStats", GetPlayerStatsByUserId);
            users.MapPut("/{id}/PlayerStats", EditPlayerStatsByUserId);

            users.MapGet("/all/UserStats", GetUserStats);
            users.MapGet("/{id}/UserStats", GetUserStatsByUserId);
            users.MapPut("/{id}/UserStats", EditUserStatsByUserId);

            users.MapPost("/{id}/PlayerInventory", AddItemToPlayerInventory);
            users.MapGet("/{id}/PlayerInventory", GetPlayerInventory);
            users.MapPut("/{id}/PlayerInventory", UpdatePlayerInventoryItem);
            users.MapDelete("/{id}/PlayerInventory", DeletePlayerInventoryItem);

        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public static async Task<IResult> GetUsers(IRepository<User> userRepository)
        //{
        //    var userResult = await userRepository.GetAll();

        //    List<UserDTO> userDTOs = new List<UserDTO>();

        //    foreach (var user in userResult)
        //    {
        //        userDTOs.Add(new UserDTO()
        //        {
        //            Id = user.Id,
        //            Email = user.Email,
        //            Password = user.Password,
        //            Username = user.Username
        //        });
        //    }


        //    Payload<IEnumerable<UserDTO>> payload = new Payload<IEnumerable<UserDTO>>();
        //    payload.data = userDTOs;
        //    return TypedResults.Ok(payload);
        //}

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public static async Task<IResult> MakeUser(
        //    IRepository<User> userRepository,
        //    IRepository<AppUser> userStatsRepository,
        //    IRepository<PlayerStats> playerStatsRepository,
        //    UserPOSTDTO newUser)
        //{
        //    var result = await userRepository.Create(new AppUser()
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Email = newUser.Email,

        //    });

        //    if (result == null)
        //        return TypedResults.BadRequest();

        //    await userStatsRepository.Create(new UserStats()
        //        { Clicks = 0, MonstersKilled = 0, UserId = result.Id, User = result });

        //    await playerStatsRepository.Create(new PlayerStats()
        //        { ClickDamage = 0, CritChance = 0, UserId = result.Id, User = result });

        //    Payload<UserDTO> payload = new Payload<UserDTO>();
        //    payload.data = new UserDTO()
        //    {
        //        Id = result.Id,   
        //        Email = result.Email,
        //        Password = result.Password,
        //        Username = result.Username
        //    };
        //    return TypedResults.Ok(payload);
        //}

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public static async Task<IResult> GetUserById(IRepository<User> userRepository, string id)
        //{
        //    var userResult = await userRepository.GetById(id);

        //    if (userResult != null)
        //    {
        //        UserDTO userDTO = new UserDTO()
        //        {
        //            Id = userResult.Id,
        //            Email = userResult.Email,
        //            Password = userResult.Password,
        //            Username = userResult.Username
        //        };

        //        Payload<UserDTO> payload = new Payload<UserDTO>();
        //        payload.data = userDTO;
        //        return TypedResults.Ok(payload);
        //    }
        //    else
        //    {
        //        return TypedResults.NotFound();
        //    }
        //}



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPlayerStats(IRepository<PlayerStats> playerStatsRepository)
        {
            var results = await playerStatsRepository.GetAll();

            List<PlayerStatsDTO> playerStatsDTOs = new List<PlayerStatsDTO>();
            foreach (var playerStat in results)
            {
             playerStatsDTOs.Add(new PlayerStatsDTO(){
                 ClickDamage = playerStat.ClickDamage, 
                 CritChance = playerStat.CritChance, 
             });   
            }

            Payload<IEnumerable<PlayerStatsDTO>> payload = new Payload<IEnumerable<PlayerStatsDTO>>();
            payload.data = playerStatsDTOs;
            return TypedResults.Ok(payload);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPlayerStatsByUserId(IRepository<PlayerStats> playerStatsRepository, string id)
        {
            var allStats = await playerStatsRepository.GetAll();
            var results = allStats.FirstOrDefault(x => x.UserId == id);

            if (results == default) return TypedResults.NotFound("Invalid user Id");

            Payload<PlayerStatsDTO> payload = new Payload<PlayerStatsDTO>();
            payload.data = new PlayerStatsDTO()
            {
                ClickDamage = results.ClickDamage,
                CritChance = results.CritChance,
            };
            return TypedResults.Ok(payload);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> EditPlayerStatsByUserId(IRepository<PlayerStats> playerStatsRepository, PlayerStatsDTO newStats, string id)
        {
            var allStats = await playerStatsRepository.GetAll();
            var stat = allStats.FirstOrDefault(x => x.UserId == id);

            if (stat == default) return TypedResults.NotFound("Invalid user id");

            stat.ClickDamage = newStats.ClickDamage;
            stat.CritChance = newStats.CritChance;

            var result = await playerStatsRepository.Update(stat);


            Payload<PlayerStatsDTO> payload = new Payload<PlayerStatsDTO>();
            payload.data = new PlayerStatsDTO()
            {
                ClickDamage = result.ClickDamage,
                CritChance = result.CritChance,
            };
            return TypedResults.Ok(payload);

        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetUserStats(IRepository<UserStats> userStatsRepository)
        {
            var results = await userStatsRepository.GetAll();

            List<UserStatsDTO> userStatsDTOs = new List<UserStatsDTO>();
            foreach (var userStat in results)
            {
                userStatsDTOs.Add(new UserStatsDTO()
                { Clicks = userStat.Clicks,
                    MonstersKilled = userStat.MonstersKilled,
                });
            }

            Payload<IEnumerable<UserStatsDTO>> payload = new Payload<IEnumerable<UserStatsDTO>>();
            payload.data = userStatsDTOs;
            return TypedResults.Ok(payload);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetUserStatsByUserId(IRepository<UserStats> userStatsRepository, string id)
        {
            var allStats = await userStatsRepository.GetAll();
            var results = allStats.FirstOrDefault(x => x.UserId == id);

            if (results == default) return TypedResults.NotFound("Invalid user id");

            Payload<UserStatsDTO> payload = new Payload<UserStatsDTO>();
            payload.data = new UserStatsDTO()
            {
                Clicks = results.Clicks,
                MonstersKilled = results.MonstersKilled
            };
            return TypedResults.Ok(payload);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> EditUserStatsByUserId(IRepository<UserStats> userStatsRepository, UserStatsDTO newStats, string id)
        {
            var allStats = await userStatsRepository.GetAll();
            var stat = allStats.FirstOrDefault(x => x.UserId == id);

            if (stat == null) return TypedResults.NotFound("Invalid user Id");

            stat.MonstersKilled = newStats.MonstersKilled;
            stat.Clicks = newStats.Clicks;

            var result = await userStatsRepository.Update(stat);

            Payload<UserStatsDTO> payload = new Payload<UserStatsDTO>();
            payload.data = new UserStatsDTO()
            {
                Clicks = result.Clicks,
                MonstersKilled = result.MonstersKilled
            };
            return TypedResults.Ok(payload);

        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddItemToPlayerInventory(
            IRepository<PlayerInventory> playerInventoryRepository,
            IRepository<Item> itemRepository,
            IRepository<User> userRepository,

            string id, int itemId, int itemAmount)
        {
            var item = await itemRepository.GetById(itemId);
            var user = await userRepository.GetById(id);

            if (item == null)
                return TypedResults.BadRequest("Invalid item Id");
            if (user == null)
                return TypedResults.BadRequest("Invalid user Id");

            PlayerInventory newItem = new PlayerInventory()
            {
                Amount = itemAmount,
                Item = item,
                ItemId = item.Id,
                UserId = id,
            };

            var result = await playerInventoryRepository.Create(newItem);


            Payload<PlayerInventoryDTO> payload = new Payload<PlayerInventoryDTO>();
            payload.data = new PlayerInventoryDTO()
            {
                Amount = result.Amount,
                ItemId = result.ItemId,
                ItemName = item.ItemName,
                ItemSpriteUrl = item.ItemSpriteUrl,
                Value = item.Value
            };
            return TypedResults.Ok(payload);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdatePlayerInventoryItem(
            IRepository<PlayerInventory> playerInventoryRepository,
            IRepository<Item> itemRepository,

            string id, int itemId, int newAmount)
        {
            var getItem = await itemRepository.GetById(itemId);

            var allInventories = await playerInventoryRepository.GetAll();
            var playerInventory = allInventories.Where(x => x.UserId == id);
            var item = playerInventory.First(x => x.ItemId == itemId);

            if (item == null || !playerInventory.Any() || allInventories == null) return TypedResults.NotFound("Item not in inventory, use POST to add it");

            item.Amount = newAmount;

            var result = await playerInventoryRepository.Update(item);


            Payload<PlayerInventoryDTO> payload = new Payload<PlayerInventoryDTO>();
            payload.data = new PlayerInventoryDTO()
            {
                Amount = result.Amount,
                ItemId = result.ItemId,
                ItemName = getItem.ItemName,
                ItemSpriteUrl = getItem.ItemSpriteUrl,
                Value = getItem.Value
            };
            return TypedResults.Ok(payload);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeletePlayerInventoryItem(
            IRepository<PlayerInventory> playerInventoryRepository,
            IRepository<Item> itemRepository,

            string id, int itemId)
        {
            var getItem = await itemRepository.GetById(itemId);

            var allInventories = await playerInventoryRepository.GetAll();
            var playerInventory = allInventories.Where(x => x.UserId == id);
            var item = playerInventory.FirstOrDefault(x => x.ItemId == itemId);

            if (!playerInventory.Any())
                return TypedResults.NotFound("Could not find player inventory, invalid user id");
            if (item == default) return TypedResults.NotFound("Item not in inventory, cannot delete!");


            var result = await playerInventoryRepository.Delete(item);


            Payload<PlayerInventoryDTO> payload = new Payload<PlayerInventoryDTO>();
            payload.data = new PlayerInventoryDTO()
            {
                Amount = result.Amount,
                ItemId = result.ItemId,
                ItemName = getItem.ItemName,
                ItemSpriteUrl = getItem.ItemSpriteUrl,
                Value = getItem.Value
            };
            return TypedResults.Ok(payload);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPlayerInventory(
            IRepository<PlayerInventory> playerInventoryRepository,
            IRepository<Item> itemRepository,
            string id)
        {
            var inventories = await playerInventoryRepository.GetAll();
            var playerInventory = inventories.Where(x => x.UserId == id);
            var items = await itemRepository.GetAll();

            if (inventories == null || !playerInventory.Any() || items == null) return TypedResults.NotFound();

            List<PlayerInventoryDTO> fullInventory = new List<PlayerInventoryDTO>();

            foreach (var inventory in playerInventory)
            {
                PlayerInventoryDTO temp = new PlayerInventoryDTO();

                var validItem = items.First(x => x.Id == inventory.ItemId);
                if (validItem != null)
                { 
                    temp.ItemName = validItem.ItemName;
                    temp.ItemSpriteUrl = validItem.ItemSpriteUrl;
                    temp.ItemId = validItem.Id;
                    temp.Amount = inventory.Amount;
                    temp.Value = validItem.Value;
                    fullInventory.Add(temp);
                }
            }


            Payload<IEnumerable<PlayerInventoryDTO>> payload = new Payload<IEnumerable<PlayerInventoryDTO>>();
            payload.data = fullInventory;
            return TypedResults.Ok(payload);

        }
    }
}
