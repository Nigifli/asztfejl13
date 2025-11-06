namespace Solution.Database.Entities;

[Table("Item")]
public class ItemEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(64)]
    [Required]
    public string Title { get; set; }

    [Required]
    public int Price { get; set; }

    [Required]
    public int Amount { get; set; }
    public virtual ICollection<BillEntity> Bills { get; set; }
}
