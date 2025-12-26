using AutoMapper;
using ToDoAPI.DTOs.Students;
using ToDoAPI.Models;

namespace ToDoAPI.Mappings
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Students, StudentList>();
        }
        
    }
}
