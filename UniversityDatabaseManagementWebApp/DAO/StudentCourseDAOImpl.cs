using System.Data.SqlClient;
using UniversityDatabaseManagementWebApp.DAO.DBUtil;
using UniversityDatabaseManagementWebApp.Models;

namespace UniversityDatabaseManagementWebApp.DAO
{
    public class StudentCourseDAOImpl : IStudentCourseDAO
    {
        public void Insert(StudentCourse? studentCourse)
        {
            if (studentCourse is null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();

                }
                else { return; }

                string sql = "INSERT INTO STUDENTS_COURSES " +
                    "(STUDENT_ID, COURSE_ID) VALUES " +
                    "(@sid, @cid)";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@sid", studentCourse.StudentId);
                command.Parameters.AddWithValue("@cid", studentCourse.CourseId);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public StudentCourse? Delete(StudentCourse? studentCourse)
        {
            if (studentCourse is null) return null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();

                }
                else { return null; }

                string sql = "DELETE FROM STUDENTS_COURSES WHERE STUDENT_ID = @sid AND COURSE_ID = @cid";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@sid", studentCourse.StudentId);
                command.Parameters.AddWithValue("@cid", studentCourse.CourseId);

                int rowsAffected = command.ExecuteNonQuery();
                return (rowsAffected > 0) ? studentCourse : null;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<StudentCourse> GetAll()
        {
            List<StudentCourse> studentCourses = new();
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();
                }

                string sql = "SELECT * FROM STUDENTS_COURSES";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    StudentCourse studentCourse = new StudentCourse()
                    {
                        StudentId = reader.GetInt32(0),
                        CourseId = reader.GetInt32(1)
                    };

                    studentCourses.Add(studentCourse);
                }

                return studentCourses;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<Course> GetAllC()
        {
            List<Course> courses = new List<Course>();
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();
                }

                string sql = "SELECT * FROM COURSES";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Course course = new Course()
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1),
                        TeacherId = reader.GetInt32(2)
                    };

                    courses.Add(course);
                }

                return courses;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<Student> GetAllS()
        {
            List<Student> students = new List<Student>();
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();
                }

                string sql = "SELECT * FROM STUDENTS";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2)
                    };

                    students.Add(student);
                }

                return students;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

    }
}
