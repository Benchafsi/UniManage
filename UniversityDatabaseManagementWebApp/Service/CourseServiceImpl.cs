using UniversityDatabaseManagementWebApp.DAO;
using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Models;

namespace UniversityDatabaseManagementWebApp.Service
{
    public class CourseServiceImpl : ICourseService
    {
        private readonly ICourseDAO dao;

        public CourseServiceImpl(ICourseDAO dao)
        {
            this.dao = dao;
        }

        public void InsertCourse(CourseDTO? dto)
        {
            if (dto is null) return;

            try
            {
                Course? course = ConvertCourse(dto);
                dao.Insert(course);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateCourse(CourseDTO? dto)
        {
            if (dto is null) return;

            try
            {
                Course? course = ConvertCourse(dto);
                dao.Update(course);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Course? DeleteCourse(CourseDTO? dto)
        {
            if (dto is null) return null;

            try
            {
                Course? course = ConvertCourse(dto);
                return dao.Delete(course);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Course? GetCourse(int id)
        {
            try
            {
                return dao.GetCourse(id);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Course> GetAllCourses()
        {
            try
            {
                return dao.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Course>();
            }
        }

        public List<Teacher> GetAllTeachersForKey()
        {
            try
            {
                return dao.GetAllTeachers();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Teacher>();
            }
        }

        private Course? ConvertCourse(CourseDTO dto)
        {
            if (dto is null) return null;

            return new Course()
            {
                Id = dto.Id,
                Description = dto.Description,
                TeacherId = dto.TeacherId
            };
        }
    }
}
