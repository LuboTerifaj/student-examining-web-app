using BL.DTO;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Facades
{
    public class TeacherFacade
    {

        private readonly StudentExaminingContext context;

        public TeacherFacade(StudentExaminingContext context)
        {
            this.context = context;
        }

        public void CreateTeacher(TeacherDTO teacher)
        {
            Teacher newTeacher = Mapping.Mapper.Map<Teacher>(teacher);

            context.Database.Log = Console.WriteLine;
            context.Teachers.Add(newTeacher);
            context.SaveChanges();
        }

        public void EditTeacher(TeacherDTO teacher)
        {
            var toEdit = Mapping.Mapper.Map<Teacher>(teacher);
            context.Entry(toEdit).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteTeacher(TeacherDTO teacher)
        {
            Teacher toDelete = Mapping.Mapper.Map<Teacher>(teacher);

            context.Database.Log = Console.WriteLine;
            context.Entry(toDelete).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void DeleteTeacher(int ID)
        {
            context.Database.Log = Console.WriteLine;
            var teacher = context.Teachers.Find(ID);
            context.Teachers.Remove(teacher);
            context.SaveChanges();
        }

        public TeacherDTO GetTeacherByID(int ID)
        {
            context.Database.Log = Console.WriteLine;
            var teacher = context.Teachers.Find(ID);
            return Mapping.Mapper.Map<TeacherDTO>(teacher);
        }

        public List<TeacherDTO> GetAllTeachers()
        {
            var teachers = new List<TeacherDTO>();
            foreach (var item in context.Teachers)
            {
                teachers.Add(Mapping.Mapper.Map<TeacherDTO>(item));
            }
            return teachers;
        }
    }
}
