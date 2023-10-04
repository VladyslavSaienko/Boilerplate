using Autofac;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.EntityFrameworkDataAccess;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
        optionsBuilder.EnableSensitiveDataLogging(true);
        optionsBuilder.UseInMemoryDatabase("UserDb");

        builder.RegisterType<Context>()
          .WithParameter(new TypedParameter(typeof(DbContextOptions), optionsBuilder.Options))
          .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
            .Where(type => type.Namespace.Contains("EntityFrameworkDataAccess"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}
