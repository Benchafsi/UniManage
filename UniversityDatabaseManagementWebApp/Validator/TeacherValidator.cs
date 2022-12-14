using UniversityDatabaseManagementWebApp.DTO;

namespace UniversityDatabaseManagementWebApp.Validator
{
    public class TeacherValidator
    {
        /// <summary>
        /// No instances of this class should be available
        /// </summary>
        private TeacherValidator() { }

        public static string Validate(TeacherDTO? dto)
        {
            if (dto is not null && dto.Firstname is not null && dto.Lastname is not null)
            {
                if ((dto.Firstname.Length < 3) || (dto.Lastname.Length < 3))
                {
                    return "Firstname or Lastname should not be less than three characters";
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
