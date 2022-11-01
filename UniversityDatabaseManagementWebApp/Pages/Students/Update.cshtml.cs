using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityDatabaseManagementWebApp.DAO;
using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Models;
using UniversityDatabaseManagementWebApp.Service;
using UniversityDatabaseManagementWebApp.Validator;

namespace UniversityDatabaseManagementWebApp.Pages.Students
{
    public class UpdateModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService service;

        public UpdateModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }

        internal StudentDTO studentDTO = new();
        internal string errorMessage = "";


        public void OnGet()
        {
            errorMessage = "";

            try
            {
                Student? student;

                int id = int.Parse(Request.Query["id"]);

                student = service.GetStudentById(id);

                if (student != null)
                {
                    studentDTO = ConvertToDTO(student);
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

            studentDTO.Id = int.Parse(Request.Form["id"]);
            studentDTO.Firstname = Request.Form["firstname"];
            studentDTO.Lastname = Request.Form["lastname"];

            errorMessage = StudentValidator.Validate(studentDTO);

            if (!errorMessage.Equals("")) return;

            try
            {
                service.UpdateStudent(studentDTO);
                Response.Redirect("/Students/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }

        private StudentDTO ConvertToDTO(Student dto)
        {
            return new StudentDTO()
            {
                Id = dto.Id,
                Firstname = dto.Firstname!.Trim(),
                Lastname = dto.Lastname!.Trim()
            };
        }
    }
}
