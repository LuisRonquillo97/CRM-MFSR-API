using Entities.Models.Developments;
using Repositories.Implementations;

namespace Services.Interfaces
{
    /// <summary>
    /// Lot service category.
    /// </summary>
    public interface ILotSerivce : IBaseService<Lot, LotRepository>
    {
    }
}
