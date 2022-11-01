using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityDatabaseManagementWebApp.DAO;
using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Models;
using UniversityDatabaseManagementWebApp.Service;
using UniversityDatabaseManagementWebApp.Validator;

namespace UniversityDatabaseManagementWebApp.Pages.Courses
{
    public class UpdateModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService? service;

        internal List<Teacher> teachers = new();
        public UpdateModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }

        internal CourseDTO courseDTO = new();
        public string errorMessage = "";

        public void OnGet()
        {
            errorMessage = "";

            try
            {
                Course? course;

                int id = int.Parse(Request.Query["id"]);
                course = service!.GetCourse(id);
                if (course != null)
                {
                    courseDTO = ConvertToDTO(course);
                }
                teachers = service!.GetAllTeachersForKey();
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }

        public void OnPost()
        {
            errorMessage = "";
            teachers = service!.GetAllTeachersForKey();

            courseDTO.Id = int.Parse(Request.Form["id"]);
            courseDTO.Description = Request.Form["description"];
            courseDTO.TeacherId = int.Parse(Request.Form["teacherid"]);

            errorMessage = CourseValidator.Validate(courseDTO);

            if (!errorMessage.Equals("")) return;

            try
            {
                service!.UpdateCourse(courseDTO);
                Response.Redirect("/Courses/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }

        private CourseDTO ConvertToDTO(Course dto)
        {
            return new CourseDTO()
            {
                Id = dto.Id,
                Description = dto.Description!.Trim()
            };
        }
    }
}
