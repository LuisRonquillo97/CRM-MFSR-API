using Entities.Models.Developments;
using Repositories.Implementations;

namespace Services.Interfaces
{
    /// <summary>
    /// Lot category service interface.
    /// </summary>
    public interface ILotCategoryService : IBaseService<LotCategory, LotCategoryRepository>
    {
    }
}
