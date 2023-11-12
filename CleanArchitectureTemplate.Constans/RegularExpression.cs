namespace CleanArchitectureReferenceTemplate.Constans
{
    public static class RegularExpression : object
    {
        static RegularExpression() { }

        public const string UserName = @"^[a-zA-Z0-9_]{6,20}$";
        public const string EmailAddress = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        public static string Password = @"^(?=.*[A-Z])(?=.*[0-9])(?!.*\s).{8,}$";
    }
}