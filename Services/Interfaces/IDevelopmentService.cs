using Entities.Models.Developments;
using Entities.Models.Users;
using Repositories.Implementations;

namespace Services.Interfaces
{
    /// <summary>
    /// Development service interface
    /// </summary>
    public interface IDevelopmentService : IBaseService<Development, DevelopmentRepository>
    {
    }
}
