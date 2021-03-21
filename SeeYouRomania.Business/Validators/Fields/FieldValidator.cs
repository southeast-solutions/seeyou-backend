namespace Business.Validators.Fields
{
    public class FieldValidator
    {
        public virtual bool IsValid(string fieldValue)
        {
            return !string.IsNullOrEmpty(fieldValue);
        }
    }
}
