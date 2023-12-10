using Business.DTOs;
using Core.Business.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IAuthService
{
    Task<IResult> LoginAsync(UserLoginDto dto);
    Task<IResult> LogoutAsync();
    Task<IResult> RegisterAsync(UserRegisterDto dto);
}
