namespace Repositories.Interfaces
{
    /// <summary>
    /// Interface for role repository.
    /// </summary>
    /// <remarks>Inherits from the base repository</remarks>
    /// <typeparam name="T">DB Entity</typeparam>
    public interface IUserRepository<T> : IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Validates if the user can login with his email and password.
        /// </summary>
        /// <param name="email">email.</param>
        /// <param name="password">password.</param>
        /// <returns>User data.</returns>
        T ValidateLogin(string email, string password);

        /// <summary>
        /// Determinate if the provided user has an especific role.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="roleId">Role ID.</param>
        /// <returns>Determinating boolean</returns>
        bool HasRole(Guid userId, Guid roleId);
    }
}
