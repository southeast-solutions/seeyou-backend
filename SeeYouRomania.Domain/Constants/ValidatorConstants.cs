namespace Domain.Constants
{
    public static class ValidatorConstants
    {
        public const string URI_PATTERN = "^(https?://)"
               + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?"
               + @"(([0-9]{1,3}\.){3}[0-9]{1,3}"
               + "|"
               + @"([0-9a-z_!~*'()-]+\.)*"
               + @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\."
               + "[a-z]{2,6})"
               + "(:[0-9]{1,4})?"
               + "((/?)|"
               + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
        public const string FIRST_NAME_PATTERN = "^[\\w'\\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\\]]{2,}$";
        public const string LAST_NAME_PATTERN = "^[\\w'\\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\\]]{2,}$";
        public static readonly string[] CITY_NAMES = { "Bucharest" };
        public static readonly string[] COUNTRY_NAMES = { "Romania" };

    }
}
