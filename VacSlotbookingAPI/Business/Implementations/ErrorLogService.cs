
namespace Business.Implementations
{
    using Business.Interfaces;
    using Domain;
    using Repository.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ErrorLogService : IErrorLogService
    {
        IRepository<ErrorLog, int> _errorLogRepository;
        public ErrorLogService(IRepository<ErrorLog, int> errorLogRepository)
        {
            _errorLogRepository = errorLogRepository;
        }
        public async Task<bool> AddErrorLogAsync(ErrorLog errorLog)
        {
            return await _errorLogRepository.AddAsync(errorLog);
        }

        public async Task<IEnumerable<ErrorLog>> GetAllErrorLogAsync()
        {
            return await _errorLogRepository.GetAllAsync();
        }

    }
}
