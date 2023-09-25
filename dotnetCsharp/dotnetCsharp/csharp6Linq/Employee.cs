using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetCsharp.csharp6Linq
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        
        public string Department { get; set; }
        public int Salarly { get; set; }
        
        public override string ToString()
        {
            return Id.ToString() + " " + Name + " " + City + " " + Department + " " + Salarly.ToString();

        }

    }
}
