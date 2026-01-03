namespace ToDoAPI.DTOs.Students
{
    public class StudentGrades
    {
        public int StudentID {  get; set; }
        public string StudentName { get; set; }
        public List<int> Grades { get; set; }= new List<int>();

    }
}
