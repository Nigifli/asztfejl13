using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bills.Core.Req;

public partial class ItemModelReq : ItemModel
{
    [JsonPropertyName("billId")]

    public int BillId { get; set; }

    public ItemEntity ToEntity()
    {
        return new ItemEntity
        {
            Id = this.Id,
            Name = this.Name,
            Price = this.Price,
            Amount = this.Amount,
            BillId = this.BillId
        };
    }
}
