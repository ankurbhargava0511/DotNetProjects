using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace dotnetCsharp.csharp6Linq
{
    public  class Linq1ExtensionMethod
    {
        public IEnumerable<Employee> GetEmployee()
        {
            return new List<Employee>()
            {
                new Employee() { Id = 110, Name = "TestName1", City = "Mumbai", Department = "Testing", Salarly = 2000 },
                new Employee() { Id = 111, Name = "Bad", City = "Pune", Department = "Devlopment", Salarly = 2400 },
                new Employee() { Id = 112, Name = "TestName3", City = "Pune", Department = "Testing", Salarly = 2500 },
                new Employee() { Id = 113, Name = "Abcd", City = "Mumbai", Department = "DevOps", Salarly = 2600 },

                new Employee() { Id = 114, Name = "Employee", City = "Bangalore", Department = "Devops", Salarly = 2000 },
                new Employee() { Id = 115, Name = "TestName1", City = "Bangalore", Department = "Manager", Salarly = 5000 },

                new Employee() { Id = 116, Name = "Good", City = "Pune", Department = "Development", Salarly = 2000 },
                new Employee() { Id = 117, Name = "TestName1", City = "Mumbai", Department = "Manager", Salarly = 4000 },

                new Employee() { Id = 118, Name = "TestMe", City = "Delhi", Department = "Devops", Salarly = 2000 },
                new Employee() { Id = 119, Name = "Work", City = "Mumbai", Department = "Development", Salarly = 3000 },
            };
        }

        public void LinqTest()
        {
            var employess = GetEmployee();

            Console.WriteLine("Filter Extension");
            Console.WriteLine("Where");

            Print(employess.Where(emp => emp.City == "Mumbai"));

            Console.WriteLine("ofType");

            Console.WriteLine("Sorting Extension");

            Console.WriteLine("OrderBy ThenBy");

            Print(employess.OrderBy(emp => emp.Salarly).ThenBy(emp=>emp.Name));

            Console.WriteLine("OrderByDesc ThenByDec");

            Print(employess.OrderByDescending(emp => emp.Salarly).ThenByDescending(emp => emp.Name));

            Console.WriteLine("Reverse");

            Print(employess.Reverse());


            Console.WriteLine("Grouping Extension");

            //Groupby

            Console.WriteLine("Join Extension");

            //Join
            Console.WriteLine("Project Extension");

            //Select // Select Many,

            Console.WriteLine("Aggregate Extension");
            Console.WriteLine("Average");
            Console.WriteLine(employess.Average(emp => emp.Salarly));

            Console.WriteLine("Count");
            Console.WriteLine(employess.Count());


            Console.WriteLine("Max");
            Console.WriteLine(employess.Max(emp => emp.Salarly));


            Console.WriteLine("Min");
            Console.WriteLine(employess.Min(emp => emp.Salarly));


            Console.WriteLine("Sum");
            Console.WriteLine(employess.Sum(emp => emp.Salarly));



            
            Console.WriteLine("Quantify Extension");

            //all, any , contains,

            Console.WriteLine("Element Extension");



            // //     Elementat Electatdefault, first, fisrt or default, last , lastordefault, single, single or default, 
            Console.WriteLine("Set Operation Extension");

            // distict, except, intesect, union

            Console.WriteLine("Partition Extension");
            //skip, skipwhile take, takewhile,

            Console.WriteLine("Concatenate Extension");
            //concat,

            Console.WriteLine("Equality Extension");

            //sequenceEqual, 
            Console.WriteLine("Generation Extension");

            //defaultEmpty, empty, rAnge, repeat, 
            Console.WriteLine("Conversion Extension");
            //Asenumerable, asquerable, cast, toarray, toDictor, to list












        }

        public void Print(IEnumerable<Employee> emp) 
        { 
            foreach (Employee e in emp)
            {
                Console.WriteLine(e.ToString());
            }
        }



    }
}
