using AutoMapper;
using StudentGradebookApi.DTOs.Students;
using StudentGradebookApi.Models;

namespace StudentGradebookApi.Mappings
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Students, StudentList>();
        }
        
    }
}
