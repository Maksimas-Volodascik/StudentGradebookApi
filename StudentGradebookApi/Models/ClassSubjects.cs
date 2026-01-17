namespace StudentGradebookApi.Models
{
    public class ClassSubjects
    {
        public int Id { get; set; }
        public int ClassId { get; set; } //FK
        public Classes Classes { get; set; } = null!;
        public int SubjectId { get; set; } //FK
        public Subjects Subjects { get; set; } = null!;
        public int TeacherId {  get; set; }//FK
        public Teachers Teachers { get; set; } = null!;
        public List<Enrollments> Enrollments { get; set; } = new();
    }
}
