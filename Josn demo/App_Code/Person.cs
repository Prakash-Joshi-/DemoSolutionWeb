using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Josn_demo.App_Code
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Boolean isAlive { get; set; }
        [ScriptIgnore]
        public int SomePropDontSerialize { get; set; }

        public Person(string pFName, string pLName, Boolean pIsAlive, int pSomePropDontSerialize)
        {
            this.FirstName = pFName;
            this.LastName = pLName;
            this.isAlive = pIsAlive;
            this.SomePropDontSerialize = pSomePropDontSerialize;
        }
    }

}