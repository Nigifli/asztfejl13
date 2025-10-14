namespace Solution.Core.Interfaces;

public interface IEarbudService
{
    Task<ErrorOr<EarbudModel>> CreateAsync(EarbudModel model);
    Task<ErrorOr<Success>> UpdateAsync(EarbudModel model);
    Task<ErrorOr<Success>> DeleteAsync(string earbudId);
    Task<ErrorOr<EarbudModel>> GetByIdAsync(string earbudId);
    Task<ErrorOr<List<EarbudModel>>> GetAllAsync();
    Task<ErrorOr<PaginationModel<EarbudModel>>> GetPagedAsync(int page = 0);
}
