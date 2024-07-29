using Application.AutoMapper;
using Application.UseCases.Login.DoLogin;
using Application.UseCases.Users.GetAll;
using Application.UseCases.Users.Profiles;
using Application.UseCases.Users.Register;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
        AddAutoMapper(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<IGetUserProfileUseCase, GetUserProfileUseCase>();
        services.AddScoped<IGetAllUserUseCase, GetAllUserUseCase>();
        
        services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
    }
}