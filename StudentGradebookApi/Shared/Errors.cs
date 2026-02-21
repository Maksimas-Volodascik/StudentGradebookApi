namespace StudentGradebookApi.Shared
{
    public class Errors
    {
        public static class GenericErrors
        {
            public static readonly Error InternalServerError = new("internal.server.error", null, "Something went wrong. Please try again later.");
        }

        public static class TeacherErrors
        {
            public static readonly Error FirstNameMissing = new("teacher.firstname.missing", "FirstName", "First name is required.");
            public static readonly Error LastNameMissing = new("teacher.lastname.missing", "LastName", "Last name is required.");
            public static readonly Error TeacherNotFound = new("teacher.not.found", null, "Teacher not found.");
        }

        public static class UserErrors
        {
            public static readonly Error EmailExists = new ("user.email.exists", "email", "Email already exists.");
            public static readonly Error EmailInvalid = new ("user.email.invalid", "email", "Invalid email address format.");
            public static readonly Error EmailRequired = new("user.email.required", "email", "Email is required.");
            public static readonly Error PasswordRequired = new("user.password.required", "password", "Password is required.");
            public static readonly Error InvalidUserCredentials = new("auth.invalid.credentials", "password", "Invalid email or password");
            public static readonly Error UserNotFound = new("user.not.found", null, "User not found.");
        }
    }
}
