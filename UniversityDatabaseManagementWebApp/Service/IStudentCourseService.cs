using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Models;

namespace UniversityDatabaseManagementWebApp.Service
{
    public interface IStudentCourseService
    {
        /// <summary>
        /// Inserts a StudentCourse record in the database
        /// the parameters should be a valid student id
        /// and a valid course id
        /// </summary>
        /// <param name="dto">The DTO object the user provides</param>
        void InsertStudentCourse(StudentCourseDTO? dto);

        /// <summary>
        /// Deletes a StudentCourse record in the database
        /// based on user input.It returns null if the input 
        /// is null or doesnt exist
        /// </summary>
        /// <param name="dto">The DTO object the user provides</param>
        /// <returns>The old entry if the input matched an record or 
        /// null if the input was not found or was null</returns>
        StudentCourse? DeleteStudentCourse(StudentCourseDTO? dto);

        /// <summary>
        /// Returns a List of type StudentCourse of all the records 
        /// currently in our database if we have none it will return
        /// an empty List
        /// </summary>
        /// <returns>A List<StudentCourse> populated by our data
        /// or an empty one</returns>
        List<StudentCourse> GetAllStudentCourses();

        /// <summary>
        /// Returns a list of all available
        /// Courses currently in our database
        /// </summary>
        /// <returns>All courses in our database</returns>
        List<Course> GetAllCourses();

        /// <summary>
        /// Returns a list of all students currently
        /// in our database.
        /// </summary>
        /// <returns>A list of Student objects</returns>
        List<Student> GetAllStudents();

    }
}
