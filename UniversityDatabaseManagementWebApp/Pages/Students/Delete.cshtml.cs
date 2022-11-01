using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityDatabaseManagementWebApp.DAO;
using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Models;
using UniversityDatabaseManagementWebApp.Service;

namespace UniversityDatabaseManagementWebApp.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService service;

        public DeleteModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }

        internal StudentDTO studentDTO = new();
        internal string errorMessage = "";


        public void OnGet()
        {

            try
            {
                Student? student;

                int id = int.Parse(Request.Query["id"]);
                studentDTO.Id = id;

                student = service.DeleteStudent(studentDTO);
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
