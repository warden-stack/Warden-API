﻿using Autofac;
using Microsoft.Extensions.Configuration;
using RawRabbit.vNext;
using RawRabbit.vNext.Disposable;
using Warden.Services.Commands;
using Warden.Services.Nancy;
using Warden.Services.Spawn.Handlers.Commands;

namespace Warden.Services.Spawn.Framework
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        private readonly IConfiguration _configuration;
        public static ILifetimeScope LifetimeScope { get; private set; }

        public Bootstrapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void ConfigureApplicationContainer(ILifetimeScope container)
        {
            base.ConfigureApplicationContainer(container);
            container.Update(builder =>
            {
                builder.RegisterInstance(BusClientFactory.CreateDefault()).As<IBusClient>();
                builder.RegisterType<SpawnWardenHandler>().As<ICommandHandler<SpawnWarden>>();
            });
            LifetimeScope = container;
        }
    }
}