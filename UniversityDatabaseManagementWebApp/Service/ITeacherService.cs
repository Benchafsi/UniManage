using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Models;

namespace UniversityDatabaseManagementWebApp.Service
{
    public interface ITeacherService
    {

        /// <summary>
        /// Inserts a teacher record into the database
        /// with parameters taken from the user
        /// </summary>
        /// <param name="dto">The user input that is converted
        /// from TeacherDTO to type Teacher.Then it is inserted into
        /// the TEACHERS table in our database </param>
        void InsertTeacher(TeacherDTO? dto);

        /// <summary>
        /// Updates a teacher record in the database
        /// with parameters taken from the user
        /// </summary>
        /// <param name="dto">The user input that is converted
        /// from TeacherDTO to type Teacher.Then the teacher's
        /// first name and last name get replaced
        /// by the new values in TEACHERS table in our database</param>
        void UpdateTeacher(TeacherDTO? dto);

        /// <summary>
        /// Deletes a teacher record if it matches the user input or returns
        /// null if the record wasn't found
        /// </summary>
        /// <param name="dto">The user input that is converted
        /// from TeacherDTO to type Teacher.</param>
        /// <returns>Returns the teacher that was deleted or null
        /// if the specified teacher was not found</returns>
        Teacher? DeleteTeacher(TeacherDTO? dto);

        /// <summary>
        /// Returns a teacher based on id
        /// </summary>
        /// <param name="id">The teachers's id</param>
        /// <returns>A Teacher object</returns>
        Teacher? GetTeacher(int id);

        /// <summary>
        /// Returns a list of all teachers currently
        /// in our database.
        /// </summary>
        /// <returns>A list of Teacher objects</returns>
        List<Teacher> GetAllTeachers();
    }
}
