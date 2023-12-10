using Business.Abstract;
using Business.Concrete;
using Data.Contexts;
using Data.Repositories.Abstract;
using Data.Repositories.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IAuthService, CookieAuthService>();
        services.AddScoped<ICategoryService, CategoryService>();


        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Login/";
                options.LogoutPath = "/Logout/";
                options.AccessDeniedPath = "/Forbidden/";
                options.SlidingExpiration = true;
                
            });


        return services;
    }
}
