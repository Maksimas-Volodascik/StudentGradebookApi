using ToDoAPI.DTOs.SubjectClass;
using ToDoAPI.Models;
using ToDoAPI.Repositories.Main;

namespace ToDoAPI.Services.SubjectClassServices
{
    public class SubjectClassService : ISubjectClassService
    {
        /*private readonly IJoinedRepository _joinedRepo;

        public SubjectClassService(IJoinedRepository joinedRepo) {
            _joinedRepo = joinedRepo;
        }*/
        public Task<Classes> AddClasses(Classes classes)
        {
            throw new NotImplementedException();
        }

        public Task AddClassSubject(NewClassSubject newClassSubject)
        {
            throw new NotImplementedException();
        }

        public Task<Subjects> AddSubject(Subjects subjects)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClassesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSubjectAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Classes> GetAllClassesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Subjects> GetAllSubjectsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Classes> GetClassesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClassSubjects>> GetAllClassSubjects()
        {
            //return await _joinedRepo.GetClassSubjectsAsync();
            throw new NotImplementedException();
        }

        public Task<Subjects> GetSubjectAsync()
        {
            throw new NotImplementedException();
        }
    }
}
