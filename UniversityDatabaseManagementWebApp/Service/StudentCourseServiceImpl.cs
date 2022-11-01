using UniversityDatabaseManagementWebApp.DAO;
using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Models;

namespace UniversityDatabaseManagementWebApp.Service
{
    public class StudentCourseServiceImpl : IStudentCourseService
    {
        private readonly IStudentCourseDAO dao;

        public StudentCourseServiceImpl(IStudentCourseDAO dao)
        {
            this.dao = dao;
        }

        public void InsertStudentCourse(StudentCourseDTO? dto)
        {
            if (dto is null) return;

            try
            {
                StudentCourse? studentCourse = ConvertStudentCourse(dto);
                dao.Insert(studentCourse);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public StudentCourse? DeleteStudentCourse(StudentCourseDTO? dto)
        {
            if (dto is null) return null;

            try
            {
                StudentCourse? studentCourse = ConvertStudentCourse(dto);
                return dao.Delete(studentCourse);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<StudentCourse> GetAllStudentCourses()
        {
            try
            {
                return dao.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<StudentCourse>();
            }
        }

        public List<Course> GetAllCourses()
        {
            try
            {
                return dao.GetAllC();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Course>();
            }
        }

        public List<Student> GetAllStudents()
        {
            try
            {
                return dao.GetAllS();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Student>();
            }
        }

        private StudentCourse? ConvertStudentCourse(StudentCourseDTO dto)
        {
            if (dto is null) return null;

            return new StudentCourse()
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId
            };
        }
    }
}
