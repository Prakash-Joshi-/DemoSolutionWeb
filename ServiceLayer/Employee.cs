using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class Employee
    {
        public IEnumerable GetEmployee()
        {
            return new List<string>() { "Ram", "Shyam", "Arjun", "Bhim","Nakul", "Sahdev","Gaurav" };
        }
    }
}
