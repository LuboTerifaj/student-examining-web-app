using AutoMapper;
using BL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class Mapping
    {
        public static IMapper Mapper { get; }

        static Mapping ()
        {
            var config = new MapperConfiguration (c => 
            {
                c.CreateMap<Answer, AnswerDTO>();
                c.CreateMap<AnswerDTO, Answer>();
                c.CreateMap<Question, QuestionDTO>();
                c.CreateMap<QuestionDTO, Question>();
                c.CreateMap<Student, StudentDTO>();
                c.CreateMap<StudentDTO, Student>();
                c.CreateMap<StudentGroup, StudentGroupDTO>();
                c.CreateMap<StudentGroupDTO, StudentGroup>();
                c.CreateMap<Teacher, TeacherDTO>();
                c.CreateMap<TeacherDTO, Teacher>();
                c.CreateMap<Test, TestDTO>();
                c.CreateMap<TestDTO, Test>();
                c.CreateMap<Topic, TopicDTO>();
                c.CreateMap<TopicDTO, Topic>();
                c.CreateMap<TestResult, TestResultDTO>();
                c.CreateMap<TestResultDTO, TestResult>();

                c.CreateMap<User, UserDTO>();
                c.CreateMap<UserDTO, User>();
            }
                );

            Mapper = config.CreateMapper();
        }
    }
}
