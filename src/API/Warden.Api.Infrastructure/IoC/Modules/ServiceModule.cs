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
            builder.RegisterType<WardenCheckService>()
                .As<IWardenCheckService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PaymentPlanService>()
                .As<IPaymentPlanService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<UserPaymentPlanService>()
                .As<IUserPaymentPlanService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<UserFeaturesManager>()
                .As<IUserFeaturesManager>()
                .InstancePerLifetimeScope();
            builder.RegisterType<Encrypter>()
                .As<IEncrypter>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ApiKeyService>()
                .As<IApiKeyService>()
                .InstancePerLifetimeScope();

            //TODO: Register RabbitMQ
            builder.RegisterType<WardenConfigurationService>()
                .As<IWardenConfigurationService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UniqueIdGenerator>()
                .As<IUniqueIdGenerator>()
                .SingleInstance();

        }
    }
}