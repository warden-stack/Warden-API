﻿using Autofac;
using Warden.Api.Infrastructure.Services;

namespace Warden.Api.Infrastructure.IoC.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrganizationService>()
                .As<IOrganizationService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<WardenService>()
                .As<IWardenService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<SecuredRequestService>()
                .As<ISecuredRequestService>()
                .InstancePerLifetimeScope();

            //TODO: Register Rebus IBus
            builder.RegisterType<WardenConfigurationService>()
                .As<IWardenConfigurationService>()
                .InstancePerLifetimeScope();
        }
    }
}