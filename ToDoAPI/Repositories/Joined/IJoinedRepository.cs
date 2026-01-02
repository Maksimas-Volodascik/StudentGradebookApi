using ToDoAPI.DTOs.SubjectClass;

namespace ToDoAPI.Repositories.Joined
{
    public interface IJoinedRepository
    {
        Task<IEnumerable<ClassSubjects>> GetClassSubjectsAsync();

        //Custom repository that will have special database logic
        //e.g. GetStudentEnrollmentsWithGradesAsync
    }
}
