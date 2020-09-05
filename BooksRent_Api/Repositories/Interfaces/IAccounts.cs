using BooksRentData.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BooksRentRepositories.Interfaces
{
    public interface IAccounts
    {
       Task<bool> Register(RegisterUserDTO registerUserDTO);
    }
}
