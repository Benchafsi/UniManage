namespace UniversityDatabaseManagementWebApp.DTO
{
    public class StudentCourseDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public override string ToString() => $"{StudentId}, {CourseId}";
    }
}
