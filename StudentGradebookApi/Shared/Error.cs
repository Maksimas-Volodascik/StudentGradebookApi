namespace StudentGradebookApi.Shared
{
    public sealed record Error (string Code, string Field, string Message);
}
