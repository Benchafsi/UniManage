using UniversityDatabaseManagementWebApp.DTO;
using UniversityDatabaseManagementWebApp.Models;

namespace UniversityDatabaseManagementWebApp.Service
{
    public interface ICourseService
    {
        /// <summary>
        /// Inserts a Course record into our database
        /// based on user input.A teacher must be available
        /// to be referenced because his id is a foreign
        /// key in our database
        /// </summary>
        /// <param name="dto">The DTO object to be converted to 
        /// Course Object</param>
        void InsertCourse(CourseDTO? dto);

        /// <summary>
        /// Updates a Course record in our database based on user
        /// input,a new Decription and a new Teacher id
        /// can be given as parameters but not a new
        /// course id because it's auto-increment for
        /// error prevention purposes
        /// </summary>
        /// <param name="dto">The DTO object to be converted to
        /// Course Object with the same id</param>
        void UpdateCourse(CourseDTO? dto);

        /// <summary>
        /// Deletes a Course record from our database
        /// 
        /// </summary>
        /// <param name="dto">The DTO object to be converted to
        /// Course Object</param>
        /// <returns>The deleted record of null if it was not found</returns>
        Course? DeleteCourse(CourseDTO? dto);

        /// <summary>
        /// Returns a Course record based on 
        /// input id
        /// </summary>
        /// <param name="id">The course id</param>
        /// <returns>The Course record</returns>
        Course? GetCourse(int id);

        /// <summary>
        /// Returns a list of all available
        /// Courses currently in our database
        /// </summary>
        /// <returns>All courses in our database</returns>
        List<Course> GetAllCourses();

        /// <summary>
        /// Returns a list of all teachers currently
        /// in our database.
        /// </summary>
        /// <returns>A list of Teacher objects</returns>
        List<Teacher> GetAllTeachersForKey();
    }
}
