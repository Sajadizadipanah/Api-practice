using API_Practice.Contracts;
using API_Practice.PhoneBook;
using API_Practice.Profiles;


namespace API_Practice;

public static class ConfigureService
{
    public static IServiceCollection RegisterPresentationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductPhoneBook, ProductPhoneBook>();

        services.AddAutoMapper(typeof(ProductProfile));
        //services.AddFluentValidationAutoValidation();
        return services;
    }
}
