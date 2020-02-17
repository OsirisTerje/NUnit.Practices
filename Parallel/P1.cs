using System;
using System.Threading;
using NUnit.Framework;


// Also see https://github.com/nunit/docs/wiki/LevelOfParallelism-Attribute, for setting in assemblies

namespace Parallel
{
   // [Parallelizable(ParallelScope.All)]  // https://github.com/nunit/docs/wiki/Framework-Parallel-Test-Execution
    public class P1
    {
        DateTime start;

        [OneTimeSetUp]
        public void Init()
        {
            start = DateTime.Now;
        }

        [Test]
        public void Test_One()
        {
            Thread.Sleep(1000);
            double secs = (DateTime.Now - start).TotalMilliseconds;
            TestContext.Error.WriteLine($"One {secs}");
        }

        [Test]
        public void Test_Two()
        {
            Thread.Sleep(1000);
            double secs = (DateTime.Now - start).TotalMilliseconds;
            TestContext.Error.WriteLine($"Two {secs}");
        }


        [Test]
        public void Test_Three()
        {
            Thread.Sleep(1000);
            double secs = (DateTime.Now - start).TotalMilliseconds;
            TestContext.Error.WriteLine($"Three {secs}");
        }

        [Test]
        public void Test_Four()
        {
            Thread.Sleep(1000);
            double secs = (DateTime.Now - start).TotalMilliseconds;
            TestContext.Error.WriteLine($"Four {secs}");
        }

        [Test]
        public void Test_Five()
        {
            Thread.Sleep(1000);
            double secs = (DateTime.Now - start).TotalMilliseconds;
            TestContext.Error.WriteLine($"Five {secs}");
        }


        [Test]
        public void Test_Six()
        {
            Thread.Sleep(1000);
            double secs = (DateTime.Now - start).TotalMilliseconds;
            TestContext.Error.WriteLine($"Six {secs}");
        }
    }
}
