namespace Solution.Core.Interfaces;

public interface ITypeService
{
    Task<ErrorOr<TypeModel>> CreateAsync(TypeModel type);
    Task<ErrorOr<Success>> UpdateAsync(TypeModel type);
    Task<ErrorOr<Success>> DeleteAsync(string typeId);
    Task<ErrorOr<TypeModel>> GetByIdAsync(string typeId);
    Task<ErrorOr<List<TypeModel>>> GetAllAsync();
}
