using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.SubjectsRepository;

namespace StudentGradebookApi.Services.SubjectsService
{
    public class SubjectsService : ISubjectsService
    {
        private readonly SubjectsRepository _subjectsRepository;
        public SubjectsService(SubjectsRepository subjectsRepository) {
            _subjectsRepository = subjectsRepository;
        }

        public async Task<Subjects> AddSubjectAsync(string subjectName, string subjectCode, string description)
        {
            Subjects newSubject = new Subjects();
            newSubject.SubjectName = subjectName;
            newSubject.SubjectCode = subjectCode;
            newSubject.Description = description;

            await _subjectsRepository.AddAsync(newSubject);

            return newSubject;
        }

        public async Task<Subjects?> DeleteSubjectAsync(int id)
        {
            Subjects? subjectToDelete = await _subjectsRepository.GetByIdAsync(id);
            if (subjectToDelete != null)
            {
                return null;
            }
            else
            {
                _subjectsRepository.Delete(subjectToDelete!);
                await _subjectsRepository.SaveChangesAsync();
                return subjectToDelete;
            }
        }

        public async Task<IEnumerable<Subjects>> GetAllSubjectsAsync()
        {
            var subjects = await _subjectsRepository.GetAllAsync();
            return subjects;
        }

        public async Task<Subjects?> GetSubjectByIdAsync(int id)
        {
            Subjects? subject = await _subjectsRepository.GetByIdAsync(id);
            return subject;
        }

        public async Task<Subjects?> UpdateSubjectAsync(int id, string subjectName, string subjectCode, string description)
        {
            Subjects? subjects = await _subjectsRepository.GetByIdAsync(id);
            if (subjects != null) { return null; }

            subjects!.SubjectName = subjectName;
            subjects.SubjectCode = subjectCode;
            subjects.Description = description;

            _subjectsRepository.Update(subjects);
            await _subjectsRepository.SaveChangesAsync();
            return subjects;
        }
    }
}
