namespace Solution.Validators;

public class ItemModelValidator : BaseValidator<ManufacturerModel>
{
    public static string NameProperty => nameof(ManufacturerModel.Name);
    public static string GlobalProperty => "Global";

    public ItemModelValidator(IHttpContextAccessor httpContextAccessor = null) : base(httpContextAccessor)
    {
        if (IsPutMethod)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }

        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
    }
}

