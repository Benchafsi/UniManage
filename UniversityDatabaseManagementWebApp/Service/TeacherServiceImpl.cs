using UniversityDatabaseManagementWebApp.DAO;
using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Models;

namespace UniversityDatabaseManagementWebApp.Service
{
    public class TeacherServiceImpl : ITeacherService
    {
        private readonly ITeacherDAO dao;

        public TeacherServiceImpl(ITeacherDAO dao)
        {
            this.dao = dao;
        }

        public void InsertTeacher(TeacherDTO? dto)
        {
            if (dto is null) return;

            try
            {
                Teacher? teacher = Convert(dto);
                dao.Insert(teacher);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateTeacher(TeacherDTO? dto)
        {
            if (dto is null) return;

            try
            {
                Teacher? teacher = Convert(dto);
                dao.Update(teacher);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Teacher? DeleteTeacher(TeacherDTO? dto)
        {
            if (dto is null) return null;

            try
            {
                Teacher? teacher = Convert(dto);
                return dao.Delete(teacher);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Teacher? GetTeacher(int id)
        {
            try
            {
                return dao.GetTeacher(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            try
            {
                return dao.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Teacher>();
            }
        }

        private Teacher? Convert(TeacherDTO dto)
        {
            if (dto is null) return null;

            return new Teacher()
            {
                Id = dto.Id,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname
            };
        }
    }
}
