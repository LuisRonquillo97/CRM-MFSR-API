using Entities.Models;
using Repositories.Implementations;

namespace Services.Interfaces
{
    public interface IRoleService<T> : IBaseService<T> where T : BaseAttributes
    {
        /// <summary>
        /// Role Repository to interact with DB.
        /// </summary>
        public RoleRepository Repository { get; set; }
    }
}
