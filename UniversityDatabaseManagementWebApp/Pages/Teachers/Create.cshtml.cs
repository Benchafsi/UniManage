using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityDatabaseManagementWebApp.DAO;
using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Models;
using UniversityDatabaseManagementWebApp.Service;
using UniversityDatabaseManagementWebApp.Validator;

namespace UniversityDatabaseManagementWebApp.Pages.Teachers
{
    public class CreateModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService? service;

        internal List<Teacher> teachers = new();
        public CreateModel()
        {
            service = new TeacherServiceImpl(teacherDAO);
        }

        internal TeacherDTO teacherDTO = new();
        public string errorMessage = "";

        public void OnGet()
        {

        }

        public void OnPost()
        {
            errorMessage = "";

            teacherDTO.Firstname = Request.Form["firstname"];
            teacherDTO.Lastname = Request.Form["lastname"];

            errorMessage = TeacherValidator.Validate(teacherDTO);

            if (!errorMessage.Equals("")) return;

            try
            {
                service!.InsertTeacher(teacherDTO);
                Response.Redirect("/Teachers/Index");

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }

        }
    }
}
