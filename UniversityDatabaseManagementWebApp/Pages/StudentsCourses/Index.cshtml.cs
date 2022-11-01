using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityDatabaseManagementWebApp.DAO;
using UniversityDatabaseManagementWebApp.Models;
using UniversityDatabaseManagementWebApp.Service;

namespace UniversityDatabaseManagementWebApp.Pages.StudentsCourses
{
    public class IndexModel : PageModel
    {
        private readonly IStudentCourseDAO studentCourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService? service;

        internal List<Course> courses = new();
        internal List<Student> students = new();
        internal List<StudentCourse> studentCourses = new();
        public IndexModel()
        {
            service = new StudentCourseServiceImpl(studentCourseDAO);
        }
        public void OnGet()
        {
            try
            {
                courses = service!.GetAllCourses();
                students = service!.GetAllStudents();
                studentCourses = service!.GetAllStudentCourses();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
