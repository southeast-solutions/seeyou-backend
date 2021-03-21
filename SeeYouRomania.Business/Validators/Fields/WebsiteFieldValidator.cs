using Domain.Constants;
using System.Text.RegularExpressions;

namespace Business.Validators.Fields
{
    public class WebsiteFieldValidator : FieldValidator
    {
        public override bool IsValid(string fieldValue)
        {
            Regex re = new Regex(ValidatorConstants.URI_PATTERN);
            return base.IsValid(fieldValue)
                && re.IsMatch(fieldValue);
        }
    }
}
