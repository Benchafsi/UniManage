using UniversityDatabaseManagementWebApp.Models;

namespace UniversityDatabaseManagementWebApp.DAO
{
    public interface IStudentCourseDAO
    {
        void Insert(StudentCourse? studentCourse);
        StudentCourse? Delete(StudentCourse? studentCourse);
        List<StudentCourse> GetAll();
        List<Student> GetAllS();
        List<Course> GetAllC();
    }
}
