using Business.Abstract;
using Business.DTOs;
using Core.Auth;
using Core.Business.Results;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class CookieAuthService : IAuthService
{
    private readonly IUserRepository _repository;
    private readonly IHttpContextAccessor _contextAccessor;

    public CookieAuthService(IUserRepository repository, IHttpContextAccessor contextAccessor)
    {
        _repository = repository;
        _contextAccessor = contextAccessor;
    }

    public async Task<IResult> LoginAsync(UserLoginDto dto)
    {
        var user = await _repository.GetAsync(u => u.Email == dto.Email);

        if(user is null)
            return new ErrorResult("Bu mail adresiyle kayıtlı bir kullanıcı bulunamadı.");

        else if (!HashingHelper.VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt))
            return new ErrorResult("Hatalı şifre.");

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Sid, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Username),
            new Claim(ClaimTypes.Role, user.Role),
        };

        var claimsIdentiy = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            ExpiresUtc = DateTime.Now.AddMinutes(10),
            IsPersistent = dto.RememberMe,
            IssuedUtc = DateTime.Now,
        };

        var principal = new ClaimsPrincipal(claimsIdentiy);

        await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

        return new SuccessResult("Giriş başarılı");

    }

    public async Task<IResult> LogoutAsync()
    {
        await _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return new SuccessResult("Çıkış başarılı");
    }

    public async Task<IResult> RegisterAsync(UserRegisterDto dto)
    {
        var exists = await _repository.AnyAsync(u => u.Email == dto.Email || u.Username == dto.Username);

        if (exists)
            return new ErrorResult("Bu mail adresi veya kullanıcı adi ile daha önce kayıt olunmuş");


        byte[] passwordHash, passwordSalt;

        HashingHelper.CreatePasswordHash(dto.Password, out passwordHash, out passwordSalt);


        User user = new User()
        {
            Username = dto.Username,
            Email = dto.Email,
            Role = "Reader",
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        await _repository.AddAsync(user);
        return new SuccessResult("Kayıt başarılı");
    }
}
