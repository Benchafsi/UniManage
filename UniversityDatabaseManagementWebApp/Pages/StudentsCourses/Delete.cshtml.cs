using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityDatabaseManagementWebApp.DAO;
using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Models;
using UniversityDatabaseManagementWebApp.Service;

namespace UniversityDatabaseManagementWebApp.Pages.StudentsCourses
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentCourseDAO studentCourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService? service;

        internal List<Course> courses = new();
        internal List<Student> students = new();
        public DeleteModel()
        {
            service = new StudentCourseServiceImpl(studentCourseDAO);
        }

        internal StudentCourseDTO studentCourseDTO = new();
        public string errorMessage = "";

        public void OnGet()
        {

            try
            {
                StudentCourse? studentCourse;

                int id = int.Parse(Request.Query["id"]);
                int id1 = int.Parse(Request.Query["id1"]);
                studentCourseDTO.StudentId = id;
                studentCourseDTO.CourseId = id1;

                studentCourse = service!.DeleteStudentCourse(studentCourseDTO);
                Response.Redirect("/StudentsCourses/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
