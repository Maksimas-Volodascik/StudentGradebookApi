using StudentGradebookApi.DTOs.Classes;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.ClassesRepository;

namespace StudentGradebookApi.Services.ClassesServices
{
    public class ClassesServices : IClassesServices
    {
        private readonly IClassesRepository _classesRepository;
        public ClassesServices(IClassesRepository classesRepository) { 
            _classesRepository = classesRepository;
        }

        public async Task<Classes> AddClassAsync(ClassesContentsDTO classesContentsDTO)
        {
            Classes newClass = new Classes();
            newClass.Room = classesContentsDTO.room;
            newClass.AcademicYear = classesContentsDTO.academicYear;

            await _classesRepository.AddAsync(newClass);
            await _classesRepository.SaveChangesAsync();

            return newClass;
        }

        public async Task<IEnumerable<Classes?>> GetAllClassesAsync()
        {
            var classes = await _classesRepository.GetAllAsync();
            if (classes == null)
            {
                return Enumerable.Empty<Classes>(); //In controller check with !classes.Any() if there are any classes
            }
            return classes;
        }

        public async Task<Classes?> GetClassByIdAsync(int id)
        {
            Classes? classes = await _classesRepository.GetByIdAsync(id);

            return classes;
        }

        public async Task<IEnumerable<Classes?>> GetClassesByYearAsync(string academicYear)
        {
            var classes = await _classesRepository.GetClassesByYearAsync(academicYear);
            if (classes is null)
            {
                return Enumerable.Empty<Classes>();
            } 
            return classes;
        }

        public async Task<Classes?> UpdateClassAsync(int id, ClassesContentsDTO classesContentsDTO)
        {
            Classes? newClass = await _classesRepository.GetByIdAsync(id);
            if (newClass == null)
            {
                return null;
            }
            newClass.Room = classesContentsDTO.room;
            newClass.AcademicYear = classesContentsDTO.academicYear;
            _classesRepository.Update(newClass);
            await _classesRepository.SaveChangesAsync();

            return newClass;
        }
    }
}
