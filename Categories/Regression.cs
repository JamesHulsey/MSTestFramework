using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestFramework.Categories
{
    public class Regression : TestMethodAttribute
    {
        public virtual TestResult[] Execute(ITestMethod testMethod)
        {
            return new TestResult[] { testMethod.Invoke(null) };
        }
    }
}
