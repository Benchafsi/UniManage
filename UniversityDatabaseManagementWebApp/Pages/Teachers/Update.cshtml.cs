using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityDatabaseManagementWebApp.DAO;
using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Models;
using UniversityDatabaseManagementWebApp.Service;
using UniversityDatabaseManagementWebApp.Validator;

namespace UniversityDatabaseManagementWebApp.Pages.Teachers
{
    public class UpdateModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService? service;

        internal List<Teacher> teachers = new();
        public UpdateModel()
        {
            service = new TeacherServiceImpl(teacherDAO);
        }

        internal TeacherDTO teacherDTO = new();
        public string errorMessage = "";

        public void OnGet()
        {
            errorMessage = "";

            try
            {
                Teacher? teacher;

                int id = int.Parse(Request.Query["id"]);
                teacher = service!.GetTeacher(id);
                if (teacher != null)
                {
                    teacherDTO = ConvertToDTO(teacher);
                }
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

            teacherDTO.Id = int.Parse(Request.Form["id"]);
            teacherDTO.Firstname = Request.Form["firstname"];
            teacherDTO.Lastname = Request.Form["lastname"];

            errorMessage = TeacherValidator.Validate(teacherDTO);

            if (!errorMessage.Equals("")) return;

            try
            {
                service!.UpdateTeacher(teacherDTO);
                Response.Redirect("/Teachers/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }

        private TeacherDTO ConvertToDTO(Teacher dto)
        {
            return new TeacherDTO()
            {
                Id = dto.Id,
                Firstname = dto.Firstname!.Trim(),
                Lastname = dto.Lastname!.Trim()
            };
        }
    }
}
