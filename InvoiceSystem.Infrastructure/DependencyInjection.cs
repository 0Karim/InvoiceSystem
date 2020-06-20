using InvoiceSystem.Application.Interfaces;
using InvoiceSystem.Infrastructure.Persistance;
using InvoiceSystem.Infrastructure.Repository;
using InvoiceSystem.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<InvoiceSystemDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(InvoiceSystemDbContext).Assembly.FullName)));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IInvoiceItemsService), typeof(InvoiceItemsService));
            services.AddScoped(typeof(IItemsService), typeof(ItemsServices));
            services.AddScoped(typeof(IStoreService), typeof(StoreService));
            services.AddScoped(typeof(IUnitService), typeof(UnitService));

            return services;
        }
    }
}
