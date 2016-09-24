﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warden.Api.Core.Domain.Users;
using Warden.Api.Core.Types;

namespace Warden.Api.Core.Repositories
{
    public interface IApiKeyRepository
    {
        Task<IEnumerable<ApiKey>> BrowseByUserId(Guid userId);
        Task<Maybe<ApiKey>> GetAsync(Guid id);
        Task<Maybe<ApiKey>> GetByKeyAsync(string key);
        Task AddAsync(ApiKey apiKey);
        Task DeleteAsync(ApiKey key);
    }
}