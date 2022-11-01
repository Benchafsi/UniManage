using UniversityDatabaseManagementWebApp.DAO;
using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Models;

namespace UniversityDatabaseManagementWebApp.Service
{
    public class StudentServiceImpl : IStudentService
    {
        private readonly IStudentDAO dao;

        public StudentServiceImpl(IStudentDAO dao)
        {
            this.dao = dao;
        }

        public void InsertStudent(StudentDTO? dto)
        {
            if (dto is null) return;

            try
            {
                Student? student = Convert(dto);
                dao.Insert(student);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateStudent(StudentDTO? dto)
        {
            if (dto is null) return;

            try
            {
                Student? student = Convert(dto);
                dao.Update(student);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public Student? DeleteStudent(StudentDTO? dto)
        {
            if (dto is null) return null;

            try
            {
                Student? student = Convert(dto);
                return dao.Delete(student);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public Student? GetStudentById(int id)
        {
            try
            {
                return dao.GetStudent(id);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public List<Student> GetAllStudents()
        {
            try
            {
                return dao.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Student>();
            }
        }


        private Student? Convert(StudentDTO dto)
        {
            if (dto is null) return null;

            return new Student()
            {
                Id = dto.Id,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname
            };
        }
    }
}
