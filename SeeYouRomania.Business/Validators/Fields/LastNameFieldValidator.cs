using Domain.Constants;
using System.Text.RegularExpressions;

namespace Business.Validators.Fields
{
    public class LastNameFieldValidator : FieldValidator
    {
        public override bool IsValid(string fieldValue)
        {
            Regex re = new Regex(ValidatorConstants.LAST_NAME_PATTERN);
            return base.IsValid(fieldValue)
                && re.IsMatch(fieldValue);
        }
    }
}
