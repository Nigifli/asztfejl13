namespace Solution.Services;

public class TypeService(AppDbContext dbContext) : ITypeService
{
    public async Task<ErrorOr<TypeModel>> CreateAsync(TypeModel type)
    {
        bool exists = await dbContext.Types.AnyAsync(x => x.Name == type.Name);


        if (exists)
        {
            return Error.Conflict(description: "Type already exists!");
        }

        var singleType = type.ToEntity();
        singleType.Name = Guid.NewGuid().ToString();

        await dbContext.Manufacturers.AddAsync(singleManufacturer);
        await dbContext.SaveChangesAsync();

        return new ManufacturerModel(singleManufacturer)
        {
            Name = manufacturer.Name
        };
    }

    public async Task<ErrorOr<Success>> UpdateAsync(ManufacturerModel manufacturer)
    {
        var result = await dbContext.Manufacturers.AsNoTracking()
                                                .Where(x => x.Name == manufacturer.Name)
                                                .ExecuteUpdateAsync(x => x.SetProperty(p => p.Name, manufacturer.Name));
        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<Success>> DeleteAsync(int manufacturerId)
    {
        var result = await dbContext.Manufacturers.AsNoTracking()
                                                .Where(x => x.Id == manufacturerId)
                                                .ExecuteDeleteAsync();

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<ManufacturerModel>> GetByIdAsync(int manufacturerId)
    {
        var manufacturer = await dbContext.Manufacturers.FirstOrDefaultAsync(x => x.Id == manufacturerId);

        if (manufacturer is null)
        {
            return Error.NotFound(description: "Manufacturer not found.");
        }

        return new ManufacturerModel(manufacturer);
    }

    public async Task<ErrorOr<List<ManufacturerModel>>> GetAllAsync() =>
        await dbContext.Manufacturers.AsNoTracking()
                                   .Select(x => new ManufacturerModel(x))
                                   .ToListAsync();
}
