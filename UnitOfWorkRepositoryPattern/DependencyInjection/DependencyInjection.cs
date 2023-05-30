using UnitOfWorkRepositoryPattern.Core.Interfaces;
using UnitOfWorkRepositoryPattern.EFCore.Repositories;
using UnitOfWorkRepositoryPattern.EFCore;
using UnitOfWorkRepositoryPattern.Core.ProfilesMapping;

namespace UnitOfWorkRepositoryPattern.Api.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectServices(this IServiceCollection Services)
        {
            Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            Services.AddScoped<IProductRepository, ProductRepository>();
            Services.AddTransient<IUnitOfWork, UnitOfWork>();
            Services.AddAutoMapper(typeof(DepartmentMapping));
            Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            return Services;
        }
    }
}
