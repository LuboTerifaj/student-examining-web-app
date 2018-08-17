using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DAL;
using BL.Facades;

namespace BL
{
    public class DataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<StudentExaminingContext>().LifestyleTransient(),
                
                Component.For<AnswerFacade>().LifestyleTransient(),

                Component.For<QuestionFacade>().LifestyleTransient(),

                Component.For<StudentFacade>().LifestyleTransient(),

                Component.For<StudentGroupFacade>().LifestyleTransient(),

                Component.For<TeacherFacade>().LifestyleTransient(),

                Component.For<TestFacade>().LifestyleTransient(),

                Component.For<TopicFacade>().LifestyleTransient(),

                Component.For<TestResultFacade>().LifestyleTransient()
                );
        }
    }
}
