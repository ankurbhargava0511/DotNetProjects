using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.AsyncProgramming
{
    public static class Task5ReturnComplexTypeExample
    {
        public static void runTaskReturn()
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            Task<Student> task1 = Task.Run(() => {

                Student _student = new Student()
                {
                    Id = 1,
                    Name = "DotNetOffice"
                };
                return _student;
            });

            Student info = task1.Result;

            task1.Wait();

            Console.WriteLine("student Id is :- " + info.Id + " And Name is " + info.Name);

            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
            
        }
       
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
