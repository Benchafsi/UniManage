﻿using UniversityDatabaseManagementWebApp.Models;

namespace UniversityDatabaseManagementWebApp.DAO
{
    public interface ITeacherDAO
    {
        void Insert(Teacher? teacher);
        void Update(Teacher? teacher);
        Teacher? Delete(Teacher? teacher);
        Teacher? GetTeacher(int id);
        List<Teacher> GetAll();
    }
}
