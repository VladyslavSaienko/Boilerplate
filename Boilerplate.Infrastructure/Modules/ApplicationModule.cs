using Autofac;

namespace Boilerplate.Infrastructure.Modules;

public class ApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(ApplicationException).Assembly)
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}
