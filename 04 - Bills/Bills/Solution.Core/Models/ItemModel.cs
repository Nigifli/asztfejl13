namespace Solution.Core.Models;

public partial class ItemModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private int id;

    [ObservableProperty]
    [JsonPropertyName("title")]
    private string title;

    [ObservableProperty]
    [JsonPropertyName("price")]
    private int price;

    [ObservableProperty]
    [JsonPropertyName("amount")]
    private int amount;

    public ItemModel()
    {
    }

    public ItemModel(ItemEntity entity)
    {
        this.Id = entity.Id;
        this.Title = entity.Title;
        this.Price = entity.Price;
        this.Amount = entity.Amount;
    }

    public ItemEntity ToEntity()
    {
        return new ItemEntity
        {
            Id = Id,
            Name = Name
        };
    }

    public void ToEntity(ItemEntity entity)
    {
        entity.Id = Id;
        entity.Name = Name;
    }

    public override bool Equals(object? obj)
    {
        return obj is ItemModel model &&
               this.Id == model.Id &&
               this.Name == model.Name;
    }
}