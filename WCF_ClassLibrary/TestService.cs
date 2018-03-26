using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_ClassLibrary
{
    class TestService :ITestService
    {
        public string MyService()
        {
            return "Service called without .svc file";
        }
    }
}
