namespace Solution.Core.Models;

public partial class BillModel: ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private int id;

    [ObservableProperty]
    [JsonPropertyName("billNumber")]
    private string billNumber;

    [ObservableProperty]
    [JsonPropertyName("billDate")]
    private DateTime billDate;

    [ObservableProperty]
    [JsonPropertyName("items")]
    private List<ItemModel> items;


    public BillModel()
    {
    }

    public BillModel(BillEntity entity)
    {
        this.Id = entity.Id;
        this.BillNumber = entity.BillNumber;
        this.BillDate = entity.BillDate;
    }

    public BillEntity ToEntity()
    {
        return new BillEntity
        {
            Id = Id,
            BillNumber = BillNumber,
            BillDate = BillDate
        };
    }

    public void ToEntity(BillEntity entity)
    {
        entity.Id = Id;
        entity.BillNumber = BillNumber;
        entity.BillDate = BillDate;
    }
}
