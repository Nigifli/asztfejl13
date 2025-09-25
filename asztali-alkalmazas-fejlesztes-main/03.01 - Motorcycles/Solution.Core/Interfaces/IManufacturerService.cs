
namespace Solution.Core.Interfaces;

public interface IManufacturerService
{
    Task<ErrorOr<ManufacturerModel>> CreateAsync(ManufacturerModel manufacturer);
    Task<ErrorOr<Success>> UpdateAsync(ManufacturerModel manufacturer);
    Task<ErrorOr<Success>> DeleteAsync(int manufacturerId);
    Task<ErrorOr<ManufacturerModel>> GetByIdAsync(int manufacturerId);
    Task<ErrorOr<List<ManufacturerModel>>> GetAllAsync();
    Task<ErrorOr<PaginationModel<ManufacturerModel>>> GetPagedAsync(int page = 0);
}
