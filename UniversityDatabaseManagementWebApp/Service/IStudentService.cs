using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Models;

namespace UniversityDatabaseManagementWebApp.Service
{
    public interface IStudentService
    {
        /// <summary>
        /// Inserts a student into the database
        /// with parameters taken from the user
        /// </summary>
        /// <param name="dto">The user input that is converted
        /// from StudentDTO to type Student.Then it is inserted into
        /// the STUDENTS table in our database </param>
        void InsertStudent(StudentDTO? dto);

        /// <summary>
        /// Updates a student record in the database
        /// with parameters taken from the user
        /// </summary>
        /// <param name="dto">The user input that is converted
        /// from StudentDTO to type Student.Then the student's
        /// first name and last name get replaced
        /// by the new values in STUDENTS table in our database</param>
        void UpdateStudent(StudentDTO? dto);

        /// <summary>
        /// Deletes a student record if it matches the user input or returns
        /// null if the record wasn't found
        /// </summary>
        /// <param name="dto">The user input that is converted
        /// from StudentDTO to type Student.</param>
        /// <returns>Returns the student that was deleted or null
        /// if the specified student was not found</returns>
        Student? DeleteStudent(StudentDTO? dto);

        /// <summary>
        /// Returns a student based on id
        /// </summary>
        /// <param name="id">The student's id</param>
        /// <returns>A Student object</returns>
        Student? GetStudentById(int id);

        /// <summary>
        /// Returns a list of all students currently
        /// in our database.
        /// </summary>
        /// <returns>A list of Student objects</returns>
        List<Student> GetAllStudents();
    }
}
