namespace Solution.Database.Entities;

[Table("Bill")]
public class BillEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string BillNumber { get; set; }

    [Required]
    public DateTime BillDate { get; set; }

    [ForeignKey("Item")]
    public int ItemId { get; set; }
    public virtual ItemEntity Item { get; set; }

}
