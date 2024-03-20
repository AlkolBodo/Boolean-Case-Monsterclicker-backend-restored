using Microsoft.AspNetCore.Mvc;
using MonsterClickerAPI.DTOs;
using MonsterClickerAPI.IRepo;
using MonsterClickerAPI.Models;
using MonsterClickerAPI.Payload;
using System.Collections.Generic;

namespace MonsterClickerAPI.Endpoints
{
    public static class UserEndpoint
    {
        public static void ConfigureUserEndpoint(this WebApplication webApp)
        {
            var users = webApp.MapGroup("users");
            users.MapGet("/all", GetUsers);
            users.MapGet("/{id}", GetUserById);
            users.MapPost("/", MakeUser);
            //Delete user eventually if there is time

            users.MapGet("/all/PlayerStats", GetPlayerStats);
            users.MapGet("/{id}/PlayerStats", GetPlayerStatsById);
            users.MapPut("/{id}/PlayerStats", EditPlayerStatsById);

            users.MapGet("/all/UserStats", GetUserStats);
            users.MapGet("/{id}/UserStats", GetUserStatsById);
            users.MapPut("/{id}/UserStats", EditUserStatsById);

            users.MapPost("/{id}/PlayerInventory", AddItemToPlayerInventory);
            users.MapGet("/{id}/PlayerInventory", GetPlayerInventory);
            users.MapPut("/{id}/PlayerInventory", UpdatePlayerInventoryItem);
            users.MapDelete("/{id}/PlayerInventory", DeletePlayerInventoryItem);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetUsers(IRepository<User> userRepository)
        {
            var userResult = await userRepository.GetAll();

            List<UserDTO> userDTOs = new List<UserDTO>();

            foreach (var user in userResult)
            {
                userDTOs.Add(new UserDTO()
                {
                    Email = user.Email,
                    Password = user.Password,
                    Username = user.Username
                });
            }


            Payload<IEnumerable<UserDTO>> payload = new Payload<IEnumerable<UserDTO>>();
            payload.data = userDTOs;
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> MakeUser(IRepository<User> userRepository, UserDTO newUser)
        {
            var result = await userRepository.Create(new User()
            {
                Email = newUser.Email,
                Password = newUser.Password,
                Username = newUser.Username,
            });

            if (result == null)
                return TypedResults.NotFound();


            Payload<UserDTO> payload = new Payload<UserDTO>();
            payload.data = new UserDTO()
            {
                Email = result.Email,
                Password = result.Password,
                Username = result.Username
            };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetUserById(IRepository<User> userRepository, int id)
        {
            var userResult = await userRepository.GetById(id);

            if (userResult != null)
            {
                UserDTO userDTO = new UserDTO()
                {
                    Email = userResult.Email,
                    Password = userResult.Password,
                    Username = userResult.Username
                };

                Payload<UserDTO> payload = new Payload<UserDTO>();
                payload.data = userDTO;
                return TypedResults.Ok(payload);
            }
            else
            {
                return TypedResults.NotFound();
            }
        }



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
        public static async Task<IResult> GetPlayerStatsById(IRepository<PlayerStats> playerStatsRepository, int id)
        {
            var results = await playerStatsRepository.GetById(id);

            Payload<PlayerStatsDTO> payload = new Payload<PlayerStatsDTO>();
            payload.data = new PlayerStatsDTO()
            {
                ClickDamage = results.ClickDamage,
                CritChance = results.CritChance,
            };
            return TypedResults.Ok(payload);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> EditPlayerStatsById(IRepository<PlayerStats> playerStatsRepository, PlayerStatsDTO newStats, int id)
        {
            var stat = await playerStatsRepository.GetById(id);

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
        public static async Task<IResult> GetUserStatsById(IRepository<UserStats> userStatsRepository, int id)
        {
            var results = await userStatsRepository.GetById(id);

            Payload<UserStatsDTO> payload = new Payload<UserStatsDTO>();
            payload.data = new UserStatsDTO()
            {
                Clicks = results.Clicks,
                MonstersKilled = results.MonstersKilled
            };
            return TypedResults.Ok(payload);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> EditUserStatsById(IRepository<UserStats> userStatsRepository, UserStatsDTO newStats, int id)
        {
            var stat = await userStatsRepository.GetById(id);

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

            int id, int itemId, int itemAmount)
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
                User = user
            };

            var result = await playerInventoryRepository.Create(newItem);


            Payload<PlayerInventoryDTO> payload = new Payload<PlayerInventoryDTO>();
            payload.data = new PlayerInventoryDTO()
            {
                Amount = result.Amount,
                ItemId = result.ItemId,
                ItemName = item.ItemName,
                ItemSpriteUrl = item.ItemSpriteUrl
            };
            return TypedResults.Ok(payload);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdatePlayerInventoryItem(
            IRepository<PlayerInventory> playerInventoryRepository,
            IRepository<Item> itemRepository,

            int id, int itemId, int newAmount)
        {
            var getItem = await itemRepository.GetById(itemId);

            var allInventories = await playerInventoryRepository.GetAll();
            var playerInventory = allInventories.Where(x => x.UserId == id);
            var item = playerInventory.First(x => x.ItemId == itemId);

            if (item == null) return TypedResults.NotFound("Item not in inventory, use POST to add it");

            item.Amount = newAmount;

            var result = await playerInventoryRepository.Update(item);


            Payload<PlayerInventoryDTO> payload = new Payload<PlayerInventoryDTO>();
            payload.data = new PlayerInventoryDTO()
            {
                Amount = result.Amount,
                ItemId = result.ItemId,
                ItemName = getItem.ItemName,
                ItemSpriteUrl = getItem.ItemSpriteUrl
            };
            return TypedResults.Ok(payload);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeletePlayerInventoryItem(
            IRepository<PlayerInventory> playerInventoryRepository,
            IRepository<Item> itemRepository,

            int id, int itemId)
        {
            var getItem = await itemRepository.GetById(itemId);

            var allInventories = await playerInventoryRepository.GetAll();
            var playerInventory = allInventories.Where(x => x.UserId == id);
            var item = playerInventory.First(x => x.ItemId == itemId);

            if (item == null) return TypedResults.NotFound("Item not in inventory, cannot delete!");

            var result = await playerInventoryRepository.Delete(item);


            Payload<PlayerInventoryDTO> payload = new Payload<PlayerInventoryDTO>();
            payload.data = new PlayerInventoryDTO()
            {
                Amount = result.Amount,
                ItemId = result.ItemId,
                ItemName = getItem.ItemName,
                ItemSpriteUrl = getItem.ItemSpriteUrl
            };
            return TypedResults.Ok(payload);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPlayerInventory(
            IRepository<PlayerInventory> playerInventoryRepository,
            IRepository<Item> itemRepository,
            int id)
        {
            var inventories = await playerInventoryRepository.GetAll();
            var playerInventory = inventories.Where(x => x.UserId == id);
            var items = await itemRepository.GetAll();

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
                    fullInventory.Add(temp);
                }
            }


            Payload<IEnumerable<PlayerInventoryDTO>> payload = new Payload<IEnumerable<PlayerInventoryDTO>>();
            payload.data = fullInventory;
            return TypedResults.Ok(payload);

        }
    }
}
