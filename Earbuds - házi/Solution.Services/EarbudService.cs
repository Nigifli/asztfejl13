namespace Solution.Services;

public class EarbudService(AppDbContext dbContext) : IEarbudService
{
    private const int ROW_COUNT = 10;

    public async Task<ErrorOr<EarbudModel>> CreateAsync(EarbudModel model)
    {
        bool exists = await dbContext.Earbuds.AnyAsync(x => x.ManufacturerId == model.Manufacturer.Id &&
                                                                x.Model.ToLower() == model.Model.ToLower().Trim() &&
                                                                x.ReleaseYear == model.ReleaseYear);

        if (exists)
        {
            return Error.Conflict(description: "Earbud already exists!");
        }

        var earbud = model.ToEntity();
        earbud.PublicId = Guid.NewGuid().ToString();
        
        await dbContext.Earbuds.AddAsync(earbud);
        await dbContext.SaveChangesAsync();

        model.Id = earbud.PublicId;

        return model;
    }

    public async Task<ErrorOr<Success>> UpdateAsync(EarbudModel model)
    {
        var result = await dbContext.Earbuds.AsNoTracking()
                                                .Where(x => x.PublicId == model.Id)
                                                .ExecuteUpdateAsync(x => x.SetProperty(p => p.PublicId, model.Id)
                                                                          .SetProperty(p => p.ManufacturerId, model.Manufacturer.Id)
                                                                          .SetProperty(p => p.TypeId, model.Type.Id)
                                                                          .SetProperty(p => p.Model, model.Model)
                                                                          .SetProperty(p => p.ReleaseYear, model.ReleaseYear)
                                                                          .SetProperty(p => p.ImageId, model.ImageId)
                                                                          .SetProperty(p => p.WebContentLink, model.WebContentLink));
        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<Success>> DeleteAsync(string earbudId)
    {
        var result = await dbContext.Earbuds.AsNoTracking()
                                                .Include(x => x.Manufacturer)
                                                .Where(x => x.PublicId == earbudId)
                                                .ExecuteDeleteAsync();

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<EarbudModel>> GetByIdAsync(string earbudId)
    {
        var earbud = await dbContext.Earbuds.Include(x => x.Manufacturer)
                                                    .FirstOrDefaultAsync(x => x.PublicId == earbudId);

        if (earbud is null)
        {
            return Error.NotFound(description: "Earbud not found.");
        }

        return new EarbudModel(earbud);
    }

    public async Task<ErrorOr<List<EarbudModel>>> GetAllAsync() =>
        await dbContext.Earbuds.AsNoTracking()
                                   .Include(x => x.Manufacturer)
                                   .Select(x => new EarbudModel(x))
                                   .ToListAsync();

    public async Task<ErrorOr<PaginationModel<EarbudModel>>> GetPagedAsync(int page = 0)
    {
        page = page <= 0 ? 1 : page - 1;

        var earbuds = await dbContext.Earbuds.AsNoTracking()
                                                     .Include(x => x.Manufacturer)
                                                     .Include(x => x.Type)
                                                     .Skip(page * ROW_COUNT)
                                                     .Take(ROW_COUNT)
                                                     .Select(x => new EarbudModel(x))
                                                     .ToListAsync();

        var paginationModel = new PaginationModel<EarbudModel>
        {
            Items = earbuds,
            Count = await dbContext.Earbuds.CountAsync()
        };

        return paginationModel;
    }
}
