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
   public class StudentFacade
    {

        private readonly StudentExaminingContext context;

        public StudentFacade(StudentExaminingContext context)
        {
            this.context = context;
        }
        public void CreateStudent(StudentDTO student)
        {
            Student newStudent = Mapping.Mapper.Map<Student>(student);
            context.Database.Log = Console.WriteLine;
            context.Students.Add(newStudent);
            context.SaveChanges();
        }

        public void EditStudent(StudentDTO student)
        {
            var toEdit = Mapping.Mapper.Map<Student>(student);
            context.Entry(toEdit).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteStudent(StudentDTO student)
        {
            Student toDelete = Mapping.Mapper.Map<Student>(student);
            context.Database.Log = Console.WriteLine;
            context.Entry(toDelete).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void DeleteStudent(int ID)
        {
            context.Database.Log = Console.WriteLine;
            var student = context.Students.Find(ID);
            context.Students.Remove(student);
            context.SaveChanges();
        }

        public StudentDTO GetStudentByID(int ID)
        {
            context.Database.Log = Console.WriteLine;
            var student = context.Students.Find(ID);
            return Mapping.Mapper.Map<StudentDTO>(student);
        }

        public List<StudentDTO> GetAllStudents()
        {
            var students = new List<StudentDTO>();
            foreach (var item in context.Students)
            {
                 students.Add(Mapping.Mapper.Map<StudentDTO>(item));
            }
            return students;
        }
    }
}
