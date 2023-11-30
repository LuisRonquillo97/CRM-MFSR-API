using Entities.Models.Developments;
using Repositories.Implementations;
using SQLDB.Context;

namespace Services.Implementations
{
    /// <summary>
    /// Development service.
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="context">DB context.</param>
    public class DevelopmentService : BaseService<Development>
    {
        public new required DevelopmentRepository Repository;
        public DevelopmentService(SqlContext context) : base(new DevelopmentRepository(context))
        {

        }
    }
}
