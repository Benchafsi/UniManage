using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityDatabaseManagementWebApp.DAO;
using UniversityDatabaseManagementWebApp.Models;
using UniversityDatabaseManagementWebApp.Service;

namespace UniversityDatabaseManagementWebApp.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService? service;

        internal List<Course> courses = new();
        internal List<Teacher> teachers = new();
        public IndexModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }
        public void OnGet()
        {
            try
            {
                courses = service!.GetAllCourses();
                teachers = service!.GetAllTeachersForKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }


        }
    }
}
