using Mango.Services.AuthAPI.Data;
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Models.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        #region CTOR
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(AppDbContext db, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        #endregion

        #region Auth Login
        public Task<LoginResponceDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Auth Register
        public async Task<string> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = registrationRequestDTO.Email,
                Email = registrationRequestDTO.Email,
                NormalizedEmail = registrationRequestDTO.Email.ToUpper()                ,
                Name = registrationRequestDTO.Name,
                PhoneNumber = registrationRequestDTO.PhoneNumber
            };
            try
            {
                //inserting the user 
                var result = await _userManager.CreateAsync(user, registrationRequestDTO.Password);
                if (result.Succeeded)
                {
                    //return user 
                    var userToReturn = _db.Users.First(u => u.UserName == registrationRequestDTO.Email);
                    //Convert to user DTOs
                    UserDTO userDTO = new UserDTO()
                    {
                        Email = userToReturn.Email,
                        Name = userToReturn.Name,
                        Id = userToReturn.Id,
                        PhoneNumber = userToReturn.PhoneNumber
                    };
                    return "";
                    //return $"{userDTO.Name} Register SuccessFully";


                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception e)
            {


            }
            return $"Error : Something went wronge";
        } 
        #endregion
    }
}
