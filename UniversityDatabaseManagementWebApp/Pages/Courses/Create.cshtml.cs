using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityDatabaseManagementWebApp.DAO;
using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Models;
using UniversityDatabaseManagementWebApp.Service;
using UniversityDatabaseManagementWebApp.Validator;

namespace UniversityDatabaseManagementWebApp.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService? service;

        internal List<Teacher> teachers = new();
        public CreateModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }

        internal CourseDTO courseDTO = new();
        public string errorMessage = "";

        public void OnGet()
        {
            try
            {
                teachers = service!.GetAllTeachersForKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public void OnPost()
        {
            errorMessage = "";

            teachers = service!.GetAllTeachersForKey();

            courseDTO.Description = Request.Form["description"];
            courseDTO.TeacherId = int.Parse(Request.Form["teacherid"]);

            errorMessage = CourseValidator.Validate(courseDTO);

            if (!errorMessage.Equals("")) return;

            try
            {
                service!.InsertCourse(courseDTO);
                Response.Redirect("/Courses/Index");

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }

        }
    }
}
