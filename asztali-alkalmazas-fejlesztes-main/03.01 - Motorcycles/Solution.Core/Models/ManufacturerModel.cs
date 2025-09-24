using Solution.Database.Migrations;
using static System.Net.Mime.MediaTypeNames;

namespace Solution.Core.Models;

public partial class ManufacturerModel : ObservableObject
{
    [ObservableProperty]
    private int id;

    [ObservableProperty]
    private string name;

    public ManufacturerModel()
    {
    }

    public ManufacturerModel(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public ManufacturerEntity ToEntity()
    {
        return new ManufacturerEntity
        {
            Name = name
        };
    }

    public ManufacturerModel(ManufacturerEntity entity)
    {
        if(entity is null)
        {
            return;
        }

        Id = entity.Id;
        Name = entity.Name;
    }

    public void ToEntity(ManufacturerEntity entity)
    {
        entity.Name = name;
    }
}
