using Microsoft.AspNetCore.Mvc;
using MonsterClickerAPI.DTOs;
using MonsterClickerAPI.IRepo;
using MonsterClickerAPI.Models;
using MonsterClickerAPI.Payload;

namespace MonsterClickerAPI.Endpoints
{
    public static class UserEndpoint
    {
        public static void ConfigureUserEndpoint(this WebApplication webApp)
        {
            var users = webApp.MapGroup("users");
            users.MapGet("/", GetUsers);
            users.MapGet("/{id}", GetUserById);
            users.MapPost("/", MakeUser);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetUsers(IRepository<User> userRepository)
        {
            var userResult = await userRepository.GetAll();

            List<UserDTO> userDTOs = new List<UserDTO>();

            foreach (var user in userResult)
            {
                userDTOs.Add(new UserDTO()
                    { Email = user.Email, 
                        Password = user.Password, 
                        Username = user.Username });
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
    }
}
