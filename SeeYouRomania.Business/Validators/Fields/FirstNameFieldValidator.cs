using Domain.Constants;
using System.Text.RegularExpressions;

namespace Business.Validators.Fields
{
    public class FirstNameFieldValidator : FieldValidator
    {
        public override bool IsValid(string fieldValue)
        {
            Regex re = new Regex(ValidatorConstants.FIRST_NAME_PATTERN);
            return base.IsValid(fieldValue)
                && re.IsMatch(fieldValue);
        }
    }
}
