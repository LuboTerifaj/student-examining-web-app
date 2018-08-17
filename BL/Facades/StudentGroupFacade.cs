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
    public class StudentGroupFacade
    {

        private readonly StudentExaminingContext context;

        public StudentGroupFacade(StudentExaminingContext context)
        {
            this.context = context;
        }
        public void CreateStudentGroup(StudentGroupDTO studentGroup)
        {
            StudentGroup newStudentGroup = Mapping.Mapper.Map<StudentGroup>(studentGroup);
            context.Database.Log = Console.WriteLine;
            context.StudentGroups.Add(newStudentGroup);
            context.SaveChanges();
        }

        public void EditStudentGroup(StudentGroupDTO studentGroup)
        {
            //var toEdit = Mapping.Mapper.Map<StudentGroup>(studentGroup);
            var toEdit = context.StudentGroups.Find(studentGroup.StudentGroupID);
            toEdit.Name = studentGroup.Name;
            toEdit.RegistrateCode = studentGroup.RegistrateCode;

            context.Entry(toEdit).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteStudentGroup(StudentGroupDTO studentGroup)
        {
            StudentGroup toDelete = Mapping.Mapper.Map<StudentGroup>(studentGroup);
            context.Database.Log = Console.WriteLine;
            context.Entry(toDelete).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void DeleteStudentGroup(int ID)
        {
            context.Database.Log = Console.WriteLine;
            var studentGroup = context.StudentGroups.Find(ID);
            context.StudentGroups.Remove(studentGroup);
            context.SaveChanges();
        }

        public StudentGroupDTO GetStudentGroupByID(int ID)
        {
            context.Database.Log = Console.WriteLine;
            var studentGroup = context.StudentGroups.Find(ID);
            return Mapping.Mapper.Map<StudentGroupDTO>(studentGroup);
        }

        public List<StudentGroupDTO> GetAllStudentGroups()
        {
            var studentGroups = new List<StudentGroupDTO>();
            foreach (var item in context.StudentGroups)
            {
                studentGroups.Add(Mapping.Mapper.Map<StudentGroupDTO>(item));
            }
            return studentGroups;
        }
    }
}
