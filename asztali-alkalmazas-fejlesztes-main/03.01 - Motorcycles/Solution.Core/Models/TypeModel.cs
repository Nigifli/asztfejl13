using Solution.Database.Migrations;
using static System.Net.Mime.MediaTypeNames;

namespace Solution.Core.Models;

public partial class TypeModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private int id;

    [ObservableProperty]
    [JsonPropertyName("name")]
    private string name;

    public TypeModel()
    {
    }

    public TypeModel(MotorcycleTypeEntity entity)
    {
        this.Id = entity.Id;
        this.Name = entity.Name;
    }

    public MotorcycleTypeEntity ToEntity()
    {
        return new MotorcycleTypeEntity
        {
            Id = Id,
            Name = name
        };
    }

    public void ToEntity(MotorcycleTypeEntity entity)
    {
        entity.Id = id;
        entity.Name = name;
    }

   public override bool Equals(object? obj)
    {
        return obj is TypeModel type &&
            this.Id == type.Id &&
            this.Name == type.Name;
    } 
}
