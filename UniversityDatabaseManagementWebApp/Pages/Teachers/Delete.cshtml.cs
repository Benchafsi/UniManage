using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityDatabaseManagementWebApp.DAO;
using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Models;
using UniversityDatabaseManagementWebApp.Service;

namespace UniversityDatabaseManagementWebApp.Pages.Teachers
{
    public class DeleteModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService? service;

        internal List<Teacher> teachers = new();
        public DeleteModel()
        {
            service = new TeacherServiceImpl(teacherDAO);
        }

        internal TeacherDTO teacherDTO = new();
        public string errorMessage = "";

        public void OnGet()
        {

            try
            {
                Teacher? teacher;

                int id = int.Parse(Request.Query["id"]);
                teacherDTO.Id = id;

                teacher = service!.DeleteTeacher(teacherDTO);
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
