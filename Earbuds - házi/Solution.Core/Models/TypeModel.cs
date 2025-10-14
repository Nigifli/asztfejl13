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

    public TypeModel(EarbudTypeEntity entity)
    {
        this.Id = entity.Id;
        this.Name = entity.Name;
    }

    public EarbudTypeEntity ToEntity()
    {
        return new EarbudTypeEntity
        {
            Id = Id,
            Name = Name
        };
    }

    public void ToEntity(EarbudTypeEntity entity)
    {
        entity.Id = Id;
        entity.Name = Name;
    }

    public override bool Equals(object? obj)
    {
        return obj is TypeModel model &&
               this.Id == model.Id &&
               this.Name == model.Name;
    }
}