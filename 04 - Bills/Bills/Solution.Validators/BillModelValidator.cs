using Microsoft.AspNetCore.Http;
using Solution.Database.Migrations;

namespace Solution.Validators;

public class BillModelValidator: BaseValidator<BillModel>
{
    public static string ModelProperty => nameof(BillModel.Model);
    public static string CubicProperty => nameof(BillModel.Cubic);
    public static string ManufacturerProperty => nameof(BillModel.Manufacturer);
    public static string TypeProperty => nameof(BillModel.Type);
    public static string NumberOfCylindersProperty => nameof(BillModel.NumberOfCylinders);
    public static string ReleaseYearProperty => nameof(BillModel.ReleaseYear);
    public static string GlobalProperty => "Global";

    public MotorcycleModelValidator(IHttpContextAccessor httpContextAccessor): base(httpContextAccessor)
    {
        if (IsPutMethod)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            //validalni h az id letezik
        }

        RuleFor(x => x.Model).NotEmpty().WithMessage("Model is required");
        
        RuleFor(x => x.Cubic).NotNull().WithMessage("Cubic is required")
                             .GreaterThan(0).WithMessage("Cubic has to be greater then 0");
        
        RuleFor(x => x.Manufacturer).NotNull().WithMessage("Manufacturer is required");

        RuleFor(x => x.Manufacturer.Id).GreaterThan(0).WithMessage("Manufacturer's ID has to be greater than 0");

        //csak olyan id-t fogadjunk el ami letezik az adatbazisban (validalni,h a gyarto id letezik az adatbazisban)
        /* segitseg: 
         * RuleFor(x => x.Id).MustAsync 
        */

        RuleFor(x => x.Type).NotNull().WithMessage("Type is required");

        RuleFor(x => x.Type.Id).GreaterThan(0).WithMessage("Type's ID has to be greater than 0");

        RuleFor(x => x.NumberOfCylinders).NotNull().WithMessage("Number of cylinders is required")
                                         .InclusiveBetween(1, 8).WithMessage("Number of cylynders has to be between 1 and 8");
        
        RuleFor(x => x.ReleaseYear).NotNull().WithMessage("Release year is required")
                                   .InclusiveBetween(1900, DateTime.Now.Year).WithMessage("Invalid release year");
    }
}
