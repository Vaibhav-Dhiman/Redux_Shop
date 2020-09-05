using BooksRentData.Dto;
using BooksRentRepositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using BooksRentData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace BooksRentRepositories.Implementations
{
    public class AccountsRepository : IAccounts
    {
        public UserManager<AppUser> UserMgr;
        public SignInManager<AppUser> SignInMgr;
        private readonly IdentityAppContext _context;

        public AccountsRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
                UserMgr = userManager;
                SignInMgr = signInManager;
        }
        public async Task<bool> Register(RegisterUserDTO registerUserDTO)
        {
            //AppUser user = await UserMgr.FindByNameAsync(registerUserDTO.UserName);

            //if (user == null)
            //{
                var user = new AppUser();
                user.UserName = registerUserDTO.UserName;
                user.Email = registerUserDTO.Email;
                IdentityResult result = await UserMgr.CreateAsync(user, registerUserDTO.PasswordHash);
                return true;
            //}
            //return false;
        }
    }
}
