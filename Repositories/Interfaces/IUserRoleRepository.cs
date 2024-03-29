﻿using Entities.Models.Users;

namespace Repositories.Interfaces
{
    /// <summary>
    /// Interface for role repository.
    /// </summary>
    /// <remarks>Inherits from the base repository</remarks>
    /// <typeparam name="T">DB Entity</typeparam>
    internal interface IUserRoleRepository : IBaseRepository<UserRole>
    {

    }
}
