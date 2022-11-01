using UniversityDatabaseManagementWebApp.DTO;

namespace UniversityDatabaseManagementWebApp.Validator
{
    public class CourseValidator
    {
        /// <summary>
        /// No instances of this class should be available
        /// </summary>
        private CourseValidator() { }

        public static string Validate(CourseDTO? dto)
        {
            if (dto is not null && dto.Description is not null)
            {
                if ((dto.Description.Length < 3))
                {
                    return "Subject description should not be less than three characters";
                }
                else
                {
                    return "";
                }


            }
            else
            {
                return "";
            }
        }
    }
}
