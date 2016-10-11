﻿using System;
using System.Threading.Tasks;
using RawRabbit;
using Warden.Common.Commands;
using Warden.Common.Commands.ApiKeys;
using Warden.Common.Commands.Organizations;
using Warden.Common.Commands.WardenChecks;
using Warden.Common.Commands.Wardens;
using Warden.Common.Events.Operations;
using Warden.Services.Operations.Domain;
using Warden.Services.Operations.Services;

namespace Warden.Services.Operations.Handlers
{
    public class GenericCommandHandler : ICommandHandler<RequestNewApiKey>, ICommandHandler<CreateApiKey>,
        ICommandHandler<RequestNewOrganization>, ICommandHandler<CreateOrganization>,
        ICommandHandler<RequestNewWarden>, ICommandHandler<CreateWarden>,
        ICommandHandler<RequestWardenCheckResultProcessing>, ICommandHandler<ProcessWardenCheckResult>
    {
        private readonly IBusClient _bus;
        private readonly IOperationService _operationService;

        public GenericCommandHandler(IBusClient bus, IOperationService operationService)
        {
            _bus = bus;
            _operationService = operationService;
        }

        public async Task HandleAsync(RequestNewApiKey command)
            => await CreateAsync(command);

        public async Task HandleAsync(CreateApiKey command)
            => await ProcessAsync(command);

        public async Task HandleAsync(RequestNewOrganization command)
            => await CreateAsync(command);

        public async Task HandleAsync(CreateOrganization command)
            => await ProcessAsync(command);

        public async Task HandleAsync(RequestNewWarden command)
            => await CreateAsync(command);

        public async Task HandleAsync(CreateWarden command)
            => await ProcessAsync(command);

        public async Task HandleAsync(RequestWardenCheckResultProcessing command)
            => await CreateAsync(command);

        public async Task HandleAsync(ProcessWardenCheckResult command)
            => await ProcessAsync(command);

        private async Task CreateAsync(IAuthenticatedCommand command)
        {
            await _operationService.CreateAsync(command.Details.Id, command.UserId,
                command.Details.Origin, command.Details.Resource, command.Details.CreatedAt);
            await _bus.PublishAsync(new OperationCreated(Guid.NewGuid(), command.Details.Id,
                command.UserId, command.Details.Origin, command.Details.Resource, States.Accepted,
                command.Details.CreatedAt, DateTime.UtcNow));
        }

        private async Task ProcessAsync(IAuthenticatedCommand command)
        {
            await _operationService.ProcessAsync(command.Details.Id);
            await _bus.PublishAsync(new OperationUpdated(Guid.NewGuid(), command.Details.Id,
                command.UserId, States.Processing, DateTime.UtcNow, null));
        } 
    }
}