

namespace Business.Interfaces
{
    #region using
    using Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion

    public interface IErrorLogService
    {
        Task<bool> AddErrorLogAsync(ErrorLog errorLog);
        Task<IEnumerable<ErrorLog>> GetAllErrorLogAsync();
    }
}
