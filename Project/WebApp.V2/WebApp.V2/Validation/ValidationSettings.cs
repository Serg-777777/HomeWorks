namespace Presentation.Validation
{
    public class ValidationSettings
    {
        public const int IdLessThan = int.MaxValue;
        public const int IdGreaterThan = 0;
        public const string IdMSG = "ID not correct";

        public const int LoginMinimumLength = 5;
        public const int LoginMaximumLength = 100;
        public const string LoginMSG = "Login not correct";

        public const int PassMinimumLength = 5;
        public const int PassMaximumLength = 10;
        public const string PassMSG = "Password not correct";

        public const int EmailMaximumLength = 200;
        public const string EmailMSG = "Email not correct";

        public const int RoleMinimumLength = 5;
        public const int RoleMaximumLength = 15;
        public const string RoleMSG = "Role not correct";

    }
}
