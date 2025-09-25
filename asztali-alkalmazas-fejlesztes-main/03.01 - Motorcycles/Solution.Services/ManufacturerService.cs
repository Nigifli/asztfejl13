namespace Solution.Services;

public class ManufacturerService(AppDbContext dbContext) : IManufacturerService
{
    private const int ROW_COUNT = 10;

    public async Task<ErrorOr<ManufacturerModel>> CreateAsync(ManufacturerModel manufacturer)
    {
        bool exists = await dbContext.Manufacturers.AnyAsync(x => x.Name == manufacturer.Name);


        if (exists)
        {
            return Error.Conflict(description: "Manufacturer already exists!");
        }

        var singleManufacturer = manufacturer.ToEntity();
        singleManufacturer.Name = Guid.NewGuid().ToString();

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
                                                .Where(x => x.Id == manufacturer.Id)
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

    public async Task<ErrorOr<PaginationModel<ManufacturerModel>>> GetPagedAsync(int page = 0)
    {
        page = page <= 0 ? 1 : page - 1;

        var manufacturers = await dbContext.Manufacturers.AsNoTracking()
                                                     .Include(x => x.Name)
                                                     .Skip(page * ROW_COUNT)
                                                     .Take(ROW_COUNT)
                                                     .Select(x => new ManufacturerModel(x))
                                                     .ToListAsync();

        var paginationModel = new PaginationModel<ManufacturerModel>
        {
            Items = manufacturers,
            Count = await dbContext.Manufacturers.CountAsync()
        };

        return paginationModel;
    }
}
