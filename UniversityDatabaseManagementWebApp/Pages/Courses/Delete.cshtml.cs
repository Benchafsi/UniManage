using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityDatabaseManagementWebApp.DAO;
using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Models;
using UniversityDatabaseManagementWebApp.Service;

namespace UniversityDatabaseManagementWebApp.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService? service;

        public DeleteModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }

        internal CourseDTO courseDTO = new();
        public string errorMessage = "";


        public void OnGet()
        {

            try
            {
                Course? course;

                int id = int.Parse(Request.Query["id"]);
                courseDTO.Id = id;

                course = service!.DeleteCourse(courseDTO);
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
