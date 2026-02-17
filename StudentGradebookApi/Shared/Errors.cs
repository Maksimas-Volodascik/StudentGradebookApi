namespace StudentGradebookApi.Shared
{
    public class Errors
    {
        public static class Teacher
        {
            public const string NotFound = "Teacher not found.";
        }
        
        public static class User
        {
            public const string EmailExists = "Email is already registered.";
            public const string EmailInvalid = "Invalid email address format.";
            public const string EmailRequired = "Email is required.";
        }
    }
}
