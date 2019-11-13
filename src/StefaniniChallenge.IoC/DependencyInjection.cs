using Microsoft.Extensions.DependencyInjection;
using StefaniniChallenge.Application.Interfaces;
using StefaniniChallenge.Application.Services;
using StefaniniChallenge.Data.Repository;
using StefaniniChallenge.Domain.Interfaces.Repositories;
using StefaniniChallenge.Domain.Interfaces.Services;
using StefaniniChallenge.Domain.Services;

namespace StefaniniChallenge.IoC
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection svcCollection)
        {
            //Application
            svcCollection.AddScoped(typeof(IAppBase<,>), typeof(AppBaseService<,>));
            svcCollection.AddScoped<IAppCustomer, AppCustomer>();
            svcCollection.AddScoped<IAppCity, AppCity>();
            svcCollection.AddScoped<IAppClassification, AppClassification>();
            svcCollection.AddScoped<IAppGender, AppGender>();
            svcCollection.AddScoped<IAppRegion, AppRegion>();

            //Domain
            svcCollection.AddScoped(typeof(IServiceBase<>), typeof(BaseService<>));
            svcCollection.AddScoped<ICustomerService, CustomerService>();
            svcCollection.AddScoped<ICityService, CityService>();
            svcCollection.AddScoped<IClassificationService, ClassificationService>();
            svcCollection.AddScoped<IGenderService, GenderService>();
            svcCollection.AddScoped<IRegionService, RegionService>();

            //Repository
            svcCollection.AddScoped(typeof(IRepositoryBase<>), typeof(BaseRepository<>));
            svcCollection.AddScoped<ICustomerRepository, CustomerRepository>();
            svcCollection.AddScoped<ICityRepository, CityRepository>();
            svcCollection.AddScoped<IClassificationRepository, ClassificationRepository>();
            svcCollection.AddScoped<IGenderRepository, GenderRepository>();
            svcCollection.AddScoped<IRegionRepository, RegionRepository>();
        }
    }
}
