namespace Solution.Core.Models;

public partial class EarbudModel: ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private string id;

    [ObservableProperty]
    [JsonPropertyName("imageId")]
    private string imageId;

    [ObservableProperty]
    [JsonPropertyName("webContentLink")]
    private string webContentLink;

    [ObservableProperty]
    [JsonPropertyName("manufacturer")]
    private ManufacturerModel manufacturer;

    [ObservableProperty]
    [JsonPropertyName("")]
    private TypeModel type;

    [ObservableProperty]
    [JsonPropertyName("model")]
    private string model;

    [ObservableProperty]
    private int? releaseYear;

    [ObservableProperty]
    [JsonPropertyName("numberOfCylinders")]
    private int? numberOfCylinders;

    public EarbudModel()
    {
    }

    public EarbudModel(EarbudEntity entity)
    {
        this.Id = entity.PublicId;
        this.ImageId = entity.ImageId;
        this.WebContentLink = entity.WebContentLink;
        this.Manufacturer = new ManufacturerModel(entity.Manufacturer);
        this.Type = new TypeModel(entity.Type);
        this.Model = entity.Model;
        this.ReleaseYear = entity.ReleaseYear;
    }

    public EarbudEntity ToEntity()
    {
        return new EarbudEntity
        {
            PublicId = Id,
            ManufacturerId = Manufacturer.Id,
            TypeId = Type.Id,
            ImageId = ImageId,
            WebContentLink = WebContentLink,
            Model = Model,
            ReleaseYear = ReleaseYear.Value
        };
    }

    public void ToEntity(EarbudEntity entity)
    {
        entity.PublicId = Id;
        entity.ManufacturerId = Manufacturer.Id;
        entity.TypeId = Type.Id;
        entity.ImageId = ImageId;
        entity.WebContentLink = WebContentLink;
        entity.Model = Model;
        entity.ReleaseYear = ReleaseYear.Value;
    }
}
