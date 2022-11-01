using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityDatabaseManagementWebApp.DAO;
using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Models;
using UniversityDatabaseManagementWebApp.Service;

namespace UniversityDatabaseManagementWebApp.Pages.StudentsCourses
{
    public class CreateModel : PageModel
    {
        private readonly IStudentCourseDAO studentCourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService? service;

        internal List<Course> courses = new();
        internal List<Student> students = new();
        public CreateModel()
        {
            service = new StudentCourseServiceImpl(studentCourseDAO);
        }

        internal StudentCourseDTO studentCourseDTO = new();
        public string errorMessage = "";

        public void OnGet()
        {
            try
            {
                students = service!.GetAllStudents();
                courses = service!.GetAllCourses();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        public void OnPost()
        {
            students = service!.GetAllStudents();
            courses = service!.GetAllCourses();
            errorMessage = "";

            try
            {

                studentCourseDTO.StudentId = int.Parse(Request.Form["studentid"]);
                studentCourseDTO.CourseId = int.Parse(Request.Form["courseid"]);

                service!.InsertStudentCourse(studentCourseDTO);
                Response.Redirect("/StudentsCourses/Index");

            }
            catch (Exception)
            {
                errorMessage = "Wrong Input - Undergraduate " +
                    "is already enrolled to the specific Subject";
                return;
            }
        }
    }
}
