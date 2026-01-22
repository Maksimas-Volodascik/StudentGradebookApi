using StudentGradebookApi.DTOs.Subjects;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.SubjectsRepository;

namespace StudentGradebookApi.Services.SubjectsService
{
    public class SubjectsService : ISubjectsService
    {
        private readonly ISubjectsRepository _subjectsRepository;
        public SubjectsService(ISubjectsRepository subjectsRepository) {
            _subjectsRepository = subjectsRepository;
        }

        public async Task<Subjects> AddSubjectAsync(SujectContentsDTO sujectContentsDTO)
        {
            Subjects newSubject = new Subjects();
            newSubject.SubjectName = sujectContentsDTO.subjectName;
            newSubject.SubjectCode = sujectContentsDTO.subjectCode;
            newSubject.Description = sujectContentsDTO.description;

            await _subjectsRepository.AddAsync(newSubject);
            await _subjectsRepository.SaveChangesAsync();
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

        public async Task<Subjects?> UpdateSubjectAsync(int id, SujectContentsDTO sujectContentsDTO)
        {
            Subjects? subjects = await _subjectsRepository.GetByIdAsync(id);
            if (subjects != null) { return null; }

            subjects!.SubjectName = sujectContentsDTO.subjectName;
            subjects.SubjectCode = sujectContentsDTO.subjectCode;
            subjects.Description = sujectContentsDTO.description;

            _subjectsRepository.Update(subjects);
            await _subjectsRepository.SaveChangesAsync();
            return subjects;
        }
    }
}
