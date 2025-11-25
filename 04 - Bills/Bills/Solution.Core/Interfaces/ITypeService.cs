namespace Solution.Core.Interfaces;

public interface ITypeService
{
    Task<ErrorOr<ItemModel>> CreateAsync(ItemModel model);
    Task<ErrorOr<Success>> UpdateAsync(ItemModel model);
    Task<ErrorOr<Success>> DeleteAsync(int typeId);
    Task<ErrorOr<ItemModel>> GetByIdAsync(int typeId);
    Task<ErrorOr<List<ItemModel>>> GetAllAsync();
    Task<ErrorOr<PaginationModel<ItemModel>>> GetPagedAsync(int page = 0);
}


