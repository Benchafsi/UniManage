using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityDatabaseManagementWebApp.DAO;
using UniversityDatabaseManagementWebApp.Models;
using UniversityDatabaseManagementWebApp.Service;

namespace UniversityDatabaseManagementWebApp.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService? service;

        internal List<Student> students = new();
        public IndexModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }

        public void OnGet()
        {
            try
            {
                students = service!.GetAllStudents();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


    }
}
