using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityDatabaseManagementWebApp.DAO;
using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Service;
using UniversityDatabaseManagementWebApp.Validator;

namespace UniversityDatabaseManagementWebApp.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService? service;

        internal StudentDTO studentDTO = new();

        public string errorMessage = "";
        public string successMessage = "";

        public CreateModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }
        public void OnGet()
        {

        }

        public void OnPost()
        {
            errorMessage = "";
            successMessage = "";

            studentDTO.Firstname = Request.Form["firstname"];
            studentDTO.Lastname = Request.Form["lastname"];

            errorMessage = StudentValidator.Validate(studentDTO);

            if (!errorMessage.Equals("")) return;

            try
            {
                service!.InsertStudent(studentDTO);
                Response.Redirect("/Students/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
